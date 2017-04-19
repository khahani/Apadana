using Apadana.Web.App_Structure;
using Apadana.Web.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Web.Mvc;
using System.Linq;
using Apadana.Web.Infrastructure;
using Apadana.Web.DataContext;

[assembly: OwinStartup(typeof(Apadana.Web.App_Start.Startup))]

namespace Apadana.Web.App_Start
{
    public class Startup
    {
        public static Func<UserManager<AppUser>> UserManagerFactory { get; private set; }

        public void Configuration(IAppBuilder app)
        {

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = "ApplicationCookie",
                LoginPath = new PathString("/auth/login")
            });

            // configure the user manager
            UserManagerFactory = () =>
            {
                var usermanager = new UserManager<AppUser>(
                    new UserStore<AppUser>(new AppDbContext()));
                // allow alphanumeric characters in username
                usermanager.UserValidator = new UserValidator<AppUser>(usermanager)
                {
                    AllowOnlyAlphanumericUserNames = false
                };

                usermanager.UserLockoutEnabledByDefault = AppSettings.UserLockoutEnabledByDefault;
                usermanager.MaxFailedAccessAttemptsBeforeLockout = AppSettings.MaxFailedAccessAttemptsBeforeLockout;

                // if you want to lock out indefinitely 200 years should be enough
                usermanager.DefaultAccountLockoutTimeSpan = TimeSpan.FromDays(365 * 200);
                return usermanager;
            };

            CreateRolesandUsers();

            //Implement dependency injection for services like mvc core
            var services = new ServiceCollection();
            ConfigureServices(services);
            var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());
            DependencyResolver.SetResolver(resolver);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add application services.
            services.AddTransient<ISMS_Service, Ghasedak_SMS_Service>();


            //this line of code is for DI for controller and services 
            //resource: http://scottdorman.github.io/2016/03/17/integrating-asp.net-core-dependency-injection-in-mvc-4/
            services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
               .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
               .Where(t => typeof(IController).IsAssignableFrom(t)
                  || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));


        }

        private void CreateRolesandUsers()
        {
            AppDbContext context = new AppDbContext();

            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var UserManager = UserManagerFactory.Invoke();

            // creating Creating Employer role  and default user
            if (!roleManager.RoleExists(AppDefaults.ROLE_EMPLOYER))
            {
                var role = new Microsoft.AspNet.Identity.EntityFramework.IdentityRole();
                role.Name = AppDefaults.ROLE_EMPLOYER;
                roleManager.Create(role);
            }

            var user = UserManager.Users.Where(m => m.PhoneNumber == "09394412792").FirstOrDefault();

            if (user == null)
            {
                user = new AppUser();
                user.PhoneNumber = "09394412792";
                user.UserName = "محمدرضا خواهانی";

                string password = "123456";

                var chkUser = UserManager.Create(user, password);

                if (chkUser.Succeeded)
                {
                    UserManager.AddToRole(user.Id, AppDefaults.ROLE_EMPLOYER);
                }
            }
            else
            {
                if (!UserManager.IsInRole(user.Id, AppDefaults.ROLE_EMPLOYER))
                {
                    IdentityResult result = UserManager.AddToRole(user.Id, AppDefaults.ROLE_EMPLOYER);
                }
            }
        }
    }
}
