using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apadana.Entities.ViewModels.Employer
{
    public class VmCreate
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_UnitName")]
        public string UnitName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Applicant")]
        public string Applicant { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        //[DataType(DataType.PhoneNumber, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_wrong_type")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Mobile")]
        [RegularExpression(@"^\d{11}$", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_wrong_type")]
        public string Mobile { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Address")]
        public string Address { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_UserName")]
        [Index(IsUnique = true)]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_FieldOfAcivity")]
        public string FieldOfAcivity { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Province")]
        [UIHint("Province")]
        public int ProvinceId { get; set; }

        [DataType(DataType.EmailAddress, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_wrong_type")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Email")]
        [Index(IsUnique = true)]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_HeadOfTheUnit")]
        public string HeadOfTheUnit { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        //[DataType(DataType.PhoneNumber, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_wrong_type")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Phone")]
        [RegularExpression(@"^\d{11}$", ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_wrong_type")]
        public string Phone { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_City")]
        public string City { get; set; }

        public static explicit operator Entities.Employer(VmCreate instance)
        {
            return new Entities.Employer
            {
                UnitName = instance.UnitName,
                Applicant = instance.Applicant,
                Mobile = instance.Mobile,
                Address = instance.Address,
                UserName = instance.UserName,
                FieldOfAcivity = instance.FieldOfAcivity,
                ProvinceId = instance.ProvinceId,
                Email = instance.Email,
                HeadOfTheUnit = instance.HeadOfTheUnit,
                Phone = instance.Phone,
                City = instance.City
            };
        }
    }
}
