using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Apadana.Entities;
using Apadana.Web.DataContext;
using Apadana.Entities.StaticObjects;
using System;

namespace Apadana.Web.Areas.Employer.Controllers
{
    public class JobsController : AppController
    {
        private ApadanaDb db = new ApadanaDb();
        private Apadana.Entities.Employer CurrentEmployer
        {
            get { return db.Employers.Where(m => m.UserName == CurrentUser.Name).FirstOrDefault(); }
        }

        // GET: Employer/Jobs
        public async Task<ActionResult> Index()
        {
            return View(await db.Jobs.ToListAsync());
        }

        // GET: Employer/Jobs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Employer/Jobs/Create
        public ActionResult Create()
        {
            ViewData["SelectedRelatedWorkExperience"] = RelatedWorkExperienceType.Instance.Objects.First().Id;
            ViewData["SelectedEducation"] = EducationType.Instance.Objects.First().Id;
            ViewData["SelectedMaximumAge"] = MaximumAgeType.Instance.Objects.First().Id;
            ViewData["SelectedWorkingHours"] = WorkingHoursType.Instance.Objects.First().Id;
            ViewData["SelectedSalary"] = SalaryType.Instance.Objects.First().Id;
            ViewData["SelectedMaritalStatus"] = MaritalStatusType.Instance.Objects.First().Id;
            ViewData["SelectedGender"] = GenderType.Instance.Objects.First().Id;
            ViewData["SelectedInsuranceStatus"] = InsuranceStatusType.Instance.Objects.First().Id;
            ViewData["SelectedHasService"] = YesOrNoType.Instance.Objects.First().Id;
            ViewData["SelectedAdsValidityPeriod"] = AdsValidityPeriodType.Instance.Objects.First().Id;

            return View();
        }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (CurrentEmployer == null)
            {
                filterContext.Result = RedirectToAction("create", "employers", new { systemMessage = "لطفا ابتدا اطلاعات پروفایل را کامل کنید" });
                return;
            }

            base.OnActionExecuting(filterContext);
        }
        // POST: Employer/Jobs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,JobTitle,Count,RelatedWorkExperience,MinimumEducation,FieldOfStudy,MaxAge,WorkingHours,Salary,MaritalStatus,Gender,InsuranceStatus,HasService,ServiceDescription,Address,AdsValidityPeriod")] Apadana.Entities.Job model)
        {
            if (ModelState.IsValid)
            {
                model.Owner = CurrentEmployer;
                model.Accepted = false;
                db.Jobs.Add(model);
                try
                {
                    await db.SaveChangesAsync();

                }catch(Exception ex)
                {

                }
                return RedirectToAction("Index");
            }

            return View(model);
        }

        // GET: Employer/Jobs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
           
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }

            ViewData["SelectedRelatedWorkExperience"] = RelatedWorkExperienceType.Instance.Objects.First(m=>m.Id == job.RelatedWorkExperience).Id;
            ViewData["SelectedEducation"] = EducationType.Instance.Objects.First(m=> m.Id == job.MinimumEducation).Id;
            ViewData["SelectedMaximumAge"] = MaximumAgeType.Instance.Objects.First(m => m.Id == job.MaxAge).Id;
            ViewData["SelectedWorkingHours"] = WorkingHoursType.Instance.Objects.First(m => m.Id == job.WorkingHours).Id;
            ViewData["SelectedSalary"] = SalaryType.Instance.Objects.First(m => m.Id == job.Salary).Id;
            ViewData["SelectedMaritalStatus"] = MaritalStatusType.Instance.Objects.First(m => m.Id == job.MaritalStatus).Id;
            ViewData["SelectedGender"] = GenderType.Instance.Objects.First(m => m.Id == job.Gender).Id;
            ViewData["SelectedInsuranceStatus"] = InsuranceStatusType.Instance.Objects.First(m => m.Id == job.InsuranceStatus).Id;
            ViewData["SelectedHasService"] = YesOrNoType.Instance.Objects.First(m => m.Id == job.HasService).Id;
            ViewData["SelectedAdsValidityPeriod"] = AdsValidityPeriodType.Instance.Objects.First(m => m.Id == job.AdsValidityPeriod).Id;

            return View(job);
        }

        // POST: Employer/Jobs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,JobTitle,Count,RelatedWorkExperience,MinimumEducation,FieldOfStudy,MaxAge,WorkingHours,Salary,MaritalStatus,Gender,InsuranceStatus,HasService,ServiceDescription,Address,AdsValidityPeriod")] Job job)
        {
            if (ModelState.IsValid)
            {
                job.Accepted = false;
                db.Entry(job).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewData["SelectedRelatedWorkExperience"] = RelatedWorkExperienceType.Instance.Objects.First(m => m.Id == job.RelatedWorkExperience).Id;
            ViewData["SelectedEducation"] = EducationType.Instance.Objects.First(m => m.Id == job.MinimumEducation).Id;
            ViewData["SelectedMaximumAge"] = MaximumAgeType.Instance.Objects.First(m => m.Id == job.MaxAge).Id;
            ViewData["SelectedWorkingHours"] = WorkingHoursType.Instance.Objects.First(m => m.Id == job.WorkingHours).Id;
            ViewData["SelectedSalary"] = SalaryType.Instance.Objects.First(m => m.Id == job.Salary).Id;
            ViewData["SelectedMaritalStatus"] = MaritalStatusType.Instance.Objects.First(m => m.Id == job.MaritalStatus).Id;
            ViewData["SelectedGender"] = GenderType.Instance.Objects.First(m => m.Id == job.Gender).Id;
            ViewData["SelectedInsuranceStatus"] = InsuranceStatusType.Instance.Objects.First(m => m.Id == job.InsuranceStatus).Id;
            ViewData["SelectedHasService"] = YesOrNoType.Instance.Objects.First(m => m.Id == job.HasService).Id;
            ViewData["SelectedAdsValidityPeriod"] = AdsValidityPeriodType.Instance.Objects.First(m => m.Id == job.AdsValidityPeriod).Id;

            return View(job);
        }

        // GET: Employer/Jobs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Job job = await db.Jobs.FindAsync(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // POST: Employer/Jobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Job job = await db.Jobs.FindAsync(id);
            db.Jobs.Remove(job);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
