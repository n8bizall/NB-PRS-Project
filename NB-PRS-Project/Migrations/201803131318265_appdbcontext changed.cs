namespace NB_PRS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class appdbcontextchanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequestId", "dbo.PurchaseRequests");
            AddColumn("dbo.PurchaseRequestLineItems", "PurchaseRequest_Id", c => c.Int());
            AddColumn("dbo.PurchaseRequests", "PurchaseRequestLineItem_Id", c => c.Int());
            CreateIndex("dbo.PurchaseRequestLineItems", "PurchaseRequest_Id");
            CreateIndex("dbo.PurchaseRequests", "PurchaseRequestLineItem_Id");
            AddForeignKey("dbo.PurchaseRequests", "PurchaseRequestLineItem_Id", "dbo.PurchaseRequestLineItems", "Id");
            AddForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequest_Id", "dbo.PurchaseRequests", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequest_Id", "dbo.PurchaseRequests");
            DropForeignKey("dbo.PurchaseRequests", "PurchaseRequestLineItem_Id", "dbo.PurchaseRequestLineItems");
            DropIndex("dbo.PurchaseRequests", new[] { "PurchaseRequestLineItem_Id" });
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "PurchaseRequest_Id" });
            DropColumn("dbo.PurchaseRequests", "PurchaseRequestLineItem_Id");
            DropColumn("dbo.PurchaseRequestLineItems", "PurchaseRequest_Id");
            AddForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequestId", "dbo.PurchaseRequests", "Id", cascadeDelete: true);
        }
    }
}
