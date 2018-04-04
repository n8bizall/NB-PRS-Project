namespace NB_PRS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeddatetimeconstraints : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Products", "DateUpdated", c => c.DateTime());
            AlterColumn("dbo.Vendors", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Vendors", "DateUpdated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Vendors", "DateUpdated", c => c.DateTime());
            AlterColumn("dbo.Vendors", "DateCreated", c => c.DateTime());
            AlterColumn("dbo.Products", "DateUpdated", c => c.DateTime());
            AlterColumn("dbo.Products", "DateCreated", c => c.DateTime());
        }
    }
}
