namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m3 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BillingMonthlies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        BillingStatusId = c.Int(nullable: false),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillingStatus", t => t.BillingStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.BillingStatusId);
            
            CreateTable(
                "dbo.BillingOneTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        BillingStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillingStatus", t => t.BillingStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.BillingStatusId);
            
            CreateTable(
                "dbo.BillingQuaterlies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        BillingStatusId = c.Int(nullable: false),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillingStatus", t => t.BillingStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.BillingStatusId);
            
            CreateTable(
                "dbo.BillingYearlies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        BillingStatusId = c.Int(nullable: false),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillingStatus", t => t.BillingStatusId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.BillingStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.BillingYearlies", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.BillingYearlies", "BillingStatusId", "dbo.BillingStatus");
            DropForeignKey("dbo.BillingQuaterlies", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.BillingQuaterlies", "BillingStatusId", "dbo.BillingStatus");
            DropForeignKey("dbo.BillingOneTimes", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.BillingOneTimes", "BillingStatusId", "dbo.BillingStatus");
            DropForeignKey("dbo.BillingMonthlies", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.BillingMonthlies", "BillingStatusId", "dbo.BillingStatus");
            DropIndex("dbo.BillingYearlies", new[] { "BillingStatusId" });
            DropIndex("dbo.BillingYearlies", new[] { "ProjectId" });
            DropIndex("dbo.BillingQuaterlies", new[] { "BillingStatusId" });
            DropIndex("dbo.BillingQuaterlies", new[] { "ProjectId" });
            DropIndex("dbo.BillingOneTimes", new[] { "BillingStatusId" });
            DropIndex("dbo.BillingOneTimes", new[] { "ProjectId" });
            DropIndex("dbo.BillingMonthlies", new[] { "BillingStatusId" });
            DropIndex("dbo.BillingMonthlies", new[] { "ProjectId" });
            DropTable("dbo.BillingYearlies");
            DropTable("dbo.BillingQuaterlies");
            DropTable("dbo.BillingOneTimes");
            DropTable("dbo.BillingMonthlies");
        }
    }
}
