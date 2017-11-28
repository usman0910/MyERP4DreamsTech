namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c16 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectServices", "Date", c => c.DateTime(nullable: true));
            AddColumn("dbo.StockCableOuts", "Date", c => c.DateTime(nullable: true));
            AddColumn("dbo.StockEquipmentOuts", "Date", c => c.DateTime(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.StockEquipmentOuts", "Date");
            DropColumn("dbo.StockCableOuts", "Date");
            DropColumn("dbo.ProjectServices", "Date");
        }
    }
}
