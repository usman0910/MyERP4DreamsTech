namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectServices", "ProjectId", c => c.Int(nullable: false));
            AddColumn("dbo.ProjectServices", "IsFirstTime", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProjectServices", "EquipmentInstallationCharges", c => c.Int(nullable: false));
            AddColumn("dbo.ProjectServices", "OtherCharges", c => c.Int(nullable: false));
            AddColumn("dbo.StockCableOuts", "IsFirstTime", c => c.Boolean(nullable: false));
            AddColumn("dbo.StockEquipmentOuts", "IsFirstTime", c => c.Boolean(nullable: false));
            CreateIndex("dbo.ProjectServices", "ProjectId");
            AddForeignKey("dbo.ProjectServices", "ProjectId", "dbo.Projects", "Id", cascadeDelete: true);
            DropColumn("dbo.Projects", "VisitCharges");
            DropColumn("dbo.Projects", "EquipmentInstallationCharges");
            DropColumn("dbo.Projects", "TowerPaintAndMaintenanceCharges");
            DropColumn("dbo.Projects", "OtherCharges");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "OtherCharges", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "TowerPaintAndMaintenanceCharges", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "EquipmentInstallationCharges", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "VisitCharges", c => c.Int(nullable: false));
            DropForeignKey("dbo.ProjectServices", "ProjectId", "dbo.Projects");
            DropIndex("dbo.ProjectServices", new[] { "ProjectId" });
            DropColumn("dbo.StockEquipmentOuts", "IsFirstTime");
            DropColumn("dbo.StockCableOuts", "IsFirstTime");
            DropColumn("dbo.ProjectServices", "OtherCharges");
            DropColumn("dbo.ProjectServices", "EquipmentInstallationCharges");
            DropColumn("dbo.ProjectServices", "IsFirstTime");
            DropColumn("dbo.ProjectServices", "ProjectId");
        }
    }
}
