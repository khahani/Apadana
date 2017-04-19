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
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
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
                        CreatedBy = c.String(nullable: false),
                        CreatedDate = c.DateTime(nullable: false),
                        UpdatedBy = c.String(nullable: false),
                        UpdatedDate = c.DateTime(nullable: false),
                        Owner_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employers", t => t.Owner_Id)
                .Index(t => t.Owner_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Jobs", "Owner_Id", "dbo.Employers");
            DropIndex("dbo.Jobs", new[] { "Owner_Id" });
            DropIndex("dbo.Employers", new[] { "Email" });
            DropIndex("dbo.Employers", new[] { "UserName" });
            DropTable("dbo.Jobs");
            DropTable("dbo.Employers");
        }
    }
}
