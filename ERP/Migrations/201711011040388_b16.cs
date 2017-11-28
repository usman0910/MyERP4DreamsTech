namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b16 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectComissions", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectComissions", new[] { "ProjectId" });
            DropColumn("dbo.ProjectComissions", "ProjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectComissions", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProjectComissions", "ProjectId");
            AddForeignKey("dbo.ProjectComissions", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
    }
}
