namespace NB_PRS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedvirtualPRLIPRLIgetset : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.PurchaseRequests", "PurchaseRequestLineItem_Id", "dbo.PurchaseRequestLineItems");
            DropForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequest_Id", "dbo.PurchaseRequests");
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "PurchaseRequestId" });
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "PurchaseRequest_Id" });
            DropIndex("dbo.PurchaseRequests", new[] { "PurchaseRequestLineItem_Id" });
            DropColumn("dbo.PurchaseRequestLineItems", "PurchaseRequestId");
            RenameColumn(table: "dbo.PurchaseRequestLineItems", name: "PurchaseRequest_Id", newName: "PurchaseRequestId");
            AlterColumn("dbo.PurchaseRequestLineItems", "PurchaseRequestId", c => c.Int(nullable: false));
            CreateIndex("dbo.PurchaseRequestLineItems", "PurchaseRequestId");
            AddForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequestId", "dbo.PurchaseRequests", "Id", cascadeDelete: true);
            DropColumn("dbo.PurchaseRequests", "PurchaseRequestLineItem_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.PurchaseRequests", "PurchaseRequestLineItem_Id", c => c.Int());
            DropForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequestId", "dbo.PurchaseRequests");
            DropIndex("dbo.PurchaseRequestLineItems", new[] { "PurchaseRequestId" });
            AlterColumn("dbo.PurchaseRequestLineItems", "PurchaseRequestId", c => c.Int());
            RenameColumn(table: "dbo.PurchaseRequestLineItems", name: "PurchaseRequestId", newName: "PurchaseRequest_Id");
            AddColumn("dbo.PurchaseRequestLineItems", "PurchaseRequestId", c => c.Int(nullable: false));
            CreateIndex("dbo.PurchaseRequests", "PurchaseRequestLineItem_Id");
            CreateIndex("dbo.PurchaseRequestLineItems", "PurchaseRequest_Id");
            CreateIndex("dbo.PurchaseRequestLineItems", "PurchaseRequestId");
            AddForeignKey("dbo.PurchaseRequestLineItems", "PurchaseRequest_Id", "dbo.PurchaseRequests", "Id");
            AddForeignKey("dbo.PurchaseRequests", "PurchaseRequestLineItem_Id", "dbo.PurchaseRequestLineItems", "Id");
        }
    }
}
