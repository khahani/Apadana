using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apadana.Entities
{
    public interface IBaseObject
    {
        int Id { get; set; }
   
        string CreatedBy { get; set; }

        DateTime CreatedDate { get; set; }
        
        string UpdatedBy { get; set; }
        
        DateTime UpdatedDate { get; set; }
    }
}
