using Apadana.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Apadana.Entities.Security;
using System.Threading.Tasks;
using System.Data.Entity.Infrastructure;

namespace Apadana.Web.Security
{
    public class SyncUserWithEmployer : BaseSyncUser, ISyncUser
    {
        public SyncUserWithEmployer(AppUserPrincipal currentUser) : base(currentUser)
        {
        }

        public void Sync(DbEntityEntry entity)
        {
            Employer employer = (Employer)entity.Entity;

            //Update user information if neccessery
            var user = appDb.Users.Where(m => m.UserName == CurrentUser.Name).FirstOrDefault();

            if (user.Email != employer.Email)
            {
                user.EmailConfirmed = false;
            }

            if (user.PhoneNumber != employer.Mobile)
            {
                user.PhoneNumberConfirmed = false;
            }

            user.Email = employer.Email;
            user.PhoneNumber = employer.Mobile;

            appDb.SaveChanges();

            //#Feature_Mobile_Confirm

            //#Feature_Email_Confirm
        }

        public async Task SyncAsync(DbEntityEntry entity)
        {
            Employer employer = (Employer)entity.Entity;

            //Update user information if neccessery
            var user = appDb.Users.Where(m => m.UserName == CurrentUser.Name).FirstOrDefault();

            if (user.Email != employer.Email)
            {
                user.EmailConfirmed = false;
            }

            if (user.PhoneNumber != employer.Mobile)
            {
                user.PhoneNumberConfirmed = false;
            }

            user.Email = employer.Email;
            user.PhoneNumber = employer.Mobile;

            await appDb.SaveChangesAsync();

            //#Feature_Mobile_Confirm

            //#Feature_Email_Confirm
        }
    }
}