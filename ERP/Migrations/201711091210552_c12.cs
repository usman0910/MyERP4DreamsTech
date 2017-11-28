namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c12 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectSupplies", "StockCableOut_Id", "dbo.StockCableOuts");
            DropIndex("dbo.ProjectSupplies", new[] { "StockCableOut_Id" });
            RenameColumn(table: "dbo.ProjectSupplies", name: "StockCableOut_Id", newName: "StockCableOutId");
            AlterColumn("dbo.ProjectSupplies", "StockCableOutId", c => c.Int(nullable: false));
            CreateIndex("dbo.ProjectSupplies", "StockCableOutId");
            AddForeignKey("dbo.ProjectSupplies", "StockCableOutId", "dbo.StockCableOuts", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectSupplies", "StockCableOutId", "dbo.StockCableOuts");
            DropIndex("dbo.ProjectSupplies", new[] { "StockCableOutId" });
            AlterColumn("dbo.ProjectSupplies", "StockCableOutId", c => c.Int());
            RenameColumn(table: "dbo.ProjectSupplies", name: "StockCableOutId", newName: "StockCableOut_Id");
            CreateIndex("dbo.ProjectSupplies", "StockCableOut_Id");
            AddForeignKey("dbo.ProjectSupplies", "StockCableOut_Id", "dbo.StockCableOuts", "Id");
        }
    }
}
