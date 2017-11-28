namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c10 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ProjectSupplies", "StockCableOutId", "dbo.StockCableOuts");
            DropIndex("dbo.ProjectSupplies", new[] { "StockCableOutId" });
            RenameColumn(table: "dbo.ProjectSupplies", name: "StockCableOutId", newName: "StockCableOut_Id");
            AlterColumn("dbo.ProjectSupplies", "StockCableOut_Id", c => c.Int());
            CreateIndex("dbo.ProjectSupplies", "StockCableOut_Id");
            AddForeignKey("dbo.ProjectSupplies", "StockCableOut_Id", "dbo.StockCableOuts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectSupplies", "StockCableOut_Id", "dbo.StockCableOuts");
            DropIndex("dbo.ProjectSupplies", new[] { "StockCableOut_Id" });
            AlterColumn("dbo.ProjectSupplies", "StockCableOut_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.ProjectSupplies", name: "StockCableOut_Id", newName: "StockCableOutId");
            CreateIndex("dbo.ProjectSupplies", "StockCableOutId");
            AddForeignKey("dbo.ProjectSupplies", "StockCableOutId", "dbo.StockCableOuts", "Id", cascadeDelete: true);
        }
    }
}
