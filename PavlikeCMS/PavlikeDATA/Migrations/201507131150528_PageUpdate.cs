namespace PavlikeDATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PageUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Page", "RootPage_Id", c => c.Int());
            CreateIndex("dbo.Page", "RootPage_Id");
            AddForeignKey("dbo.Page", "RootPage_Id", "dbo.Page", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Page", "RootPage_Id", "dbo.Page");
            DropIndex("dbo.Page", new[] { "RootPage_Id" });
            DropColumn("dbo.Page", "RootPage_Id");
        }
    }
}
