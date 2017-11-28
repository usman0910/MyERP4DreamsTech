namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ServiceAndSuppliesFirstTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VisitCharges = c.Int(nullable: false),
                        EquipmentInstallationCharges = c.Int(nullable: false),
                        TowerPaintAndMaintenanceCharges = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ServiceAndSuppliesFirstTimes");
        }
    }
}
