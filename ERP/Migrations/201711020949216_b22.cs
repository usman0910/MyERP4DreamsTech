namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b22 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "Client_Id", "dbo.Clients");
            DropForeignKey("dbo.Projects", "ProjectComission_Id", "dbo.ProjectComissions");
            DropForeignKey("dbo.Projects", "StockCableOut_Id", "dbo.StockCableOuts");
            DropForeignKey("dbo.Projects", "StockEquipmentOut_Id", "dbo.StockEquipmentOuts");
            DropIndex("dbo.Projects", new[] { "Client_Id" });
            DropIndex("dbo.Projects", new[] { "ProjectComission_Id" });
            DropIndex("dbo.Projects", new[] { "StockCableOut_Id" });
            DropIndex("dbo.Projects", new[] { "StockEquipmentOut_Id" });
            DropColumn("dbo.Projects", "Client_Id");
            DropColumn("dbo.Projects", "ProjectComission_Id");
            DropColumn("dbo.Projects", "StockCableOut_Id");
            DropColumn("dbo.Projects", "StockEquipmentOut_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "StockEquipmentOut_Id", c => c.Int());
            AddColumn("dbo.Projects", "StockCableOut_Id", c => c.Int());
            AddColumn("dbo.Projects", "ProjectComission_Id", c => c.Int());
            AddColumn("dbo.Projects", "Client_Id", c => c.Int());
            CreateIndex("dbo.Projects", "StockEquipmentOut_Id");
            CreateIndex("dbo.Projects", "StockCableOut_Id");
            CreateIndex("dbo.Projects", "ProjectComission_Id");
            CreateIndex("dbo.Projects", "Client_Id");
            AddForeignKey("dbo.Projects", "StockEquipmentOut_Id", "dbo.StockEquipmentOuts", "Id");
            AddForeignKey("dbo.Projects", "StockCableOut_Id", "dbo.StockCableOuts", "Id");
            AddForeignKey("dbo.Projects", "ProjectComission_Id", "dbo.ProjectComissions", "Id");
            AddForeignKey("dbo.Projects", "Client_Id", "dbo.Clients", "Id");
        }
    }
}
