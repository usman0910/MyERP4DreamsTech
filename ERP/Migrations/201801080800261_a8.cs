namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a8 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.StockCableOuts", "ForComplaintManagement", c => c.Boolean(nullable: true));
            AddColumn("dbo.StockEquipmentOuts", "ForComplaintManagement", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockEquipmentOuts", "ForComplaintManagement");
            DropColumn("dbo.StockCableOuts", "ForComplaintManagement");
        }
    }
}
