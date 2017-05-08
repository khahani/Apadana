namespace Apadana.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class add_accepted_job : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Jobs", "Accepted", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Jobs", "Accepted");
        }
    }
}
