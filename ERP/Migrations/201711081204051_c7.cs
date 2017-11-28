namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c7 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MonthlySalaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Month = c.DateTime(nullable: false),
                        Year = c.DateTime(nullable: false),
                        TotalMonthSalary = c.Double(nullable: false),
                        Advance = c.Double(nullable: false),
                        FuelExpence = c.Double(nullable: false),
                        SalaryStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.SalaryStatus", t => t.SalaryStatusId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.SalaryStatusId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.MonthlySalaries", "SalaryStatusId", "dbo.SalaryStatus");
            DropForeignKey("dbo.MonthlySalaries", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.MonthlySalaries", new[] { "SalaryStatusId" });
            DropIndex("dbo.MonthlySalaries", new[] { "EmployeeId" });
            DropTable("dbo.MonthlySalaries");
        }
    }
}
