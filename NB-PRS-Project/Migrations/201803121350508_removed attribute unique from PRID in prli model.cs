namespace NB_PRS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedattributeuniquefromPRIDinprlimodel : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "PurchaseRequestId" });
            CreateIndex("dbo.PurchaseRequestLineItems", "PurchaseRequestId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "PurchaseRequestId" });
            CreateIndex("dbo.PurchaseRequestLineItems", "PurchaseRequestId", unique: true);
        }
    }
}
