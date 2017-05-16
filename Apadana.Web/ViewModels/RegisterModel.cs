using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Apadana.Web.ViewModels
{
    public class RegisterModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Name")]
        public string Name { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Mobile")]
        [RegularExpression(@"^\d{11}$", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_wrong_type")]
        public string Mobile { get; set; }
        
        public string Role { get; set; }
    }
}