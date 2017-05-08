using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apadana.Web.Models;
using Apadana.Web.Repository;
using Apadana.Web.ViewModels;

namespace Apadana.Web.Controllers
{
    [AllowAnonymous]
    public class HomeController : AppController
    {
        JobRepo JobRepo = new JobRepo();

        public HomeController()
        {
        }

        // GET: Home
        public ActionResult Index()
        {
            HomePageViewModel model = new HomePageViewModel();

            model.Jobs = JobRepo.TakeFirsts(6);
            return View(model);
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