namespace NB_PRS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _2nullablefieldsonproductfortesting : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "DateUpdated", c => c.DateTime());
            AlterColumn("dbo.Products", "UpdatedByUser", c => c.Int());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "UpdatedByUser", c => c.Int(nullable: false));
            AlterColumn("dbo.Products", "DateUpdated", c => c.DateTime(nullable: false));
        }
    }
}
