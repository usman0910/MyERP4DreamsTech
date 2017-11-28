namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class m2 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.BillingStatus", "Status", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.BillingStatus", "Status", c => c.Int(nullable: false));
        }
    }
}
