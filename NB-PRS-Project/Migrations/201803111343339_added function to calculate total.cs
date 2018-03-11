namespace NB_PRS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addedfunctiontocalculatetotal : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseRequestLineItems", "LineTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseRequestLineItems", "LineTotal", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
    }
}
