using Apadana.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Apadana.Web.Security
{
    public static class SyncUserFactory
    {
        public static ISyncUser CreateSyncUser(DbEntityEntry entity, AppUserPrincipal currentUser)
        {
            ISyncUser result = null;

            if (entity.Entity.GetType().Name == typeof(Employer).Name)
            {
                result = new SyncUserWithEmployer(currentUser);
            }

            //Other sync entities goes here

            return result;
        }
    }
}