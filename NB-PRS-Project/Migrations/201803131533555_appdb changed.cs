namespace NB_PRS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appdbchanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseRequestLineItems", "DateCreated", c => c.DateTime());
            DropColumn("dbo.PurchaseRequestLineItems", "Price");
            DropColumn("dbo.PurchaseRequestLineItems", "LineTotal");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseRequestLineItems", "LineTotal", c => c.Decimal(precision: 18, scale: 2));
            AddColumn("dbo.PurchaseRequestLineItems", "Price", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.PurchaseRequestLineItems", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
