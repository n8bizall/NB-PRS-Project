namespace NB_PRS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addednullablepropertyiesfortestingPRandPRLI : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseRequestLineItems", "LineTotal", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.PurchaseRequests", "DateUpdated", c => c.DateTime());
            AlterColumn("dbo.PurchaseRequests", "UpdatedByUser", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseRequests", "UpdatedByUser", c => c.Int(nullable: false));
            AlterColumn("dbo.PurchaseRequests", "DateUpdated", c => c.DateTime(nullable: false));
            AlterColumn("dbo.PurchaseRequestLineItems", "LineTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
