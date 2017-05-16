using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apadana.Entities
{
    public class JobApplication : IBaseObject
    {
        public virtual Job Job { get; set; }

        public virtual JobSeeker JobSeeker { get; set; }

        public string Date { get; set; }

        public string Number { get; set; }

        public string CreatedBy { get; set; }

        public string CreatedDate { get; set; }

        [Key]
        public int Id { get; set; }

        public string UpdatedBy { get; set; }

        public string UpdatedDate { get; set; }
    }
}
