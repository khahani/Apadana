namespace Apadana.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class jobseeker : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobSeekers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        LastName = c.String(),
                        FatherName = c.String(),
                        Gender = c.Int(nullable: false),
                        Birthdate = c.String(),
                        NationalCode = c.String(),
                        PersonalId = c.String(),
                        MaritalStatus = c.Int(nullable: false),
                        MilitaryStatus = c.Int(nullable: false),
                        LatestDegree = c.Int(nullable: false),
                        FieldOfStudy = c.String(),
                        UniversityName = c.String(),
                        UniversityType = c.Int(nullable: false),
                        CityOfDegree = c.String(),
                        YearOfGraduation = c.String(),
                        GradePointAverage = c.Single(nullable: false),
                        MinimumRelatedExperience = c.String(),
                        AboutSpeciality = c.String(),
                        DescriptionForSpeciality = c.String(),
                        OrganizationName1 = c.String(),
                        OrganizationFieldOfActivity1 = c.String(),
                        OrganizationJobTitle1 = c.String(),
                        OrganizationBeginDate1 = c.String(),
                        OrganizationEndDate1 = c.String(),
                        OrganizationReasonForLeave1 = c.String(),
                        OrganizationName2 = c.String(),
                        OrganizationFieldOfActivity2 = c.String(),
                        OrganizationJobTitle2 = c.String(),
                        OrganizationBeginDate2 = c.String(),
                        OrganizationEndDate2 = c.String(),
                        OrganizationReasonForLeave2 = c.String(),
                        OrganizationName3 = c.String(),
                        OrganizationFieldOfActivity3 = c.String(),
                        OrganizationJobTitle3 = c.String(),
                        OrganizationBeginDate3 = c.String(),
                        OrganizationEndDate3 = c.String(),
                        OrganizationReasonForLeave3 = c.String(),
                        OrganizationName4 = c.String(),
                        OrganizationFieldOfActivity4 = c.String(),
                        OrganizationJobTitle4 = c.String(),
                        OrganizationBeginDate4 = c.String(),
                        OrganizationEndDate4 = c.String(),
                        OrganizationReasonForLeave4 = c.String(),
                        OrganizationName5 = c.String(),
                        OrganizationFieldOfActivity5 = c.String(),
                        OrganizationJobTitle5 = c.String(),
                        OrganizationBeginDate5 = c.String(),
                        OrganizationEndDate5 = c.String(),
                        OrganizationReasonForLeave5 = c.String(),
                        Province = c.Int(nullable: false),
                        City = c.String(),
                        Address = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        Mobile = c.String(),
                        JobTitle = c.String(),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.JobSeekers");
        }
    }
}
