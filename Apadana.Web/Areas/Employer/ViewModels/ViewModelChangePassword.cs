using Apadana.Web.Areas.Employer.Localization;
using System.ComponentModel.DataAnnotations;

namespace Apadana.Web.Areas.Employer.ViewModels
{
    public class ViewModelChangePassword
    {
        [Required(ErrorMessageResourceType =typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings =false)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_CurrentPassword")]
        public string CurrentPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_NewPassword")]
        public string NewPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_ConfirmPassword")]
        [Compare("NewPassword", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_confirm_is_not_the_same")]
        public string Confirm { get; set; }
    }
}