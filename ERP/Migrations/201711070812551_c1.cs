namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.VehicleRecords", "VehicleStatusId");
            DropTable("dbo.VehicleStatus");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.VehicleStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("dbo.VehicleRecords", "VehicleStatusId", c => c.Int(nullable: false));
        }
    }
}
