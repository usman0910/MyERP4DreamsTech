namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreTablesAdded2 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CableRolls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        FeetMeasurement = c.Int(nullable: false),
                        OtherInfo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Brand = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EquipmentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.StockCables",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CableRollId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CableRolls", t => t.CableRollId, cascadeDelete: true)
                .Index(t => t.CableRollId);
            
            CreateTable(
                "dbo.StockEquipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipmentId = c.Int(nullable: false),
                        EquipmentTypeId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        UnitPrice = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .ForeignKey("dbo.EquipmentTypes", t => t.EquipmentTypeId, cascadeDelete: true)
                .Index(t => t.EquipmentId)
                .Index(t => t.EquipmentTypeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.StockEquipments", "EquipmentTypeId", "dbo.EquipmentTypes");
            DropForeignKey("dbo.StockEquipments", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.StockCables", "CableRollId", "dbo.CableRolls");
            DropIndex("dbo.StockEquipments", new[] { "EquipmentTypeId" });
            DropIndex("dbo.StockEquipments", new[] { "EquipmentId" });
            DropIndex("dbo.StockCables", new[] { "CableRollId" });
            DropTable("dbo.StockEquipments");
            DropTable("dbo.StockCables");
            DropTable("dbo.EquipmentTypes");
            DropTable("dbo.Equipments");
            DropTable("dbo.CableRolls");
        }
    }
}
