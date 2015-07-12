namespace PavlikeDATA.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class EntityLog : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EntityLog",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ErrorId = c.Int(nullable: false),
                        Detail = c.String(),
                        Controller = c.String(),
                        Method = c.String(),
                        EntityModel = c.String(),
                        Job = c.String(),
                        Result = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EntityLog");
        }
    }
}
