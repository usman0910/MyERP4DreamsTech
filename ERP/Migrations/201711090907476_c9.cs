namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.TestingProjectSupplies", "StockCableOut_Id", "dbo.StockCableOuts");
            DropForeignKey("dbo.TestingProjectSupplies", "StockEquipmentOut_Id", "dbo.StockEquipmentOuts");
            DropIndex("dbo.TestingProjectSupplies", new[] { "StockCableOut_Id" });
            DropIndex("dbo.TestingProjectSupplies", new[] { "StockEquipmentOut_Id" });
            DropTable("dbo.TestingProjectSupplies");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TestingProjectSupplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockCableOut_Id = c.Int(),
                        StockEquipmentOut_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateIndex("dbo.TestingProjectSupplies", "StockEquipmentOut_Id");
            CreateIndex("dbo.TestingProjectSupplies", "StockCableOut_Id");
            AddForeignKey("dbo.TestingProjectSupplies", "StockEquipmentOut_Id", "dbo.StockEquipmentOuts", "Id");
            AddForeignKey("dbo.TestingProjectSupplies", "StockCableOut_Id", "dbo.StockCableOuts", "Id");
        }
    }
}
