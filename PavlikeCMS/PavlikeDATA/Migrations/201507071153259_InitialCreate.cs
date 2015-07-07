namespace PavlikeDATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlbumMedia",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Album_Id = c.Int(),
                        Media_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Album", t => t.Album_Id)
                .ForeignKey("dbo.Media", t => t.Media_Id)
                .Index(t => t.Album_Id)
                .Index(t => t.Media_Id);
            
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Active = c.Boolean(nullable: false),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Author", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.Author",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserGuid = c.String(),
                        RoleGuid = c.String(),
                        Name = c.String(),
                        Surname = c.String(),
                        DateofBirth = c.DateTime(nullable: false),
                        EMail = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Article",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Content = c.String(),
                        ArticleType_Id = c.Int(),
                        Author_Id = c.Int(),
                        Page_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ArticleType", t => t.ArticleType_Id)
                .ForeignKey("dbo.Author", t => t.Author_Id)
                .ForeignKey("dbo.Page", t => t.Page_Id)
                .Index(t => t.ArticleType_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.Page_Id);
            
            CreateTable(
                "dbo.ArticleType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Page",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Url = c.String(),
                        Author_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Author", t => t.Author_Id)
                .Index(t => t.Author_Id);
            
            CreateTable(
                "dbo.File",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Detail = c.String(),
                        Folder = c.String(),
                        Url = c.String(),
                        FileName = c.String(),
                        Extension = c.String(),
                        UploadDateTime = c.DateTime(nullable: false),
                        Author_Id = c.Int(),
                        FileType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Author", t => t.Author_Id)
                .ForeignKey("dbo.FileType", t => t.FileType_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.FileType_Id);
            
            CreateTable(
                "dbo.Document",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Description = c.String(),
                        Active = c.Boolean(nullable: false),
                        Author_Id = c.Int(),
                        FileType_Id = c.Int(),
                        File_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Author", t => t.Author_Id)
                .ForeignKey("dbo.FileType", t => t.FileType_Id)
                .ForeignKey("dbo.File", t => t.File_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.FileType_Id)
                .Index(t => t.File_Id);
            
            CreateTable(
                "dbo.FileType",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Media",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Caption = c.String(),
                        AltText = c.String(),
                        Description = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        Active = c.Boolean(nullable: false),
                        Author_Id = c.Int(),
                        File_Id = c.Int(),
                        FileType_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Author", t => t.Author_Id)
                .ForeignKey("dbo.File", t => t.File_Id)
                .ForeignKey("dbo.FileType", t => t.FileType_Id)
                .Index(t => t.Author_Id)
                .Index(t => t.File_Id)
                .Index(t => t.FileType_Id);
            
            CreateTable(
                "dbo.Slider",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        SubTitle = c.String(),
                        Detail = c.String(),
                        Active = c.Boolean(nullable: false),
                        File_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.File", t => t.File_Id)
                .Index(t => t.File_Id);
            
            CreateTable(
                "dbo.Seo",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.Int(nullable: false),
                        Description = c.String(),
                        Keywords = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Settings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Social",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        ApiKey = c.String(),
                        ApiCode = c.String(),
                        Active = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Slider", "File_Id", "dbo.File");
            DropForeignKey("dbo.Document", "File_Id", "dbo.File");
            DropForeignKey("dbo.Media", "FileType_Id", "dbo.FileType");
            DropForeignKey("dbo.Media", "File_Id", "dbo.File");
            DropForeignKey("dbo.Media", "Author_Id", "dbo.Author");
            DropForeignKey("dbo.AlbumMedia", "Media_Id", "dbo.Media");
            DropForeignKey("dbo.File", "FileType_Id", "dbo.FileType");
            DropForeignKey("dbo.Document", "FileType_Id", "dbo.FileType");
            DropForeignKey("dbo.Document", "Author_Id", "dbo.Author");
            DropForeignKey("dbo.File", "Author_Id", "dbo.Author");
            DropForeignKey("dbo.Page", "Author_Id", "dbo.Author");
            DropForeignKey("dbo.Article", "Page_Id", "dbo.Page");
            DropForeignKey("dbo.Article", "Author_Id", "dbo.Author");
            DropForeignKey("dbo.Article", "ArticleType_Id", "dbo.ArticleType");
            DropForeignKey("dbo.Album", "Author_Id", "dbo.Author");
            DropForeignKey("dbo.AlbumMedia", "Album_Id", "dbo.Album");
            DropIndex("dbo.Slider", new[] { "File_Id" });
            DropIndex("dbo.Media", new[] { "FileType_Id" });
            DropIndex("dbo.Media", new[] { "File_Id" });
            DropIndex("dbo.Media", new[] { "Author_Id" });
            DropIndex("dbo.Document", new[] { "File_Id" });
            DropIndex("dbo.Document", new[] { "FileType_Id" });
            DropIndex("dbo.Document", new[] { "Author_Id" });
            DropIndex("dbo.File", new[] { "FileType_Id" });
            DropIndex("dbo.File", new[] { "Author_Id" });
            DropIndex("dbo.Page", new[] { "Author_Id" });
            DropIndex("dbo.Article", new[] { "Page_Id" });
            DropIndex("dbo.Article", new[] { "Author_Id" });
            DropIndex("dbo.Article", new[] { "ArticleType_Id" });
            DropIndex("dbo.Album", new[] { "Author_Id" });
            DropIndex("dbo.AlbumMedia", new[] { "Media_Id" });
            DropIndex("dbo.AlbumMedia", new[] { "Album_Id" });
            DropTable("dbo.Social");
            DropTable("dbo.Settings");
            DropTable("dbo.Seo");
            DropTable("dbo.Slider");
            DropTable("dbo.Media");
            DropTable("dbo.FileType");
            DropTable("dbo.Document");
            DropTable("dbo.File");
            DropTable("dbo.Page");
            DropTable("dbo.ArticleType");
            DropTable("dbo.Article");
            DropTable("dbo.Author");
            DropTable("dbo.Album");
            DropTable("dbo.AlbumMedia");
        }
    }
}
