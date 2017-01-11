using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apadana.Web.Controllers
{
    public class PostController : Controller
    {
        // GET: Post
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Check(int id)
        {
            return View();
        }
        public ActionResult SimpleListForRightMenu()
        {
            return PartialView("_SimpleListForRightMenu");
        }
    }
}