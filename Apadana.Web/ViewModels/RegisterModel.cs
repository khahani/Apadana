using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apadana.Web.ViewModels
{
    public class RegisterModel
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Mobile { get; set; }
        
    }
}