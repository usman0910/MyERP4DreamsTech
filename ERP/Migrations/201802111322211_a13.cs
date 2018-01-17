namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a13 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ComplaintManagements", "ClientId", c => c.Int(nullable: false));
            CreateIndex("dbo.ComplaintManagements", "ClientId");
            AddForeignKey("dbo.ComplaintManagements", "ClientId", "dbo.Clients", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComplaintManagements", "ClientId", "dbo.Clients");
            DropIndex("dbo.ComplaintManagements", new[] { "ClientId" });
            DropColumn("dbo.ComplaintManagements", "ClientId");
        }
    }
}
