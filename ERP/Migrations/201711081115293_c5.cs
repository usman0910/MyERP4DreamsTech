namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FuelExpenses", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.FuelExpenses", "YearsId");
            DropColumn("dbo.FuelExpenses", "MonthsId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FuelExpenses", "MonthsId", c => c.Int(nullable: false));
            AddColumn("dbo.FuelExpenses", "YearsId", c => c.Int(nullable: false));
            DropColumn("dbo.FuelExpenses", "Date");
        }
    }
}
