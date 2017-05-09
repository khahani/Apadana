using Apadana.Web.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Apadana.Web.Areas.Personel.Controllers
{
    public class EmployersController : Controller
    {
        private ApadanaDb db = new ApadanaDb();
        // GET: Personel/Employers
        public async Task<ActionResult> Index(string searchString, string message)
        {
            var employers = db.Employers.Select(m=>m);

            if (!String.IsNullOrEmpty(searchString))
            {
                employers = employers.Where(m => m.UnitName.Contains(searchString));
            }

            ViewBag.SearchString = searchString;
            ViewBag.Message = message;

            return View(await employers.ToListAsync());
        }

        public ActionResult Select(int id)
        {
            Session[AppDefaults.SESSION_SELECTED_EMPLOYER] = id;
            string message = "کارفرما انتخاب شد.";
            return RedirectToAction("Index", new { message = message });
        }
        
    }
}