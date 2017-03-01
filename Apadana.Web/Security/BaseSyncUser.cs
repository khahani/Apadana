using Apadana.Web.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Web.Security
{
    public abstract class BaseSyncUser
    {
        public AppDbContext appDb = new AppDbContext();
        public AppUserPrincipal CurrentUser;

        public BaseSyncUser(AppUserPrincipal currentUser)
        {
            CurrentUser = currentUser;
        }
    }
}