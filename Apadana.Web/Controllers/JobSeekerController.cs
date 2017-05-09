using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apadana.Web.Controllers
{
    [AllowAnonymous]
    public class JobSeekerController : AppController
    {
        // GET: JobSeeker
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View("FastRegister");
        }

        public ActionResult Check(int id)
        {
            return View();

        }
    }
}