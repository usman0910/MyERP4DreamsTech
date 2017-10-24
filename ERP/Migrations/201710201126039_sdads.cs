namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class sdads : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClientId = c.Int(nullable: false),
                        ProjectBillingTypeId = c.Int(nullable: false),
                        StartingDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.ProjectBillingTypes", t => t.ProjectBillingTypeId, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.ProjectBillingTypeId);
            
            CreateTable(
                "dbo.ProjectBillingTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ProjectBillingTypeId", "dbo.ProjectBillingTypes");
            DropForeignKey("dbo.Projects", "ClientId", "dbo.Clients");
            DropIndex("dbo.Projects", new[] { "ProjectBillingTypeId" });
            DropIndex("dbo.Projects", new[] { "ClientId" });
            DropTable("dbo.ProjectBillingTypes");
            DropTable("dbo.Projects");
        }
    }
}
