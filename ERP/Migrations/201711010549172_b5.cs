namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectServices", "projectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectSupplies", "projectId", "dbo.Projects");
            DropIndex("dbo.ProjectServices", new[] { "projectId" });
            DropIndex("dbo.ProjectSupplies", new[] { "projectId" });
            DropColumn("dbo.ProjectServices", "IsFirstTime");
            DropColumn("dbo.ProjectServices", "projectId");
            DropColumn("dbo.ProjectSupplies", "IsFirstTime");
            DropColumn("dbo.ProjectSupplies", "projectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectSupplies", "projectId", c => c.Int(nullable: false));
            AddColumn("dbo.ProjectSupplies", "IsFirstTime", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProjectServices", "projectId", c => c.Int(nullable: false));
            AddColumn("dbo.ProjectServices", "IsFirstTime", c => c.Boolean(nullable: false));
            CreateIndex("dbo.ProjectSupplies", "projectId");
            CreateIndex("dbo.ProjectServices", "projectId");
            AddForeignKey("dbo.ProjectSupplies", "projectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProjectServices", "projectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
    }
}
