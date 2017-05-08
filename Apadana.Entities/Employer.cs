using Apadana.Entities.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Apadana.Entities
{
    public class Employer : IBaseObject, IUserSyncable
    {
        public Employer()
        {
            Jobs = new List<Job>();
        }

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
        [Column(TypeName = "VARCHAR")]
        [StringLength(36)]
        [Index]
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
        [Column(TypeName = "VARCHAR")]
        [StringLength(254)]
        [Index]
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

        public virtual ICollection<Job> Jobs { get; set; }

        [Key]
        public int Id { get; set; }

        public string CreatedBy { get; set; }
        
        public string CreatedDate { get; set; }
        
        public string UpdatedBy { get; set; }
        
        public string UpdatedDate { get; set; }

       
    }
}
