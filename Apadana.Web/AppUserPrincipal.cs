using Apadana.Web.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Apadana.Web
{
    public class AppUserPrincipal : ClaimsPrincipal
    {
        public AppUserPrincipal(ClaimsPrincipal principal)
            : base(principal)
        {
        }

        public string Name
        {
            get
            {
                return this.FindFirst(ClaimTypes.Name).Value;
            }
        }

        public string Mobile
        {
            get
            {
                AppDbContext db = new AppDbContext();
                return db.Users.Where(m => m.UserName == Name).FirstOrDefault().PhoneNumber;
                //return this.FindFirst(ClaimTypes.MobilePhone).Value;
            }
        }
    }
}