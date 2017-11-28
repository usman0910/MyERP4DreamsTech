namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b25 : DbMigration
    {
        public override void Up()
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
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TotalStocks");
        }
    }
}
