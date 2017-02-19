using Apadana.Web.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Apadana.Web
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
            :base ("DefaultConnection")
        {

        }
        
    }
}