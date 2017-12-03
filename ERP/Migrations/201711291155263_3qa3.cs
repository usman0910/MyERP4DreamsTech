namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _3qa3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "BillingStatusId", c => c.Int(nullable: true));
            CreateIndex("dbo.Projects", "BillingStatusId");
            AddForeignKey("dbo.Projects", "BillingStatusId", "dbo.BillingStatus", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "BillingStatusId", "dbo.BillingStatus");
            DropIndex("dbo.Projects", new[] { "BillingStatusId" });
            DropColumn("dbo.Projects", "BillingStatusId");
        }
    }
}
