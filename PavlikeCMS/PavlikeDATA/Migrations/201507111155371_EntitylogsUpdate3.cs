namespace PavlikeDATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitylogsUpdate3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.EntityLog", "Job", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.EntityLog", "Job", c => c.String());
        }
    }
}
