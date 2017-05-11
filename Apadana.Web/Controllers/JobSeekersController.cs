using Apadana.Entities;
using Apadana.Web.DataContext;
using Apadana.Web.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apadana.Web.Controllers
{
    [AllowAnonymous]
    public class JobSeekersController : Controller
    {
        ApadanaDb db = new ApadanaDb();

        JobSeekerRepo JobSeekerRepo = new JobSeekerRepo();

        public ActionResult Index()
        {
            var jobseekers = JobSeekerRepo.TakeFirsts(10);
            return View(jobseekers);
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View("FastRegister");
        }

        public ActionResult Check(int id)
        {
            JobSeeker jobSeeker = JobSeekerRepo.Get(id);
            return View(jobSeeker);

        }
    }
}