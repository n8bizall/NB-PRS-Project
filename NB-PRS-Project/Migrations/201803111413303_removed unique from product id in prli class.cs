namespace NB_PRS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removeduniquefromproductidinprliclass : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "ProductId" });
            CreateIndex("dbo.PurchaseRequestLineItems", "ProductId");
        }
        
        public override void Down()
        {
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "ProductId" });
            CreateIndex("dbo.PurchaseRequestLineItems", "ProductId", unique: true);
        }
    }
}
