using System;
using System.ComponentModel.DataAnnotations;
using Apadana.Entities.StaticObjects;
using Apadana.Entities.ViewModels.Job;

namespace Apadana.Entities
{
    public class Job : IBaseObject
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
        public int RelatedWorkExperience { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)EducationType.GetMinimumId, (double)EducationType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_MinimumEducation")]
        public int MinimumEducation { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_FieldOfStudy")]
        public string FieldOfStudy { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)MaximumAgeType.GetMinimumId, (double)MaximumAgeType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_MaxAge")]
        public int MaxAge { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)WorkingHoursType.GetMinimumId, (double)WorkingHoursType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_WorkingHours")]
        public int WorkingHours { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)SalaryType.GetMinimumId, (double)SalaryType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Salary")]
        public int Salary { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)MaritalStatusType.GetMinimumId, (double)MaritalStatusType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Salary")]
        public int MaritalStatus { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)GenderType.GetMinimumId, (double)GenderType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Gender")]
        public int Gender { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)InsuranceStatusType.GetMinimumId, (double)InsuranceStatusType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_InsuranceStatus")]
        public int InsuranceStatus { get; set; }
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)YesOrNoType.GetMinimumId, (double)YesOrNoType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_HasService")]
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
        public int AdsValidityPeriod { get; set; }

        public virtual Employer Owner { get; set; }


        [Key]
        public int Id { get; set; }

        [Required]
        public string CreatedBy { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; }
        [Required]
        public string UpdatedBy { get; set; }
        [Required]
        [DataType(DataType.DateTime)]
        public DateTime UpdatedDate { get; set; }

        public Job()
        {
            Owner = new Employer();
        }

        public static explicit operator Job(VmCreate v)
        {
            return new Job
            {
                Id = v.Id,
                Address = v.Address,
                AdsValidityPeriod= v.AdsValidityPeriod,
                Count = v.Count,
                FieldOfStudy = v.FieldOfStudy,
                Gender = v.Gender,
                HasService = v.HasService,
                InsuranceStatus = v.InsuranceStatus,
                JobTitle = v.JobTitle,
                MaritalStatus = v.MaritalStatus,
                MaxAge = v.MaxAge,
                MinimumEducation = v.MinimumEducation,
                Owner = v.Owner,
                RelatedWorkExperience = v.RelatedWorkExperience,
                Salary = v.Salary,
                ServiceDescription = v.ServiceDescription,
                WorkingHours = v.WorkingHours
            };
        }
    }
}
