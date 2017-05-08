using Apadana.Entities;
using Apadana.Web.DataContext;
using Apadana.Web.Infrastructure;
using Apadana.Web.Repository;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace Apadana.Web.Controllers
{
    [AllowAnonymous]
    public class JobController : AppController
    {
        private readonly ISMS_Service _smsService;
        private readonly UserManager<AppUser> _userManager;

        public JobController(ISMS_Service sms_service)
            : this(App_Start.Startup.UserManagerFactory.Invoke(), sms_service)
        {

        }

        public JobController(UserManager<AppUser> userManager, ISMS_Service sms_service)
        {
            _userManager = userManager;
            _smsService = sms_service;
        }

        JobRepo JobRepo = new JobRepo();
        // GET: Job
        public ActionResult Index()
        {
            var jobs = JobRepo.TakeFirsts(6);

            return View(jobs);
        }
        public ActionResult Check(int id)
        {
            Job job = JobRepo.Get(id);

            if (job == null)
            {
                return HttpNotFound();
            }

            return View(job);
        }

        public ActionResult SendBySMS(int id)
        {
            if (!User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Register", "Auth");
            }
            _smsService.SendAsync(CurrentUser.Mobile, JobRepo.JobDetailForSMS(id));
            return RedirectToAction("Check", new { Id = id });
        }
    }
}