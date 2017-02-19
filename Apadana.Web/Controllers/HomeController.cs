using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apadana.Web.Models;

namespace Apadana.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : AppController
    {
        private SiteIndexPageModel Model;

        public HomeController()
        {
            Model = new SiteIndexPageModel();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View(Model);
        }
        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Help()
        {
            return View();
        }
    }
}