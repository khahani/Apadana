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

            //Implement dependency injection for services like mvc core
            var services = new ServiceCollection();
            ConfigureServices(services);
            var resolver = new DefaultDependencyResolver(services.BuildServiceProvider());
            DependencyResolver.SetResolver(resolver);
        }

        public void ConfigureServices(IServiceCollection services)
        {
            // Add application services.
            services.AddTransient<ISMS_Service, SMS_Service_Demo>();


            //this line of code is for DI for controller and services 
            //resource: http://scottdorman.github.io/2016/03/17/integrating-asp.net-core-dependency-injection-in-mvc-4/
            services.AddControllersAsServices(typeof(Startup).Assembly.GetExportedTypes()
               .Where(t => !t.IsAbstract && !t.IsGenericTypeDefinition)
               .Where(t => typeof(IController).IsAssignableFrom(t)
                  || t.Name.EndsWith("Controller", StringComparison.OrdinalIgnoreCase)));


        }
    }
}
