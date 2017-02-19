using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apadana.Web.Areas.Employer.ViewModels
{
    public class ViewModelChangePassword
    {
        [Required(ErrorMessage ="رمز فعلی را وارد نمایید", AllowEmptyStrings =false)]
        [DataType(DataType.Password)]
        [Display(Name ="رمز فعلی")]
        public string CurrentPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Compare("NewPassword")]
        public string Confirm { get; set; }
    }
}