namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _44r6 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AdvanceSalaries", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AdvanceSalaries", "Status", c => c.Int(nullable: false));
        }
    }
}
