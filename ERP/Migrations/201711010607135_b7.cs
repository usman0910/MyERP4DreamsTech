namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AddToProjects", "ProjectId", c => c.Int(nullable: false));
            AddColumn("dbo.AddToProjects", "ProjectServiceId", c => c.Int(nullable: false));
            AddColumn("dbo.AddToProjects", "ProjectSuppliesId", c => c.Int(nullable: false));
            CreateIndex("dbo.AddToProjects", "ProjectId");
            CreateIndex("dbo.AddToProjects", "ProjectServiceId");
            CreateIndex("dbo.AddToProjects", "ProjectSuppliesId");
            AddForeignKey("dbo.AddToProjects", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AddToProjects", "ProjectServiceId", "dbo.ProjectServices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AddToProjects", "ProjectSuppliesId", "dbo.ProjectSupplies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AddToProjects", "ProjectSuppliesId", "dbo.ProjectSupplies");
            DropForeignKey("dbo.AddToProjects", "ProjectServiceId", "dbo.ProjectServices");
            DropForeignKey("dbo.AddToProjects", "ProjectId", "dbo.Projects");
            DropIndex("dbo.AddToProjects", new[] { "ProjectSuppliesId" });
            DropIndex("dbo.AddToProjects", new[] { "ProjectServiceId" });
            DropIndex("dbo.AddToProjects", new[] { "ProjectId" });
            DropColumn("dbo.AddToProjects", "ProjectSuppliesId");
            DropColumn("dbo.AddToProjects", "ProjectServiceId");
            DropColumn("dbo.AddToProjects", "ProjectId");
        }
    }
}
