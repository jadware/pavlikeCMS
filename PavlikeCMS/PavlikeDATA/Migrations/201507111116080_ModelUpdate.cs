namespace PavlikeDATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModelUpdate : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Author", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Author", "Media_Id", c => c.Int());
            AddColumn("dbo.Author", "Picture_Id", c => c.Int());
            AddColumn("dbo.Article", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Page", "Published", c => c.Boolean(nullable: false));
            AddColumn("dbo.Page", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.File", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Media", "Author_Id1", c => c.Int());
            AddColumn("dbo.MailSettings", "Active", c => c.Boolean(nullable: false));
            AddColumn("dbo.Seo", "Active", c => c.Boolean(nullable: false));
            CreateIndex("dbo.Author", "Media_Id");
            CreateIndex("dbo.Author", "Picture_Id");
            CreateIndex("dbo.Media", "Author_Id1");
            AddForeignKey("dbo.Author", "Media_Id", "dbo.Media", "Id");
            AddForeignKey("dbo.Media", "Author_Id1", "dbo.Author", "Id");
            AddForeignKey("dbo.Author", "Picture_Id", "dbo.Media", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Author", "Picture_Id", "dbo.Media");
            DropForeignKey("dbo.Media", "Author_Id1", "dbo.Author");
            DropForeignKey("dbo.Author", "Media_Id", "dbo.Media");
            DropIndex("dbo.Media", new[] { "Author_Id1" });
            DropIndex("dbo.Author", new[] { "Picture_Id" });
            DropIndex("dbo.Author", new[] { "Media_Id" });
            DropColumn("dbo.Seo", "Active");
            DropColumn("dbo.MailSettings", "Active");
            DropColumn("dbo.Media", "Author_Id1");
            DropColumn("dbo.File", "Active");
            DropColumn("dbo.Page", "Active");
            DropColumn("dbo.Page", "Published");
            DropColumn("dbo.Article", "Active");
            DropColumn("dbo.Author", "Picture_Id");
            DropColumn("dbo.Author", "Media_Id");
            DropColumn("dbo.Author", "Active");
        }
    }
}
