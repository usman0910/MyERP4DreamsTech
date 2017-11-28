namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b23 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockCableOuts", "ProjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Clients", "ProjectId", c => c.Int(nullable: false));
            AddColumn("dbo.ProjectComissions", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.StockCableOuts", "ProjectId");
            CreateIndex("dbo.Clients", "ProjectId");
            CreateIndex("dbo.ProjectComissions", "ProjectId");
            AddForeignKey("dbo.StockCableOuts", "ProjectId", "dbo.Projects", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Clients", "ProjectId", "dbo.Projects", "Id", cascadeDelete: false);
            AddForeignKey("dbo.ProjectComissions", "ProjectId", "dbo.Projects", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectComissions", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Clients", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.StockCableOuts", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectComissions", new[] { "ProjectId" });
            DropIndex("dbo.Clients", new[] { "ProjectId" });
            DropIndex("dbo.StockCableOuts", new[] { "ProjectId" });
            DropColumn("dbo.ProjectComissions", "ProjectId");
            DropColumn("dbo.Clients", "ProjectId");
            DropColumn("dbo.StockCableOuts", "ProjectId");
        }
    }
}
