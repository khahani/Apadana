using Apadana.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Web.ViewModels
{
    public class HomePageViewModel
    {
        public IEnumerable<Job> Jobs { get; set; }
    }
}