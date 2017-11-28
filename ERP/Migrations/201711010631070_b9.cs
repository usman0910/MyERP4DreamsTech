namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b9 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ServiceAndSuppliesFirstTimes", "StockCableOutId", c => c.Int(nullable: false));
            AddColumn("dbo.ServiceAndSuppliesFirstTimes", "StockEquipmentOutId", c => c.Int(nullable: false));
            CreateIndex("dbo.ServiceAndSuppliesFirstTimes", "StockCableOutId");
            CreateIndex("dbo.ServiceAndSuppliesFirstTimes", "StockEquipmentOutId");
            AddForeignKey("dbo.ServiceAndSuppliesFirstTimes", "StockCableOutId", "dbo.StockCableOuts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ServiceAndSuppliesFirstTimes", "StockEquipmentOutId", "dbo.StockEquipmentOuts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ServiceAndSuppliesFirstTimes", "StockEquipmentOutId", "dbo.StockEquipmentOuts");
            DropForeignKey("dbo.ServiceAndSuppliesFirstTimes", "StockCableOutId", "dbo.StockCableOuts");
            DropIndex("dbo.ServiceAndSuppliesFirstTimes", new[] { "StockEquipmentOutId" });
            DropIndex("dbo.ServiceAndSuppliesFirstTimes", new[] { "StockCableOutId" });
            DropColumn("dbo.ServiceAndSuppliesFirstTimes", "StockEquipmentOutId");
            DropColumn("dbo.ServiceAndSuppliesFirstTimes", "StockCableOutId");
        }
    }
}
