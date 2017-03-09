using Apadana.Entities;
using Apadana.Entities.Security;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apadana.Web.Security
{
    public interface ISyncUser
    {
        void Sync(DbEntityEntry entity);

        Task SyncAsync(DbEntityEntry entity);
    }
}
