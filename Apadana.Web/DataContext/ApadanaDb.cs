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
using System.Data.Entity.Infrastructure;

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
                                   .Where(x => x.Entity is IBaseObject && x.Entity is IUserSyncable &&
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
                                    .Where(x => x.Entity is IBaseObject &&
                                    (x.State == EntityState.Added || x.State == EntityState.Modified));

            var userId = new Guid(HttpContext.Current.User.Identity.GetUserId());

            var currentDate = DateTime.Now;
            
            foreach (var entity in selectedEntityList)
            {
                Employer emp = Employers.Where(m => m.Id == ((IBaseObject)entity.Entity).Id).FirstOrDefault<Employer>();

                if (entity.State == EntityState.Added)
                {
                    ((IBaseObject)entity.Entity).CreatedBy = userId.ToString();
                    ((IBaseObject)entity.Entity).CreatedDate = currentDate;

                }
                if (entity.State == EntityState.Modified)
                {
                    var originalValues = entity.OriginalValues;
                    
                }
                ((IBaseObject)entity.Entity).UpdatedBy = userId.ToString();
                ((IBaseObject)entity.Entity).UpdatedDate = currentDate;
            }
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<ApadanaDb>(null);
            base.OnModelCreating(modelBuilder);
        }

        private T CreateWithValues<T>(DbPropertyValues values)
            where T : new()
        {
            T entity = new T();
            Type type = typeof(T);

            foreach (var name in values.PropertyNames)
            {
                var property = type.GetProperty(name);
                property.SetValue(entity, values.GetValue<object>(name));
            }

            return entity;
        }
    }
}