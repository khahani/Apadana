using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Web.Models
{
    public class SiteIndexPageModel
    {
        public SiteIndexPageModel()
        {
            LatestJob = new List<Job>();
        }

        public List<Job> LatestJob;
    }
}