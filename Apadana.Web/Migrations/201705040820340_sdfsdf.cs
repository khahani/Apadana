namespace Apadana.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdfsdf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employers", "CreatedBy", c => c.String());
            AlterColumn("dbo.Employers", "UpdatedBy", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Employers", "UpdatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Employers", "CreatedBy", c => c.String(nullable: false));
        }
    }
}
