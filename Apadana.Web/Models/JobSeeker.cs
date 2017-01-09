using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Apadana.Web.Models
{
    public class JobSeeker
    {
        public int JobSeekerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FatherName { get; set; }
        public string PersonalId { get; set; }//شماره شناسنامه
        public string NationalCode { get; set; }//کدملی
        public DateTime BirthDate { get; set; }
        public string BirthCity { get; set; }
        public int Status { get; set; }
    }
}