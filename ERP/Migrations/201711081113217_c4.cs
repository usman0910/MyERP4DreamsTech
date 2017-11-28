namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FuelExpenses", "MonthsId", "dbo.Months");
            DropForeignKey("dbo.FuelExpenses", "YearsId", "dbo.Years");
            DropIndex("dbo.FuelExpenses", new[] { "YearsId" });
            DropIndex("dbo.FuelExpenses", new[] { "MonthsId" });
        }
        
        public override void Down()
        {
            CreateIndex("dbo.FuelExpenses", "MonthsId");
            CreateIndex("dbo.FuelExpenses", "YearsId");
            AddForeignKey("dbo.FuelExpenses", "YearsId", "dbo.Years", "Id", cascadeDelete: true);
            AddForeignKey("dbo.FuelExpenses", "MonthsId", "dbo.Months", "Id", cascadeDelete: true);
        }
    }
}
