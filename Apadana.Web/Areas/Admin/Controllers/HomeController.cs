using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apadana.Web.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        // GET: Admin/Home
        public ActionResult Index()
        {
            return View();
        }

        [AllowAnonymous]
        public ActionResult Signin()
        {
            ViewBag.WrongeUsernameOrPassword = false;
            return View();
        }

        [HttpPost]
        public ActionResult Signin(string username, string password)
        {
            if (username == "admin" && password == "123")
            {
                return RedirectToAction("Index"); ;
            }
            ViewBag.WrongeUsernameOrPassword = true;
            return View();
        }
    }
}