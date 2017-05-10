using Apadana.Entities.StaticObjects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Apadana.Entities
{
    public class JobSeeker : IBaseObject
    {
        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Name")]
        public string Name { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_LastName")]
        public string LastName { get; set; }



        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_FatherName")]
        public string FatherName { get; set; }



        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)GenderType.GetMinimumId, (double)GenderType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Gender")]
        [UIHint("Gender")]
        public int Gender { get; set; }




        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Birthdate")]
        public string Birthdate { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_NationalCode")]
        public string NationalCode { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_PersonalId")]
        public string PersonalId { get; set; }



        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)MaritalStatusType.GetMinimumId, (double)MaritalStatusType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_MaritalStatus")]
        [UIHint("MaritalStatus")]
        public int MaritalStatus { get; set; }



        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)MilitaryStatusType.GetMinimumId, (double)MilitaryStatusType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_MilitaryStatus")]
        [UIHint("MilitaryStatus")]
        public int MilitaryStatus { get; set; }



        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)EducationType.GetMinimumId, (double)EducationType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_LatestDegree")]
        [UIHint("Education")]
        public int LatestDegree { get; set; }



        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_FieldOfStudy")]
        public string FieldOfStudy { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_UniversityName")]
        public string UniversityName { get; set; }



        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Range((double)StaticObjects.UniversityType.GetMinimumId, (double)StaticObjects.UniversityType.GetMaximumId, ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_enter_a_valid_number")]
        [Display(ResourceType = typeof(Resources), Name = "DisName_UniversityType")]
        [UIHint("University")]
        public int UniversityType { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_CityOfDegree")]
        public string CityOfDegree { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_YearOfGraduation")]
        public string YearOfGraduation { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_GradePointAverage")]
        public float GradePointAverage { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_MinimumRelatedExperience")]
        public string MinimumRelatedExperience { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_AboutSpeciality")]
        public string AboutSpeciality { get; set; }




        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_DescriptionForSpeciality")]
        public string DescriptionForSpeciality { get; set; }


        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationName")]
        public string OrganizationName1 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationFieldOfActivity")]
        public string OrganizationFieldOfActivity1 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationJobTitle")]
        public string OrganizationJobTitle1 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationBeginDate")]
        public string OrganizationBeginDate1 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationEndDate")]
        public string OrganizationEndDate1 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationReasonForLeave")]
        public string OrganizationReasonForLeave1 { get; set; }


        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationName")]
        public string OrganizationName2 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationFieldOfActivity")]
        public string OrganizationFieldOfActivity2 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationJobTitle")]
        public string OrganizationJobTitle2 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationBeginDate")]
        public string OrganizationBeginDate2 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationEndDate")]
        public string OrganizationEndDate2 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationReasonForLeave")]
        public string OrganizationReasonForLeave2 { get; set; }



        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationName")]
        public string OrganizationName3 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationFieldOfActivity")]
        public string OrganizationFieldOfActivity3 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationJobTitle")]
        public string OrganizationJobTitle3 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationBeginDate")]
        public string OrganizationBeginDate3 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationEndDate")]
        public string OrganizationEndDate3 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationReasonForLeave")]
        public string OrganizationReasonForLeave3 { get; set; }



        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationName")]
        public string OrganizationName4 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationFieldOfActivity")]
        public string OrganizationFieldOfActivity4 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationJobTitle")]
        public string OrganizationJobTitle4 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationBeginDate")]
        public string OrganizationBeginDate4 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationEndDate")]
        public string OrganizationEndDate4 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationReasonForLeave")]
        public string OrganizationReasonForLeave4 { get; set; }




        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationName")]
        public string OrganizationName5 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationFieldOfActivity")]
        public string OrganizationFieldOfActivity5 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationJobTitle")]
        public string OrganizationJobTitle5 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationBeginDate")]
        public string OrganizationBeginDate5 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationEndDate")]
        public string OrganizationEndDate5 { get; set; }
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_OrganizationReasonForLeave")]
        public string OrganizationReasonForLeave5 { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Province")]
        [UIHint("Province")]
        public int Province { get; set; }



        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_City")]
        public string City { get; set; }





        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Address")]
        public string Address { get; set; }





        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Email")]
        public string Email { get; set; }

        



        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Phone")]
        public string Phone { get; set; }


        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_Mobile")]
        public string Mobile { get; set; }




        [Required(ErrorMessageResourceType = typeof(Resources), ErrorMessageResourceName = "Val_this_field_is_required", AllowEmptyStrings = false)]
        [DataType(DataType.Text)]
        [Display(ResourceType = typeof(Resources), Name = "DisName_JobTitle")]
        public string JobTitle { get; set; }




        public string CreatedBy { get; set; }
        
        public string CreatedDate { get; set; }

        public int Id { get; set; }

        public string UpdatedBy { get; set; }

        public string UpdatedDate { get; set; }
    }
}
