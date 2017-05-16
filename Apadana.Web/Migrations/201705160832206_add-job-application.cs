namespace Apadana.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addjobapplication : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.JobApplications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CreatedBy = c.String(),
                        CreatedDate = c.String(),
                        UpdatedBy = c.String(),
                        UpdatedDate = c.String(),
                        Job_Id = c.Int(),
                        JobSeeker_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Jobs", t => t.Job_Id)
                .ForeignKey("dbo.JobSeekers", t => t.JobSeeker_Id)
                .Index(t => t.Job_Id)
                .Index(t => t.JobSeeker_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.JobApplications", "JobSeeker_Id", "dbo.JobSeekers");
            DropForeignKey("dbo.JobApplications", "Job_Id", "dbo.Jobs");
            DropIndex("dbo.JobApplications", new[] { "JobSeeker_Id" });
            DropIndex("dbo.JobApplications", new[] { "Job_Id" });
            DropTable("dbo.JobApplications");
        }
    }
}
