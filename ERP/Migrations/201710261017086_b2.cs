namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectServices", "projectId", c => c.Int(nullable: false));
            AddColumn("dbo.ProjectSupplies", "projectId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProjectServices", "projectId");
            CreateIndex("dbo.ProjectSupplies", "projectId");
            AddForeignKey("dbo.ProjectServices", "projectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProjectSupplies", "projectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectSupplies", "projectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectServices", "projectId", "dbo.Projects");
            DropIndex("dbo.ProjectSupplies", new[] { "projectId" });
            DropIndex("dbo.ProjectServices", new[] { "projectId" });
            DropColumn("dbo.ProjectSupplies", "projectId");
            DropColumn("dbo.ProjectServices", "projectId");
        }
    }
}
