namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b27 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CableRolls", "FeetPrice", c => c.Single(nullable: false));
            AddColumn("dbo.StockEquipmentOuts", "ProjectId", c => c.Int(nullable: false));
            AddColumn("dbo.Equipments", "UnitPrice", c => c.Single(nullable: false));
            CreateIndex("dbo.StockEquipmentOuts", "ProjectId");
            AddForeignKey("dbo.StockEquipmentOuts", "ProjectId", "dbo.Projects", "Id", cascadeDelete: false);
            DropColumn("dbo.StockCableOuts", "feetPrice");
            DropColumn("dbo.StockEquipmentOuts", "UnitPrice");
            DropColumn("dbo.StockCableIns", "feetPrice");
            DropColumn("dbo.StockEquipmentIns", "UnitPrice");
        }
        
        public override void Down()
        {
            AddColumn("dbo.StockEquipmentIns", "UnitPrice", c => c.Double(nullable: false));
            AddColumn("dbo.StockCableIns", "feetPrice", c => c.Double(nullable: false));
            AddColumn("dbo.StockEquipmentOuts", "UnitPrice", c => c.Double(nullable: false));
            AddColumn("dbo.StockCableOuts", "feetPrice", c => c.Double(nullable: false));
            DropForeignKey("dbo.StockEquipmentOuts", "ProjectId", "dbo.Projects");
            DropIndex("dbo.StockEquipmentOuts", new[] { "ProjectId" });
            DropColumn("dbo.Equipments", "UnitPrice");
            DropColumn("dbo.StockEquipmentOuts", "ProjectId");
            DropColumn("dbo.CableRolls", "FeetPrice");
        }
    }
}
