namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b11 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "VisitCharges", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "EquipmentInstallationCharges", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "TowerPaintAndMaintenanceCharges", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "OtherCharges", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "StockCableOutId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "StockEquipmentOutId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "StockCableOutId");
            CreateIndex("dbo.Projects", "StockEquipmentOutId");
            AddForeignKey("dbo.Projects", "StockCableOutId", "dbo.StockCableOuts", "Id", cascadeDelete: false);
            AddForeignKey("dbo.Projects", "StockEquipmentOutId", "dbo.StockEquipmentOuts", "Id", cascadeDelete: false);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "StockEquipmentOutId", "dbo.StockEquipmentOuts");
            DropForeignKey("dbo.Projects", "StockCableOutId", "dbo.StockCableOuts");
            DropIndex("dbo.Projects", new[] { "StockEquipmentOutId" });
            DropIndex("dbo.Projects", new[] { "StockCableOutId" });
            DropColumn("dbo.Projects", "StockEquipmentOutId");
            DropColumn("dbo.Projects", "StockCableOutId");
            DropColumn("dbo.Projects", "OtherCharges");
            DropColumn("dbo.Projects", "TowerPaintAndMaintenanceCharges");
            DropColumn("dbo.Projects", "EquipmentInstallationCharges");
            DropColumn("dbo.Projects", "VisitCharges");
        }
    }
}
