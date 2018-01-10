namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "ProjectId", "dbo.Projects");
            DropIndex("dbo.Clients", new[] { "ProjectId" });
            DropColumn("dbo.Clients", "ProjectId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "ProjectId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clients", "ProjectId");
            AddForeignKey("dbo.Clients", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
        }
    }
}
