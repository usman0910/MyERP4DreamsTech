namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.StockCables", newName: "StockCableOuts");
            RenameTable(name: "dbo.StockEquipments", newName: "StockEquipmentOuts");
            CreateTable(
                "dbo.ProjectServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VisitCharges = c.Int(nullable: false),
                        EquipmentRepairCharges = c.Int(nullable: false),
                        EquipmentReplacementCharges = c.Int(nullable: false),
                        TowerPaintAndMaintenanceCharges = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectSupplies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        StockCableOutId = c.Int(nullable: false),
                        StockEquipmentOutId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.StockCableOuts", t => t.StockCableOutId, cascadeDelete: true)
                .ForeignKey("dbo.StockEquipmentOuts", t => t.StockEquipmentOutId, cascadeDelete: true)
                .Index(t => t.StockCableOutId)
                .Index(t => t.StockEquipmentOutId);
            
            CreateTable(
                "dbo.StockCableIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CableRollId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.CableRollId);
            
            CreateTable(
                "dbo.StockEquipmentIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipmentId = c.Int(nullable: false),
                        EquipmentTypeId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.EquipmentId)
                .Index(t => t.EquipmentTypeId);
            
            AddColumn("dbo.Projects", "ProjectServiceId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "EmployeeId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "ProjectSuppliesId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "ProjectServiceId");
            CreateIndex("dbo.Projects", "EmployeeId");
            CreateIndex("dbo.Projects", "ProjectSuppliesId");
            AddForeignKey("dbo.Projects", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "ProjectServiceId", "dbo.ProjectServices", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Projects", "ProjectSuppliesId", "dbo.ProjectSupplies", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Projects", "ProjectSuppliesId", "dbo.ProjectSupplies");
            DropForeignKey("dbo.ProjectSupplies", "StockEquipmentOutId", "dbo.StockEquipmentOuts");
            DropForeignKey("dbo.ProjectSupplies", "StockCableOutId", "dbo.StockCableOuts");
            DropForeignKey("dbo.Projects", "ProjectServiceId", "dbo.ProjectServices");
            DropForeignKey("dbo.Projects", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.StockEquipmentIns", new[] { "EquipmentTypeId" });
            DropIndex("dbo.StockEquipmentIns", new[] { "EquipmentId" });
            DropIndex("dbo.StockCableIns", new[] { "CableRollId" });
            DropIndex("dbo.ProjectSupplies", new[] { "StockEquipmentOutId" });
            DropIndex("dbo.ProjectSupplies", new[] { "StockCableOutId" });
            DropIndex("dbo.Projects", new[] { "ProjectSuppliesId" });
            DropIndex("dbo.Projects", new[] { "EmployeeId" });
            DropIndex("dbo.Projects", new[] { "ProjectServiceId" });
            DropColumn("dbo.Projects", "ProjectSuppliesId");
            DropColumn("dbo.Projects", "EmployeeId");
            DropColumn("dbo.Projects", "ProjectServiceId");
            DropTable("dbo.StockEquipmentIns");
            DropTable("dbo.StockCableIns");
            DropTable("dbo.ProjectSupplies");
            DropTable("dbo.ProjectServices");
            RenameTable(name: "dbo.StockEquipmentOuts", newName: "StockEquipments");
            RenameTable(name: "dbo.StockCableOuts", newName: "StockCables");
        }
    }
}
