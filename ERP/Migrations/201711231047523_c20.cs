namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "BillingAmount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "BillingAmount");
        }
    }
}
