namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class TablesAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AssignVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        VehicleRecordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleRecords", t => t.VehicleRecordId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.VehicleRecordId);
            
            CreateTable(
                "dbo.VehicleRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleTypeId = c.Int(nullable: false),
                        RegistrationNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId, cascadeDelete: true)
                .Index(t => t.VehicleTypeId);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AssignVehicles", "VehicleRecordId", "dbo.VehicleRecords");
            DropForeignKey("dbo.VehicleRecords", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.AssignVehicles", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.VehicleRecords", new[] { "VehicleTypeId" });
            DropIndex("dbo.AssignVehicles", new[] { "VehicleRecordId" });
            DropIndex("dbo.AssignVehicles", new[] { "EmployeeId" });
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.VehicleRecords");
            DropTable("dbo.AssignVehicles");
        }
    }
}
