using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apadana.Web.Areas.JobSeeker.Controllers
{
    [Authorize(Roles =AppDefaults.ROLE_JOBSEEKER)]
    public class HomeController : AppController
    {
        // GET: JobSeeker/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}