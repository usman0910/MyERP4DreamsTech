namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _44r4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "TotalComission", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "TotalComission");
        }
    }
}
