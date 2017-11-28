namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c3 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.SalaryStatus", "Status", c => c.String());
            CreateIndex("dbo.VehicleRecords", "VehicleStatusId");
            AddForeignKey("dbo.VehicleRecords", "VehicleStatusId", "dbo.VehicleStatus", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.VehicleRecords", "VehicleStatusId", "dbo.VehicleStatus");
            DropIndex("dbo.VehicleRecords", new[] { "VehicleStatusId" });
            AlterColumn("dbo.SalaryStatus", "Status", c => c.Int(nullable: false));
        }
    }
}
