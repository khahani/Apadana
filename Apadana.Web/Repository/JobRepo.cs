using Apadana.Entities;
using Apadana.Web.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Web;

namespace Apadana.Web.Repository
{
    public class JobRepo
    {
        ApadanaDb db = new ApadanaDb();

        public IEnumerable<Job> TakeFirsts(int count)
        {
            var jobs = db.Jobs.Where(m=>m.Accepted == true).Take(count).ToArray();

            for (int i = 0; i < jobs.Count(); i++)
            {
                jobs[i].Address = new string(jobs[i].Address.Take(10).ToArray());
            }

            return jobs;
        }

        public Job Get(int id)
        {
            var jobs = db.Jobs.Where(m=>m.Id == id && m.Accepted == true).Include(m=>m.Owner).FirstOrDefault();
            return jobs;
        }

        public string JobDetailForSMS(int id)
        {
            Job job = Get(id);

            return string.Format("شماره تماس: {0} آدرس: {1}", job.Owner.Phone, job.Address);
        }
    }
}