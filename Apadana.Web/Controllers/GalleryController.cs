using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apadana.Web.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallary
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ListForSiteFooter()
        {
            return PartialView("_ListForSiteFooter");
        }
    }
}