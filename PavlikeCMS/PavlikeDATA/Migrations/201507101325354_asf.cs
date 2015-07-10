namespace PavlikeDATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class asf : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MailSettings",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(),
                        Host = c.String(),
                        Port = c.Int(nullable: false),
                        EmailAdress = c.String(),
                        EmailPassword = c.String(),
                        EmailDisplayName = c.String(),
                        EnableSsl = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.Settings", "EMailConfirmation", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Settings", "EMailConfirmation");
            DropTable("dbo.MailSettings");
        }
    }
}
