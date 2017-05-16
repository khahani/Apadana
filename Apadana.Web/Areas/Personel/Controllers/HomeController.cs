﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Apadana.Web.Areas.Personel.Controllers
{
    [Authorize(Roles = AppDefaults.ROLE_PERSONEL)]
    public class HomeController : Controller
    {
        // GET: Personel/Home
        public ActionResult Index()
        {
            return View();
        }
    }
}