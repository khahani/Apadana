using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apadana.Entities
{
    public class Job : IBaseObject
    {


        public string JobTitle { get; set; }
        public int Count { get; set; }
        public int RelatedWorkExperience { get; set; }
        public int MinimumEducation { get; set; }
        public int FieldOfStudy { get; set; }
        public int MaxAge { get; set; }
        public int WorkingHours { get; set; }
        public int Salary { get; set; }
        public int MaritalStatus { get; set; }
        public int Gender { get; set; }
        public int InsuranceStatus { get; set; }
        public int HasService { get; set; }
        public string ServiceDescription { get; set; }
        public string Address { get; set; }
        public int AdsValidityPeriod { get; set; }

        public virtual Employer Owner { get; set; }


        [Key]
        public int Id { get; set; }

        [Required]
        public string CreatedBy { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string UpdatedBy { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime UpdatedDate { get; set; }
    }
}
