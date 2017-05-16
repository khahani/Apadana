using Apadana.Web.DataContext;
using Apadana.Web.Infrastructure;
using Apadana.Web.Models;
using Apadana.Web.ViewModels;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.DataProtection;
using System;
using System.Linq;
using System.Reflection;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Apadana.Web.Controllers
{
    [AllowAnonymous]
    public class AuthController : AppController
    {
        private readonly AppDbContext db = new AppDbContext();
        private readonly UserManager<AppUser> userManager;
        private readonly ISMS_Service _smsService;
        private const string SESSION_NEW_PASSWORD = "new_password";
        private const string SESSION_USER_PHONE_NUMBER_FOR_RESET_PASSWORD = "user_phone_number";
        private string ResetPassword_NewPassword
        {
            get
            {
                if (Session[SESSION_NEW_PASSWORD] == null)
                    return string.Empty;
                return Session[SESSION_NEW_PASSWORD].ToString();
            }
            set
            {
                Session[SESSION_NEW_PASSWORD] = value;
            }
        }
        private string ResetPassword_UserPhoneNumber
        {
            get
            {
                if (Session[SESSION_USER_PHONE_NUMBER_FOR_RESET_PASSWORD] == null)
                    return string.Empty;
                return Session[SESSION_USER_PHONE_NUMBER_FOR_RESET_PASSWORD].ToString();
            }
            set
            {
                Session[SESSION_USER_PHONE_NUMBER_FOR_RESET_PASSWORD] = value;
            }
        }
        public AuthController(ISMS_Service smsService)
        : this(App_Start.Startup.UserManagerFactory.Invoke(), smsService)
        {
        }
        public AuthController(UserManager<AppUser> userManager, ISMS_Service smsService)
        {
            this.userManager = userManager;
            this._smsService = smsService;
        }

        public ActionResult LogOut()
        {
            GetAuthenticationManager().SignOut("ApplicationCookie");
            return RedirectToAction("index", "home");
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = new AppUser
            {
                UserName = model.Name,
                PhoneNumber = model.Mobile
            };
            
            string password = GeneratePassword();

            bool smsResult = await _smsService.SendAsync(model.Mobile, "::مشخصات کاریابی آپادانا::\nنام کاربری:\n{0}\nرمز عبور:\n{1}", new string[] { model.Name, password });

            if (smsResult != true)
            {
                ModelState.AddModelError("SMS Failed", "بدلیل اینکه پیامک برایتان ارسال نشد ثبت نام شما لغو شده است. لطفا مجددا امتحان کنید.");
                return View();
            }

            var result = await userManager.CreateAsync(user, password);
            
            if (result.Succeeded)
            {

                switch (model.Role)
                {
                    case AppDefaults.ROLE_EMPLOYER:
                    case AppDefaults.ROLE_JOBSEEKER:
                        userManager.AddToRole(user.Id, model.Role);
                        break;
                    default:
                        return HttpNotFound();
                }


                await SignIn(user);
                return RedirectToAction("index", "home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("", error);
            }

            return View();
        }

        private string GeneratePassword()
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";

            string password = Membership.GeneratePassword(AppSettings.PasswordLength, AppSettings.NonAlphanumeric);

            if (AppSettings.ContainAlphabet == true && AppSettings.ContainNumber == true)
            {
                password = Regex.Replace(password, @"[^a-zA-Z0-9]", m => new Random().Next(0, 10).ToString());
            }
            if (AppSettings.ContainAlphabet == true && AppSettings.ContainNumber == false)
            {
                password = Regex.Replace(password, @"[^a-zA-Z]", m => new string(Enumerable.Repeat(chars, 1).Select(s => s[new Random().Next(s.Length)]).ToArray()));
            }
            if (AppSettings.ContainAlphabet == false && AppSettings.ContainNumber == true)
            {
                password = Regex.Replace(password, @"[^0-9]", m => new Random().Next(0, 10).ToString());
            }
            if (!AppSettings.CaseSensitive)
            {
                password = password.ToLower();
            }
            return password;
        }

        // GET: Auth
        [HttpGet]
        public ActionResult LogIn(string returnUrl)
        {
            var model = new LogInModel
            {
                ReturnUrl = returnUrl
            };

            return View(model);
        }
        [HttpPost]
        public async Task<ActionResult> LogIn(LogInModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await userManager.FindByPhoneNumberAsync(model.PhoneNumber);

            if (!AppSettings.CaseSensitive)
            {
                model.Password = model.Password.ToLower();
            }

            var result = await userManager.CheckPasswordAsync(user, model.Password);

            if (result == false)
            {
                user = null;
            }

            if (user != null)
            {
                var identity = await userManager.CreateIdentityAsync(
                    user, DefaultAuthenticationTypes.ApplicationCookie);

                GetAuthenticationManager().SignIn(identity);

                return RedirectToAction("RedirectToPanel");
            }

            // user authN failed
            ModelState.AddModelError("", "نام کاربری یا رمز عبور اشتباه است");
            return View();
        }

        [HttpGet]
        public ActionResult ResetPassword()
        {
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> ResetPassword(string phoneNumber)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            var user = await userManager.FindByPhoneNumberAsync(phoneNumber);

            string newPassword = GeneratePassword();

            var provider = new DpapiDataProtectionProvider("Apadana.Web");

            userManager.UserTokenProvider = new DataProtectorTokenProvider<AppUser>(
                provider.Create("ResetPasswordBySMS"));

            string resetToken = await userManager.GeneratePasswordResetTokenAsync(user.Id);

            IdentityResult passwordChangeResult = await userManager.ResetPasswordAsync(user.Id, resetToken, newPassword);

            if (passwordChangeResult.Succeeded)
            {
                ResetPassword_NewPassword = newPassword;
                ResetPassword_UserPhoneNumber = user.PhoneNumber;

                await _smsService.SendAsync(user.PhoneNumber, "رمز جدید: {0}", ResetPassword_NewPassword);

                return RedirectToAction("ResetCompleted");
            }
            else
            {
                ModelState.AddModelError("", "امکان تغییر رمز وجود ندارد لطفا دوباره تلاش کنید.");
            }
            return View();
        }

        [HttpGet]
        public ActionResult ResetCompleted()
        {
            return View();
        }

        public async Task<ActionResult> ResendPassword()
        {
            await _smsService.SendAsync(ResetPassword_UserPhoneNumber, "رمز جدید: {0}", ResetPassword_NewPassword);
            return View("ResetCompleted");
        }
        private string GetRedirectUrl(string returnUrl)
        {
            if (string.IsNullOrEmpty(returnUrl) || !Url.IsLocalUrl(returnUrl))
            {
                return Url.Action("index", "home");
            }

            return returnUrl;
        }

        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }

        private async Task SignIn(AppUser user)
        {
            var identity = await userManager.CreateIdentityAsync(
                user, DefaultAuthenticationTypes.ApplicationCookie);
            GetAuthenticationManager().SignIn(identity);
        }

        [HttpGet]
        public ActionResult RedirectToPanel()
        {
            if (!CurrentUser.Identity.IsAuthenticated)
                return RedirectToAction("index", "home");

            if (CurrentUser.IsInRole(AppDefaults.ROLE_EMPLOYER))
                return RedirectToAction("index", "home", new { area = AppDefaults.AREA_EMPLOYER });
            else if (CurrentUser.IsInRole(AppDefaults.ROLE_PERSONEL))
                return RedirectToAction("index", "home", new { area = AppDefaults.AREA_PERSONEL });
            else if (CurrentUser.IsInRole(AppDefaults.ROLE_JOBSEEKER))
                return RedirectToAction("index", "home", new { area = AppDefaults.AREA_JOBSEEKER });
            return RedirectToAction("index", "home");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && userManager != null)
            {
                userManager.Dispose();
            }
            base.Dispose(disposing);
        }

      
    }
}