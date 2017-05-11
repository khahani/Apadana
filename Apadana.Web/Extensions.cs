using Microsoft.AspNet.Identity;
using System.Linq;
using System.Threading.Tasks;
using System.Data.Entity;
using System;

namespace Apadana.Web
{
    public static class Extensions
    {
        public static async Task<AppUser> FindByPhoneNumberAsync (this UserManager<AppUser> userManager, string phoneNumber)
        {
            return await userManager.Users.Where(m => m.PhoneNumber == phoneNumber).FirstOrDefaultAsync();
        }

        public static string ToPersianDate(this DateTime date)
        {
            System.Globalization.PersianCalendar p = new System.Globalization.PersianCalendar();
            return string.Format("{0}/{1}/{2}", p.GetYear(date), p.GetMonth(date), p.GetDayOfMonth(date));
        }
    }
}