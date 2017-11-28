namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b26 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CableRolls", "StockAvailable", c => c.Int(nullable: false));
            AddColumn("dbo.Equipments", "StockAvailable", c => c.Int(nullable: false));
            DropTable("dbo.TotalStocks");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.TotalStocks",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TotalEuqipmentsQuantity = c.Int(nullable: false),
                        TotalCableFeets = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.Equipments", "StockAvailable");
            DropColumn("dbo.CableRolls", "StockAvailable");
        }
    }
}
