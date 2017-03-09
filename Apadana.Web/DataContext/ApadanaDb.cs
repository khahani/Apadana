using Apadana.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using Apadana.Entities.Security;
using Apadana.Web.Security;

namespace Apadana.Web.DataContext
{

    public class ApadanaDb : DbContext
    {
        public ApadanaDb()
            : base("DefaultConnection")
        {
        }

        public DbSet<Employer> Employers { get; set; }


        public override int SaveChanges()
        {
            SaveChangesSequence();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            SaveChangesSequence();
            return base.SaveChangesAsync();
        }

        //Because both SaveChanges and SaveChangesAsync not duplicat they call this method
        // and logic code for both come here
        private void SaveChangesSequence()
        {
            EntityChangeRequiredChangesOnUser();
            SaveUserInfoAndTimeForEachTuple();
        }


        //some entities when change user must change to sync information. this method do it.
        private void EntityChangeRequiredChangesOnUser()
        {
            var selectedEntityList = ChangeTracker.Entries()
                                   .Where(x => x.Entity is BaseObject && x.Entity is IUserSyncable &&
                                   (x.State == EntityState.Added || x.State == EntityState.Modified));

            AppUserPrincipal currentUser = new AppUserPrincipal(HttpContext.Current.User as ClaimsPrincipal);

            foreach (var entity in selectedEntityList)
            {
                ISyncUser syncUser = SyncUserFactory.CreateSyncUser(entity, currentUser);

                if (syncUser != null)
                    syncUser.Sync(entity);
            }

        }

        private void SaveUserInfoAndTimeForEachTuple()
        {
            var selectedEntityList = ChangeTracker.Entries()
                                    .Where(x => x.Entity is BaseObject &&
                                    (x.State == EntityState.Added || x.State == EntityState.Modified));

            var userId = new Guid(HttpContext.Current.User.Identity.GetUserId());

            var currentDate = DateTime.Now;

            foreach (var entity in selectedEntityList)
            {
                if (entity.State == EntityState.Added)
                {
                    ((BaseObject)entity.Entity).CreatedBy = userId;
                    ((BaseObject)entity.Entity).CreatedDate = currentDate;

                }
                ((BaseObject)entity.Entity).UpdatedBy = userId;
                ((BaseObject)entity.Entity).UpdatedDate = currentDate;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ApadanaDb>(null);
            base.OnModelCreating(modelBuilder);
        }
    }
}