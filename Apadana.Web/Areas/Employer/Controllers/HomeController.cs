using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apadana.Web.Infrastructure;
using Microsoft.AspNet.Identity;
using Apadana.Web.Areas.Employer.ViewModels;
using System.Threading.Tasks;

namespace Apadana.Web.Areas.Employer.Controllers
{
    public class HomeController : AppController
    {
        public ActionResult Index()
        {
            return View();
        }
    }
}