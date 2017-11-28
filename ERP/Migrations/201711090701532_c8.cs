namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TestingProjectSupplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockCableOut_Id = c.Int(),
                        StockEquipmentOut_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StockCableOuts", t => t.StockCableOut_Id)
                .ForeignKey("dbo.StockEquipmentOuts", t => t.StockEquipmentOut_Id)
                .Index(t => t.StockCableOut_Id)
                .Index(t => t.StockEquipmentOut_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.TestingProjectSupplies", "StockEquipmentOut_Id", "dbo.StockEquipmentOuts");
            DropForeignKey("dbo.TestingProjectSupplies", "StockCableOut_Id", "dbo.StockCableOuts");
            DropIndex("dbo.TestingProjectSupplies", new[] { "StockEquipmentOut_Id" });
            DropIndex("dbo.TestingProjectSupplies", new[] { "StockCableOut_Id" });
            DropTable("dbo.TestingProjectSupplies");
        }
    }
}
