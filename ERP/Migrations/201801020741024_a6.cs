namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MonthlySalaries", "BasicSalary", c => c.Long(nullable: false));
            AddColumn("dbo.MonthlySalaries", "TotalComission", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MonthlySalaries", "TotalComission");
            DropColumn("dbo.MonthlySalaries", "BasicSalary");
        }
    }
}
