namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DesignationUpdate : DbMigration
    {
        public override void Up()
        {
            CreateIndex("dbo.Employees", "DesignationId");
            AddForeignKey("dbo.Employees", "DesignationId", "dbo.Designations", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropIndex("dbo.Employees", new[] { "DesignationId" });
        }
    }
}
