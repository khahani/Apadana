using Apadana.Entities;
using Apadana.Web.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Web.Repository
{
    public class JobSeekerRepo
    {
        ApadanaDb db = new ApadanaDb();

        public IEnumerable<JobSeeker> TakeFirsts(int count)
        {
            var jobseekers = db.JobSeekers.Take(count).ToArray();

            return jobseekers;
        }

        public JobSeeker Get(int id)
        {
            var jobseekers = db.JobSeekers.Where(m => m.Id == id).FirstOrDefault();
            return jobseekers;
        }

    }
}