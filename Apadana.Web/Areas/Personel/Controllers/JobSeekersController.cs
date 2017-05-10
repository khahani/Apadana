using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using En = Apadana.Entities;
using Apadana.Web.DataContext;

namespace Apadana.Web.Areas.Personel.Controllers
{
    public class JobSeekersController : Controller
    {
        private ApadanaDb db = new ApadanaDb();

        // GET: Personel/JobSeekers
        public async Task<ActionResult> Index()
        {
            return View(await db.JobSeekers.ToListAsync());
        }

        // GET: Personel/JobSeekers/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            En.JobSeeker jobSeeker = await db.JobSeekers.FindAsync(id);
            if (jobSeeker == null)
            {
                return HttpNotFound();
            }
            return View(jobSeeker);
        }

        // GET: Personel/JobSeekers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Personel/JobSeekers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Id,Name,LastName,FatherName,Gender,Birthdate,NationalCode,PersonalId,MaritalStatus,MilitaryStatus,LatestDegree,FieldOfStudy,UniversityName,UniversityType,CityOfDegree,YearOfGraduation,GradePointAverage,MinimumRelatedExperience,AboutSpeciality,DescriptionForSpeciality,OrganizationName1,OrganizationFieldOfActivity1,OrganizationJobTitle1,OrganizationBeginDate1,OrganizationEndDate1,OrganizationReasonForLeave1,OrganizationName2,OrganizationFieldOfActivity2,OrganizationJobTitle2,OrganizationBeginDate2,OrganizationEndDate2,OrganizationReasonForLeave2,OrganizationName3,OrganizationFieldOfActivity3,OrganizationJobTitle3,OrganizationBeginDate3,OrganizationEndDate3,OrganizationReasonForLeave3,OrganizationName4,OrganizationFieldOfActivity4,OrganizationJobTitle4,OrganizationBeginDate4,OrganizationEndDate4,OrganizationReasonForLeave4,OrganizationName5,OrganizationFieldOfActivity5,OrganizationJobTitle5,OrganizationBeginDate5,OrganizationEndDate5,OrganizationReasonForLeave5,Province,City,Address,Email,Phone,Mobile,JobTitle")] En.JobSeeker jobSeeker)
        {
            if (ModelState.IsValid)
            {
                db.JobSeekers.Add(jobSeeker);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(jobSeeker);
        }

        // GET: Personel/JobSeekers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            En.JobSeeker jobSeeker = await db.JobSeekers.FindAsync(id);
            if (jobSeeker == null)
            {
                return HttpNotFound();
            }
            return View(jobSeeker);
        }

        // POST: Personel/JobSeekers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Name,LastName,FatherName,Gender,Birthdate,NationalCode,PersonalId,MaritalStatus,MilitaryStatus,LatestDegree,FieldOfStudy,UniversityName,UniversityType,CityOfDegree,YearOfGraduation,GradePointAverage,MinimumRelatedExperience,AboutSpeciality,DescriptionForSpeciality,OrganizationName1,OrganizationFieldOfActivity1,OrganizationJobTitle1,OrganizationBeginDate1,OrganizationEndDate1,OrganizationReasonForLeave1,OrganizationName2,OrganizationFieldOfActivity2,OrganizationJobTitle2,OrganizationBeginDate2,OrganizationEndDate2,OrganizationReasonForLeave2,OrganizationName3,OrganizationFieldOfActivity3,OrganizationJobTitle3,OrganizationBeginDate3,OrganizationEndDate3,OrganizationReasonForLeave3,OrganizationName4,OrganizationFieldOfActivity4,OrganizationJobTitle4,OrganizationBeginDate4,OrganizationEndDate4,OrganizationReasonForLeave4,OrganizationName5,OrganizationFieldOfActivity5,OrganizationJobTitle5,OrganizationBeginDate5,OrganizationEndDate5,OrganizationReasonForLeave5,Province,City,Address,Email,Phone,Mobile,JobTitle")] En.JobSeeker jobSeeker)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobSeeker).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(jobSeeker);
        }

        // GET: Personel/JobSeekers/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            En.JobSeeker jobSeeker = await db.JobSeekers.FindAsync(id);
            if (jobSeeker == null)
            {
                return HttpNotFound();
            }
            return View(jobSeeker);
        }

        // POST: Personel/JobSeekers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            En.JobSeeker jobSeeker = await db.JobSeekers.FindAsync(id);
            db.JobSeekers.Remove(jobSeeker);
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
