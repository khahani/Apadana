using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Apadana.Web.Infrastructure;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using Apadana.Web.Repository;
using Apadana.Web.ViewModels;

namespace Apadana.Web.Areas.Employer.Controllers
{
    [Authorize(Roles = AppDefaults.ROLE_EMPLOYER)]
    public class HomeController : AppController
    {
        
        public ActionResult Index()
        {
            return View();
        }
    }
}