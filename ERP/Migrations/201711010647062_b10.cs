namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ServiceAndSuppliesFirstTimes", "StockCableOutId", "dbo.StockCableOuts");
            DropForeignKey("dbo.ServiceAndSuppliesFirstTimes", "StockEquipmentOutId", "dbo.StockEquipmentOuts");
            DropIndex("dbo.ServiceAndSuppliesFirstTimes", new[] { "StockCableOutId" });
            DropIndex("dbo.ServiceAndSuppliesFirstTimes", new[] { "StockEquipmentOutId" });
            DropColumn("dbo.ServiceAndSuppliesFirstTimes", "VisitCharges");
            DropColumn("dbo.ServiceAndSuppliesFirstTimes", "EquipmentInstallationCharges");
            DropColumn("dbo.ServiceAndSuppliesFirstTimes", "TowerPaintAndMaintenanceCharges");
            DropColumn("dbo.ServiceAndSuppliesFirstTimes", "StockCableOutId");
            DropColumn("dbo.ServiceAndSuppliesFirstTimes", "StockEquipmentOutId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ServiceAndSuppliesFirstTimes", "StockEquipmentOutId", c => c.Int(nullable: false));
            AddColumn("dbo.ServiceAndSuppliesFirstTimes", "StockCableOutId", c => c.Int(nullable: false));
            AddColumn("dbo.ServiceAndSuppliesFirstTimes", "TowerPaintAndMaintenanceCharges", c => c.Int(nullable: false));
            AddColumn("dbo.ServiceAndSuppliesFirstTimes", "EquipmentInstallationCharges", c => c.Int(nullable: false));
            AddColumn("dbo.ServiceAndSuppliesFirstTimes", "VisitCharges", c => c.Int(nullable: false));
            CreateIndex("dbo.ServiceAndSuppliesFirstTimes", "StockEquipmentOutId");
            CreateIndex("dbo.ServiceAndSuppliesFirstTimes", "StockCableOutId");
            AddForeignKey("dbo.ServiceAndSuppliesFirstTimes", "StockEquipmentOutId", "dbo.StockEquipmentOuts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ServiceAndSuppliesFirstTimes", "StockCableOutId", "dbo.StockCableOuts", "Id", cascadeDelete: true);
        }
    }
}
