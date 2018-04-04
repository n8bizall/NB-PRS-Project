namespace NB_PRS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixesdateconstraintsinallmodels : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.PurchaseRequests", "DateCreated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.PurchaseRequests", "DateCreated", c => c.DateTime(nullable: false));
        }
    }
}
