namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a12 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MonthlyHistoryDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillingMonthlyId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        AmountAdded = c.Long(nullable: false),
                        TaxAdded = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillingMonthlies", t => t.BillingMonthlyId, cascadeDelete: true)
                .Index(t => t.BillingMonthlyId);
            
            CreateTable(
                "dbo.OneTimeHistoryDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillingOneTimeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        AmountAdded = c.Long(nullable: false),
                        TaxAdded = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillingOneTimes", t => t.BillingOneTimeId, cascadeDelete: true)
                .Index(t => t.BillingOneTimeId);
            
            CreateTable(
                "dbo.QuaterlyHistoryDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillingQuaterlyId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        AmountAdded = c.Long(nullable: false),
                        TaxAdded = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillingQuaterlies", t => t.BillingQuaterlyId, cascadeDelete: true)
                .Index(t => t.BillingQuaterlyId);
            
            CreateTable(
                "dbo.YearlyHistoryDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        BillingYearlyId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        AmountAdded = c.Long(nullable: false),
                        TaxAdded = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.BillingYearlies", t => t.BillingYearlyId, cascadeDelete: true)
                .Index(t => t.BillingYearlyId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.YearlyHistoryDetails", "BillingYearlyId", "dbo.BillingYearlies");
            DropForeignKey("dbo.QuaterlyHistoryDetails", "BillingQuaterlyId", "dbo.BillingQuaterlies");
            DropForeignKey("dbo.OneTimeHistoryDetails", "BillingOneTimeId", "dbo.BillingOneTimes");
            DropForeignKey("dbo.MonthlyHistoryDetails", "BillingMonthlyId", "dbo.BillingMonthlies");
            DropIndex("dbo.YearlyHistoryDetails", new[] { "BillingYearlyId" });
            DropIndex("dbo.QuaterlyHistoryDetails", new[] { "BillingQuaterlyId" });
            DropIndex("dbo.OneTimeHistoryDetails", new[] { "BillingOneTimeId" });
            DropIndex("dbo.MonthlyHistoryDetails", new[] { "BillingMonthlyId" });
            DropTable("dbo.YearlyHistoryDetails");
            DropTable("dbo.QuaterlyHistoryDetails");
            DropTable("dbo.OneTimeHistoryDetails");
            DropTable("dbo.MonthlyHistoryDetails");
        }
    }
}
