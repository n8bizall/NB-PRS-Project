namespace NB_PRS_Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AppDBContexthadchanged : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Users", "DateUpdated", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Users", "DateUpdated", c => c.DateTime());
        }
    }
}
