using Apadana.Entities;
using Apadana.Web.DataContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Web.Repository
{
    public class EmployerRepo
    {
        ApadanaDb db = new ApadanaDb();

        public Employer Get(int id)
        {
            return db.Employers.Find(id);
        }
    }
}