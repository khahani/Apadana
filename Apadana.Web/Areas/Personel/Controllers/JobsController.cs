using Apadana.Entities;
using Apadana.Web.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apadana.Web.Areas.Personel.Controllers
{
    public class JobsController : Controller
    {
        ApadanaDb db = new ApadanaDb();
        // GET: Personel/Jobs
        public ActionResult NotAccepted()
        {
            var jobs = db.Jobs.Where(m => m.Accepted == false);
            return View(jobs);
        }

        public ActionResult Accept(int id)
        {
            Job job = db.Jobs.Find(id);

            if (job == null)
            {
                return HttpNotFound();
            }

            job.Accepted = true;

            db.Entry(job).State = EntityState.Modified;

            db.SaveChanges();

            return RedirectToAction("Accepted");
        }

        public ActionResult Accepted()
        {
            var jobs = db.Jobs.Where(m => m.Accepted == true);
            return View(jobs);
        }
    }
}