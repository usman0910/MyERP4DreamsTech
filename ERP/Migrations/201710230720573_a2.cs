namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Projects", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.Projects", new[] { "EmployeeId" });
            DropColumn("dbo.Projects", "EmployeeId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "EmployeeId", c => c.Int(nullable: false));
            CreateIndex("dbo.Projects", "EmployeeId");
            AddForeignKey("dbo.Projects", "EmployeeId", "dbo.Employees", "Id", cascadeDelete: true);
        }
    }
}
