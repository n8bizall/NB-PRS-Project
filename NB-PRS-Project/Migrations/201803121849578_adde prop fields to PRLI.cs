namespace NB_PRS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addepropfieldstoPRLI : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.PurchaseRequestLineItems", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.PurchaseRequestLineItems", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.PurchaseRequestLineItems", "DateUpdated", c => c.DateTime());
            AddColumn("dbo.PurchaseRequestLineItems", "UpdatedByUser", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.PurchaseRequestLineItems", "UpdatedByUser");
            DropColumn("dbo.PurchaseRequestLineItems", "DateUpdated");
            DropColumn("dbo.PurchaseRequestLineItems", "DateCreated");
            DropColumn("dbo.PurchaseRequestLineItems", "Active");
        }
    }
}
