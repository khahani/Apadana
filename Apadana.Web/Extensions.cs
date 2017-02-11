using Microsoft.AspNet.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Apadana.Web
{
    public static class Extensions
    {
        public static async Task<AppUser> FindByPhoneNumberAsync (this UserManager<AppUser> userManager, string phoneNumber)
        {
            return await userManager.Users.Where(m => m.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        }
    }
}