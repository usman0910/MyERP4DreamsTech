namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BillingMonthlies", "ProjectComissionId", c => c.Int(nullable: false));
            AddColumn("dbo.BillingOneTimes", "ProjectComissionId", c => c.Int(nullable: false));
            AddColumn("dbo.BillingQuaterlies", "ProjectComissionId", c => c.Int(nullable: false));
            AddColumn("dbo.BillingYearlies", "ProjectComissionId", c => c.Int(nullable: false));
            CreateIndex("dbo.BillingMonthlies", "ProjectComissionId");
            CreateIndex("dbo.BillingOneTimes", "ProjectComissionId");
            CreateIndex("dbo.BillingQuaterlies", "ProjectComissionId");
            CreateIndex("dbo.BillingYearlies", "ProjectComissionId");
            AddForeignKey("dbo.BillingMonthlies", "ProjectComissionId", "dbo.ProjectComissions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.BillingOneTimes", "ProjectComissionId", "dbo.ProjectComissions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.BillingQuaterlies", "ProjectComissionId", "dbo.ProjectComissions", "Id", cascadeDelete: false);
            AddForeignKey("dbo.BillingYearlies", "ProjectComissionId", "dbo.ProjectComissions", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BillingYearlies", "ProjectComissionId", "dbo.ProjectComissions");
            DropForeignKey("dbo.BillingQuaterlies", "ProjectComissionId", "dbo.ProjectComissions");
            DropForeignKey("dbo.BillingOneTimes", "ProjectComissionId", "dbo.ProjectComissions");
            DropForeignKey("dbo.BillingMonthlies", "ProjectComissionId", "dbo.ProjectComissions");
            DropIndex("dbo.BillingYearlies", new[] { "ProjectComissionId" });
            DropIndex("dbo.BillingQuaterlies", new[] { "ProjectComissionId" });
            DropIndex("dbo.BillingOneTimes", new[] { "ProjectComissionId" });
            DropIndex("dbo.BillingMonthlies", new[] { "ProjectComissionId" });
            DropColumn("dbo.BillingYearlies", "ProjectComissionId");
            DropColumn("dbo.BillingQuaterlies", "ProjectComissionId");
            DropColumn("dbo.BillingOneTimes", "ProjectComissionId");
            DropColumn("dbo.BillingMonthlies", "ProjectComissionId");
        }
    }
}
