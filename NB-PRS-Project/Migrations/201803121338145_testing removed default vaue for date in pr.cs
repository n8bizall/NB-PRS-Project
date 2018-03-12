namespace NB_PRS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class testingremoveddefaultvauefordateinpr : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseRequests", "DateCreated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PurchaseRequests", "DateUpdated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseRequests", "DateUpdated", c => c.DateTime());
            AlterColumn("dbo.PurchaseRequests", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
