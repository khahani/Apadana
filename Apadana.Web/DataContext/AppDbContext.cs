using Microsoft.AspNet.Identity.EntityFramework;

namespace Apadana.Web.DataContext
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
            : base("DefaultConnection")
        {

        }

    }
}