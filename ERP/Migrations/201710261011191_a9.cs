namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "ProjectServiceId", "dbo.ProjectServices");
            DropForeignKey("dbo.Projects", "ProjectSuppliesId", "dbo.ProjectSupplies");
            DropIndex("dbo.Projects", new[] { "ProjectServiceId" });
            DropIndex("dbo.Projects", new[] { "ProjectSuppliesId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.Projects", "ProjectSuppliesId");
            CreateIndex("dbo.Projects", "ProjectServiceId");
            AddForeignKey("dbo.Projects", "ProjectSuppliesId", "dbo.ProjectSupplies", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "ProjectServiceId", "dbo.ProjectServices", "Id", cascadeDelete: true);
        }
    }
}
