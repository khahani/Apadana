using System;
using System.ComponentModel.DataAnnotations;
using Apadana.Entities.StaticObjects;
using System.Collections.Generic;

namespace Apadana.Entities
{
    public partial class Job : IBaseObject
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_JobTitle")]
        public string JobTitle { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range(1, 100, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Count")]
        public int Count { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range(0, 30, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_RelatedWorkExperience")]
        [UIHint("RelatedWorkExperience")]
        public int RelatedWorkExperience { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)EducationType.GetMinimumId, (double)EducationType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_MinimumEducation")]
        [UIHint("Education")]
        public int MinimumEducation { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_FieldOfStudy")]
        public string FieldOfStudy { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)MaximumAgeType.GetMinimumId, (double)MaximumAgeType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_MaxAge")]
        [UIHint("MaximumAge")]
        public int MaxAge { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)WorkingHoursType.GetMinimumId, (double)WorkingHoursType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_WorkingHours")]
        [UIHint("WorkingHours")]
        public int WorkingHours { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)SalaryType.GetMinimumId, (double)SalaryType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Salary")]
        [UIHint("Salary")]
        public int Salary { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)MaritalStatusType.GetMinimumId, (double)MaritalStatusType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_MaritalStatus")]
        [UIHint("MaritalStatus")]
        public int MaritalStatus { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)GenderType.GetMinimumId, (double)GenderType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Gender")]
        [UIHint("Gender")]
        public int Gender { get; set; }



        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)InsuranceStatusType.GetMinimumId, (double)InsuranceStatusType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_InsuranceStatus")]
        [UIHint("InsuranceStatus")]
        public int InsuranceStatus { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)YesOrNoType.GetMinimumId, (double)YesOrNoType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_HasService")]
        [UIHint("HasService")]
        public int HasService { get; set; }


        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_ServiceDescription")]
        public string ServiceDescription { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.MultilineText)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Address")]
        public string Address { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)AdsValidityPeriodType.GetMinimumId, (double)AdsValidityPeriodType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_AdsValidityPeriod")]
        [UIHint("AdsValidityPeriod")]
        public int AdsValidityPeriod { get; set; }


        public bool Accepted { get; set; }

        public virtual Employer Owner { get; set; }
        public virtual ICollection<JobApplication> JobApplications { get; set; }

        [Key]
        public int Id { get; set; }
        
        public string CreatedBy { get; set; }
       
        public string CreatedDate { get; set; }
        
        public string UpdatedBy { get; set; }
        
        
        public string UpdatedDate { get; set; }

        public Job()
        {
           // Owner = new Employer();
        }

      
    }
}
