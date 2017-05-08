namespace Apadana.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdfsdf2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employers", "CreatedDate", c => c.String());
            AlterColumn("dbo.Employers", "UpdatedDate", c => c.String());
            AlterColumn("dbo.Jobs", "CreatedBy", c => c.String());
            AlterColumn("dbo.Jobs", "CreatedDate", c => c.String());
            AlterColumn("dbo.Jobs", "UpdatedBy", c => c.String());
            AlterColumn("dbo.Jobs", "UpdatedDate", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Jobs", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Jobs", "UpdatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Jobs", "CreatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Jobs", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Employers", "UpdatedDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Employers", "CreatedDate", c => c.DateTime(nullable: false));
        }
    }
}
