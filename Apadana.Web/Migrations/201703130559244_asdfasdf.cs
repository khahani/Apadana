namespace Apadana.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asdfasdf : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Employers", "CreatedBy", c => c.String(nullable: false));
            AlterColumn("dbo.Employers", "UpdatedBy", c => c.String(nullable: false));
            CreateIndex("dbo.Employers", "UserName", unique: true);
            CreateIndex("dbo.Employers", "Email", unique: true);
        }
        
        public override void Down()
        {
            DropIndex("dbo.Employers", new[] { "Email" });
            DropIndex("dbo.Employers", new[] { "UserName" });
            AlterColumn("dbo.Employers", "UpdatedBy", c => c.Guid(nullable: false));
            AlterColumn("dbo.Employers", "CreatedBy", c => c.Guid(nullable: false));
        }
    }
}
