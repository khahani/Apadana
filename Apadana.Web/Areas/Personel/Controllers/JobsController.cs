using Apadana.Entities;
using Apadana.Web.DataContext;
using Apadana.Web.Repository;
using Apadana.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Apadana.Web.Areas.Personel.Controllers
{
    public class JobsController : AppController
    {
        ApadanaDb db = new ApadanaDb();

        private JobRepo JobRepo = new JobRepo();

        private EmployerRepo EmployerRepo = new EmployerRepo();

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

        public ActionResult Create()
        {
            if (Session[AppDefaults.SESSION_SELECTED_EMPLOYER] == null)
            {
                return RedirectToAction("Index", "Employers", new { message = "ابتدا کارفرمای مورد نظر را انتخاب کنید" });
            }

            int employerId = Convert.ToInt32(Session[AppDefaults.SESSION_SELECTED_EMPLOYER]);

            var employer = EmployerRepo.Get(employerId);

            if (employer == null)
            {
                return HttpNotFound();
            }

            ViewBag.SelectedEmployer = employer.UnitName;

            return View();
        }

        // POST: Employer/Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,JobTitle,Count,RelatedWorkExperience,MinimumEducation,FieldOfStudy,MaxAge,WorkingHours,Salary,MaritalStatus,Gender,InsuranceStatus,HasService,ServiceDescription,Address,AdsValidityPeriod")] Apadana.Entities.Job model)
        {
            if (Session[AppDefaults.SESSION_SELECTED_EMPLOYER] == null)
            {
                return RedirectToAction("Index", "Employers", new { message = "ابتدا کارفرمای مورد نظر را انتخاب کنید" });
            }

            if (ModelState.IsValid)
            { 
                model.Accepted = true;
                try
                {
                    await JobRepo.CreateAsync(model, Convert.ToInt32(Session[AppDefaults.SESSION_SELECTED_EMPLOYER]));

                }
                catch (Exception ex)
                {

                }
                return RedirectToAction("Accepted");
            }

            return View(model);
        }
    }
}