using Apadana.Web.App_Structure;
using Apadana.Web.Areas.Employer.ViewModels;
using Apadana.Web.Infrastructure;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Apadana.Web.Areas.Employer.Controllers
{
    [Authorize(Roles =AppDefaults.ROLE_EMPLOYER)]
    public class AuthController : AppController
    {
        private readonly ISMS_Service _sms_service;
        private readonly UserManager<AppUser> _userManager;

        public object DefaultApp { get; private set; }

        public AuthController(ISMS_Service sms_service)
            :this(App_Start.Startup.UserManagerFactory.Invoke(), sms_service)
        {

        }

        public AuthController(UserManager<AppUser> userManager, ISMS_Service sms_service)
        {
            _userManager = userManager;
            _sms_service = sms_service;
        }

        // GET: Employer/Home
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult ChangePassword()
        {
            return View();
        }
        [HttpPost]
        [MultipleButton(Name="action", Argument = "ChangePassword")]
        public async Task<ActionResult> ChangePassword(ViewModelChangePassword model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            IdentityResult result = await _userManager.ChangePasswordAsync(CurrentUser.Identity.GetUserId(), model.CurrentPassword, model.NewPassword);

            if (Request.IsAjaxRequest())
            {
                return Json(new { success = result.Succeeded }, JsonRequestBehavior.AllowGet);
            }

            if (!result.Succeeded)
            {
                ViewBag.Message = "امکان تغییر رمز وجود ندارد.";
                ViewBag.Errors = result.Errors;
                return View(model);
            }

            return View();
        }

        public ActionResult LogOut()
        {
            GetAuthenticationManager().SignOut("ApplicationCookie");
            return RedirectToAction("index", "home", new { area = string.Empty });
        }
        private IAuthenticationManager GetAuthenticationManager()
        {
            var ctx = Request.GetOwinContext();
            return ctx.Authentication;
        }

        [HttpPost]
        [MultipleButton(Name="action", Argument = "Cancel")]
        public ActionResult Cancel()
        {
            return RedirectToAction("index", "home", new { area = AppDefaults.AREA_EMPLOYER });
        }
    }
}