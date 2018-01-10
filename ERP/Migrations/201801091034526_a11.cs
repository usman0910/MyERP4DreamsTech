namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BillingMonthlies", "Tax", c => c.Long(nullable: false));
            AddColumn("dbo.Projects", "ClientId", c => c.Int(nullable: false));
            AddColumn("dbo.BillingOneTimes", "Tax", c => c.Long(nullable: false));
            AddColumn("dbo.BillingQuaterlies", "Tax", c => c.Long(nullable: false));
            AddColumn("dbo.BillingYearlies", "Tax", c => c.Long(nullable: false));
            CreateIndex("dbo.Projects", "ClientId");
            AddForeignKey("dbo.Projects", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ClientId", "dbo.Clients");
            DropIndex("dbo.Projects", new[] { "ClientId" });
            DropColumn("dbo.BillingYearlies", "Tax");
            DropColumn("dbo.BillingQuaterlies", "Tax");
            DropColumn("dbo.BillingOneTimes", "Tax");
            DropColumn("dbo.Projects", "ClientId");
            DropColumn("dbo.BillingMonthlies", "Tax");
        }
    }
}
