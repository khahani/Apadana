using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Apadana.Web.ViewModels
{
    public class LogInModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Mobile")]
        [RegularExpression(@"^\d{11}$", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_wrong_type")]
        public string PhoneNumber { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Password")]
        public string Password { get; set; }

        [HiddenInput]
        public string ReturnUrl { get; set; }
    }
}