namespace Apadana.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatejobapplication : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.JobApplications", "Date", c => c.String());
            AddColumn("dbo.JobApplications", "Number", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.JobApplications", "Number");
            DropColumn("dbo.JobApplications", "Date");
        }
    }
}
