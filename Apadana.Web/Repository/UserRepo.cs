using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Web.Repository
{
    public class UserRepo
    {
        public static string GetUserNameById(string userId)
        {
            UserManager<AppUser> userManager = Apadana.Web.App_Start.Startup.UserManagerFactory.Invoke();

            AppUser user = userManager.Users.Where(m => m.Id == userId).FirstOrDefault();

            return user.UserName;
        }
    }
}