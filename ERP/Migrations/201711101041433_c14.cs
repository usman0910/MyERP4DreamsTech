namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c14 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectSupplies", "StockCableOutId", "dbo.StockCableOuts");
            DropForeignKey("dbo.ProjectSupplies", "StockEquipmentOutId", "dbo.StockEquipmentOuts");
            DropIndex("dbo.ProjectSupplies", new[] { "StockCableOutId" });
            DropIndex("dbo.ProjectSupplies", new[] { "StockEquipmentOutId" });
            DropTable("dbo.ProjectSupplies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ProjectSupplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockCableOutId = c.Int(nullable: false),
                        StockEquipmentOutId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.ProjectSupplies", "StockEquipmentOutId");
            CreateIndex("dbo.ProjectSupplies", "StockCableOutId");
            AddForeignKey("dbo.ProjectSupplies", "StockEquipmentOutId", "dbo.StockEquipmentOuts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.ProjectSupplies", "StockCableOutId", "dbo.StockCableOuts", "Id", cascadeDelete: true);
        }
    }
}
