namespace NB_PRS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class allowingnullsondatesanduserfortesting : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Vendors", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Vendors", "DateUpdated", c => c.DateTime());
            AlterColumn("dbo.Users", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Users", "DateUpdated", c => c.DateTime());
            AlterColumn("dbo.Users", "UpdatedByUser", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "UpdatedByUser", c => c.Int(nullable: false));
            AlterColumn("dbo.Users", "DateUpdated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Users", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vendors", "DateUpdated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Vendors", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Products", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
