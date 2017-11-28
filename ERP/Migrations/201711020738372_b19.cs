namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockCableOuts", "Totalfeets", c => c.Int(nullable: false));
            AddColumn("dbo.StockCableOuts", "feetPrice", c => c.Double(nullable: false));
            AddColumn("dbo.StockCableIns", "Totalfeets", c => c.Int(nullable: false));
            AddColumn("dbo.StockCableIns", "feetPrice", c => c.Double(nullable: false));
            DropColumn("dbo.StockCableOuts", "Quantity");
            DropColumn("dbo.StockCableOuts", "UnitPrice");
            DropColumn("dbo.CableRolls", "FeetMeasurement");
            DropColumn("dbo.CableRolls", "OtherInfo");
            DropColumn("dbo.StockCableIns", "Quantity");
            DropColumn("dbo.StockCableIns", "UnitPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockCableIns", "UnitPrice", c => c.Double(nullable: false));
            AddColumn("dbo.StockCableIns", "Quantity", c => c.Int(nullable: false));
            AddColumn("dbo.CableRolls", "OtherInfo", c => c.String());
            AddColumn("dbo.CableRolls", "FeetMeasurement", c => c.Int(nullable: false));
            AddColumn("dbo.StockCableOuts", "UnitPrice", c => c.Double(nullable: false));
            AddColumn("dbo.StockCableOuts", "Quantity", c => c.Int(nullable: false));
            DropColumn("dbo.StockCableIns", "feetPrice");
            DropColumn("dbo.StockCableIns", "Totalfeets");
            DropColumn("dbo.StockCableOuts", "feetPrice");
            DropColumn("dbo.StockCableOuts", "Totalfeets");
        }
    }
}
