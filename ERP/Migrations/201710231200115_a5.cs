namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a5 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvanceSalaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        GivenDate = c.DateTime(nullable: false),
                        AdvanceAmount = c.Int(nullable: false),
                        Reason = c.String(),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.FuelExpenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        YearsId = c.Int(nullable: false),
                        MonthsId = c.Int(nullable: false),
                        FuelPrice = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Months", t => t.MonthsId, cascadeDelete: true)
                .ForeignKey("dbo.Years", t => t.YearsId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.YearsId)
                .Index(t => t.MonthsId);
            
            CreateTable(
                "dbo.SalaryStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.FuelExpenses", "YearsId", "dbo.Years");
            DropForeignKey("dbo.FuelExpenses", "MonthsId", "dbo.Months");
            DropForeignKey("dbo.FuelExpenses", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.AdvanceSalaries", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.FuelExpenses", new[] { "MonthsId" });
            DropIndex("dbo.FuelExpenses", new[] { "YearsId" });
            DropIndex("dbo.FuelExpenses", new[] { "EmployeeId" });
            DropIndex("dbo.AdvanceSalaries", new[] { "EmployeeId" });
            DropTable("dbo.SalaryStatus");
            DropTable("dbo.FuelExpenses");
            DropTable("dbo.AdvanceSalaries");
        }
    }
}
