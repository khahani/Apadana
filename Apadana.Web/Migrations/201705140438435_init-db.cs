namespace Apadana.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initdb : DbMigration
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
                        UserName = c.String(nullable: false),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Jobs", "Owner_Id", "dbo.Employers");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Jobs", new[] { "Owner_Id" });
            DropIndex("dbo.Employers", new[] { "Email" });
            DropIndex("dbo.Employers", new[] { "UserName" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.JobSeekers");
            DropTable("dbo.Jobs");
            DropTable("dbo.Employers");
        }
    }
}
