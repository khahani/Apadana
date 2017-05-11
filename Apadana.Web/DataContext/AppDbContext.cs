using Apadana.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;

namespace Apadana.Web.DataContext
{
    public class AppDbContext : IdentityDbContext<AppUser>
    {
        public AppDbContext()
            : base("DefaultConnection")
        {

        }

        //Trick for publish version not use in real code
        public DbSet<Employer> Employers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<JobSeeker> JobSeeker { get; set; }
    }
}