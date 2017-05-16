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
using Apadana.Web.Repository;

namespace Apadana.Web.Areas.Employer.Controllers
{
    [Authorize(Roles = AppDefaults.ROLE_EMPLOYER)]
    public class JobsController : AppController
    {
        private ApadanaDb db = new ApadanaDb();
        private JobRepo JobRepo = new JobRepo();
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
                //model.Owner = CurrentEmployer;
                model.Accepted = false;
                try
                {
                    await JobRepo.CreateAsync(model, CurrentEmployer.Id);

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
