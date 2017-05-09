using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ent = Apadana.Entities;
using Apadana.Web.DataContext;
using System.Security.Claims;
using System.Data.Entity.Migrations;

namespace Apadana.Web.Areas.Employer.Controllers
{
    public class EmployersController : AppController
    {
        private ApadanaDb db = new ApadanaDb();
        private AppDbContext appDb = new AppDbContext();

       

        //// GET: Employer/Employers/Details/5
        //public async Task<ActionResult> Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Ent.Employer employer = await db.Employers.FindAsync(id);
        //    if (employer == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(employer);
        //}

        // GET: Employer/Employers/Create
        public ActionResult Create(string systemMessage)
        {

            var existsEmployer = db.Employers.Where(m => m.UserName == CurrentUser.Identity.Name).FirstOrDefault();

            if (existsEmployer != null)
            {
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true, resultType = "redirect", url = Url.Action("Edit", new { id = existsEmployer.Id }) }, JsonRequestBehavior.AllowGet);
                }
                return RedirectToAction("Edit", new { id = existsEmployer.Id });
            }

            var user = appDb.Users.Where(m => m.UserName == CurrentUser.Name).FirstOrDefault();

            var model = new Ent.Employer
            {
                UserName = user.UserName,
                Mobile = user.PhoneNumber
            };
            
            ViewData["SystemMessage"] = systemMessage;
            return View(model);
        }

        // POST: Employer/Employers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Create([Bind(Include = "Id,UnitName,Applicant,Mobile,Address,UserName,FieldOfAcivity,ProvinceId,Email,HeadOfTheUnit,Phone,City")] Ent.Employer model)
        {
            var existsEmployer = db.Employers.Where(m => m.UserName == CurrentUser.Identity.Name).FirstOrDefault();

            if (existsEmployer != null)
            {
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = true, resultType = "redirect", url = Url.Action("Edit", new { id = existsEmployer.Id }) }, JsonRequestBehavior.AllowGet);
                }
                return RedirectToAction("Edit", new { id = existsEmployer.Id });
            }

            Ent.Employer employer = (Ent.Employer)model;

            CheckSystemRules(employer);

          
            if (!ModelState.IsValid)
                return View(model);

            bool result = false;

            try
            {
                db.Employers.Add(employer);

                await db.SaveChangesAsync();

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            if (Request.IsAjaxRequest())
            {
                return Json(new { success = result }, JsonRequestBehavior.AllowGet);
            }

            return View();

        }

        // GET: Employer/Employers/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            Ent.Employer model = await db.Employers.FindAsync(id);

            if (model == null)
            {
                return HttpNotFound();
            }

            return View(model);
        }

        private void CheckSystemRules(Ent.Employer employer)
        {
            //Email must be unique
            //Mobile fill with user mobile number as default

            if (appDb.Users.Where(m => m.Email == employer.Email && m.UserName != CurrentUser.Name && m.Email != null).FirstOrDefault() != null)
            {
                ModelState.AddModelError("duplicate_email", "ایمیل قبلا ثبت شده است");
            }

            if (appDb.Users.Where(m => m.PhoneNumber == employer.Mobile && m.UserName != CurrentUser.Name && m.PhoneNumber != null).FirstOrDefault() != null)
            {
                ModelState.AddModelError("duplicate_mobile", "موبایل قبلا ثبت شده است");
            }
        }

        // POST: Employer/Employers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        public async Task<ActionResult> Edit([Bind(Include = "Id,UnitName,Applicant,Mobile,Address,UserName,FieldOfAcivity,ProvinceId,Email,HeadOfTheUnit,Phone,City")] Ent.Employer model)
        {
            //username can not change
            
            CheckSystemRules(model);

            if (!ModelState.IsValid)
            {
                if (Request.IsAjaxRequest())
                {
                    return Json(new { success = false }, JsonRequestBehavior.AllowGet);
                }
                return View(model);
            }

            bool result = false;

            try
            {
                db.Entry(model).State = EntityState.Modified;
                await db.SaveChangesAsync();

                result = true;
            }
            catch (Exception ex)
            {
                result = false;
            }

            if (Request.IsAjaxRequest())
            {
                return Json(new { success = result }, JsonRequestBehavior.AllowGet);
            }
            
            return View(model);
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
                appDb.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
