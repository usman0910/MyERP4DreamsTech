namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b20 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "ClientId", "dbo.Clients");
            DropForeignKey("dbo.Projects", "ProjectComissionId", "dbo.ProjectComissions");
            DropForeignKey("dbo.Projects", "StockCableOutId", "dbo.StockCableOuts");
            DropForeignKey("dbo.Projects", "StockEquipmentOutId", "dbo.StockEquipmentOuts");
            DropIndex("dbo.Projects", new[] { "ClientId" });
            DropIndex("dbo.Projects", new[] { "StockCableOutId" });
            DropIndex("dbo.Projects", new[] { "StockEquipmentOutId" });
            DropIndex("dbo.Projects", new[] { "ProjectComissionId" });
            RenameColumn(table: "dbo.Projects", name: "ClientId", newName: "Client_Id");
            RenameColumn(table: "dbo.Projects", name: "ProjectComissionId", newName: "ProjectComission_Id");
            RenameColumn(table: "dbo.Projects", name: "StockCableOutId", newName: "StockCableOut_Id");
            RenameColumn(table: "dbo.Projects", name: "StockEquipmentOutId", newName: "StockEquipmentOut_Id");
            AlterColumn("dbo.Projects", "Client_Id", c => c.Int());
            AlterColumn("dbo.Projects", "StockCableOut_Id", c => c.Int());
            AlterColumn("dbo.Projects", "StockEquipmentOut_Id", c => c.Int());
            AlterColumn("dbo.Projects", "ProjectComission_Id", c => c.Int());
            CreateIndex("dbo.Projects", "Client_Id");
            CreateIndex("dbo.Projects", "ProjectComission_Id");
            CreateIndex("dbo.Projects", "StockCableOut_Id");
            CreateIndex("dbo.Projects", "StockEquipmentOut_Id");
            AddForeignKey("dbo.Projects", "Client_Id", "dbo.Clients", "Id");
            AddForeignKey("dbo.Projects", "ProjectComission_Id", "dbo.ProjectComissions", "Id");
            AddForeignKey("dbo.Projects", "StockCableOut_Id", "dbo.StockCableOuts", "Id");
            AddForeignKey("dbo.Projects", "StockEquipmentOut_Id", "dbo.StockEquipmentOuts", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "StockEquipmentOut_Id", "dbo.StockEquipmentOuts");
            DropForeignKey("dbo.Projects", "StockCableOut_Id", "dbo.StockCableOuts");
            DropForeignKey("dbo.Projects", "ProjectComission_Id", "dbo.ProjectComissions");
            DropForeignKey("dbo.Projects", "Client_Id", "dbo.Clients");
            DropIndex("dbo.Projects", new[] { "StockEquipmentOut_Id" });
            DropIndex("dbo.Projects", new[] { "StockCableOut_Id" });
            DropIndex("dbo.Projects", new[] { "ProjectComission_Id" });
            DropIndex("dbo.Projects", new[] { "Client_Id" });
            AlterColumn("dbo.Projects", "ProjectComission_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Projects", "StockEquipmentOut_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Projects", "StockCableOut_Id", c => c.Int(nullable: false));
            AlterColumn("dbo.Projects", "Client_Id", c => c.Int(nullable: false));
            RenameColumn(table: "dbo.Projects", name: "StockEquipmentOut_Id", newName: "StockEquipmentOutId");
            RenameColumn(table: "dbo.Projects", name: "StockCableOut_Id", newName: "StockCableOutId");
            RenameColumn(table: "dbo.Projects", name: "ProjectComission_Id", newName: "ProjectComissionId");
            RenameColumn(table: "dbo.Projects", name: "Client_Id", newName: "ClientId");
            CreateIndex("dbo.Projects", "ProjectComissionId");
            CreateIndex("dbo.Projects", "StockEquipmentOutId");
            CreateIndex("dbo.Projects", "StockCableOutId");
            CreateIndex("dbo.Projects", "ClientId");
            AddForeignKey("dbo.Projects", "StockEquipmentOutId", "dbo.StockEquipmentOuts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "StockCableOutId", "dbo.StockCableOuts", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "ProjectComissionId", "dbo.ProjectComissions", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "ClientId", "dbo.Clients", "Id", cascadeDelete: true);
        }
    }
}
