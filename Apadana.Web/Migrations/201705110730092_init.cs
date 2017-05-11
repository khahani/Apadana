namespace Apadana.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UnitName = c.String(nullable: false),
                        Applicant = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 36, unicode: false),
                        FieldOfAcivity = c.String(nullable: false),
                        ProvinceId = c.Int(nullable: false),
                        Email = c.String(maxLength: 254, unicode: false),
                        HeadOfTheUnit = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        City = c.String(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName)
                .Index(t => t.Email);
            
            CreateTable(
                "dbo.Jobs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        JobTitle = c.String(nullable: false),
                        Count = c.Int(nullable: false),
                        RelatedWorkExperience = c.Int(nullable: false),
                        MinimumEducation = c.Int(nullable: false),
                        FieldOfStudy = c.String(nullable: false),
                        MaxAge = c.Int(nullable: false),
                        WorkingHours = c.Int(nullable: false),
                        Salary = c.Int(nullable: false),
                        MaritalStatus = c.Int(nullable: false),
                        Gender = c.Int(nullable: false),
                        InsuranceStatus = c.Int(nullable: false),
                        HasService = c.Int(nullable: false),
                        ServiceDescription = c.String(),
                        Address = c.String(nullable: false),
                        AdsValidityPeriod = c.Int(nullable: false),
                        Accepted = c.Boolean(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.String(),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employers", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
            CreateTable(
                "dbo.JobSeekers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LastName = c.String(nullable: false),
                        FatherName = c.String(nullable: false),
                        Gender = c.Int(nullable: false),
                        Birthdate = c.String(nullable: false),
                        NationalCode = c.String(nullable: false),
                        PersonalId = c.String(nullable: false),
                        MaritalStatus = c.Int(nullable: false),
                        MilitaryStatus = c.Int(nullable: false),
                        LatestDegree = c.Int(nullable: false),
                        FieldOfStudy = c.String(nullable: false),
                        UniversityName = c.String(nullable: false),
                        UniversityType = c.Int(nullable: false),
                        CityOfDegree = c.String(nullable: false),
                        YearOfGraduation = c.String(nullable: false),
                        GradePointAverage = c.Single(nullable: false),
                        MinimumRelatedExperience = c.String(nullable: false),
                        AboutSpeciality = c.String(nullable: false),
                        DescriptionForSpeciality = c.String(nullable: false),
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
                        City = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        Email = c.String(nullable: false),
                        Phone = c.String(nullable: false),
                        Mobile = c.String(nullable: false),
                        JobTitle = c.String(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "Owner_Id", "dbo.Employers");
            DropIndex("dbo.Jobs", new[] { "Owner_Id" });
            DropIndex("dbo.Employers", new[] { "Email" });
            DropIndex("dbo.Employers", new[] { "UserName" });
            DropTable("dbo.JobSeekers");
            DropTable("dbo.Jobs");
            DropTable("dbo.Employers");
        }
    }
}
