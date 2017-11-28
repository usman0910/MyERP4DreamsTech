namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.AddToProjects", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.AddToProjects", "ProjectServiceId", "dbo.ProjectServices");
            DropForeignKey("dbo.AddToProjects", "ProjectSuppliesId", "dbo.ProjectSupplies");
            DropIndex("dbo.AddToProjects", new[] { "ProjectId" });
            DropIndex("dbo.AddToProjects", new[] { "ProjectServiceId" });
            DropIndex("dbo.AddToProjects", new[] { "ProjectSuppliesId" });
            DropTable("dbo.AddToProjects");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.AddToProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        ProjectServiceId = c.Int(nullable: false),
                        ProjectSuppliesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.AddToProjects", "ProjectSuppliesId");
            CreateIndex("dbo.AddToProjects", "ProjectServiceId");
            CreateIndex("dbo.AddToProjects", "ProjectId");
            AddForeignKey("dbo.AddToProjects", "ProjectSuppliesId", "dbo.ProjectSupplies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AddToProjects", "ProjectServiceId", "dbo.ProjectServices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.AddToProjects", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
    }
}
