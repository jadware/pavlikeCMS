namespace PavlikeDATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntitylogsUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.EntityLog", "EntityResult", c => c.Int(nullable: false));
            DropColumn("dbo.EntityLog", "Result");
        }
        
        public override void Down()
        {
            AddColumn("dbo.EntityLog", "Result", c => c.Int(nullable: false));
            DropColumn("dbo.EntityLog", "EntityResult");
        }
    }
}
