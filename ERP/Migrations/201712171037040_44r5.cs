namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _44r5 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.FuelExpenses", "Detail", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.FuelExpenses", "Detail");
        }
    }
}
