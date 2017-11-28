namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b17 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "ProjectComissionId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "ProjectComissionId");
            AddForeignKey("dbo.Projects", "ProjectComissionId", "dbo.ProjectComissions", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ProjectComissionId", "dbo.ProjectComissions");
            DropIndex("dbo.Projects", new[] { "ProjectComissionId" });
            DropColumn("dbo.Projects", "ProjectComissionId");
        }
    }
}
