﻿using Apadana.Web.DataContext;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Apadana.Web.Areas.Personel.Controllers
{
    public class EmployersController : Controller
    {
        private ApadanaDb db = new ApadanaDb();
        // GET: Personel/Employers
        public async Task<ActionResult> Index(string searchString)
        {
            var employers = db.Employers.Select(m=>m);

            if (!String.IsNullOrEmpty(searchString))
            {
                employers = employers.Where(m => m.UnitName.Contains(searchString));
            }

            return View(await employers.ToListAsync());
        }

        public ActionResult Create(int id)
    }
}