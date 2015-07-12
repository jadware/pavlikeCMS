namespace PavlikeDATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitylogsUpdate2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EntityLog", "Class", c => c.String());
            DropColumn("dbo.EntityLog", "Controller");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EntityLog", "Controller", c => c.String());
            DropColumn("dbo.EntityLog", "Class");
        }
    }
}
