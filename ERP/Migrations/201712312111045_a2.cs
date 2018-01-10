namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.BillingQuaterlies", "AmountToPay");
            DropColumn("dbo.BillingQuaterlies", "AmountPaid");
            DropColumn("dbo.BillingYearlies", "AmountToPay");
            DropColumn("dbo.BillingYearlies", "AmountPaid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BillingYearlies", "AmountPaid", c => c.Long(nullable: false));
            AddColumn("dbo.BillingYearlies", "AmountToPay", c => c.Long(nullable: false));
            AddColumn("dbo.BillingQuaterlies", "AmountPaid", c => c.Long(nullable: false));
            AddColumn("dbo.BillingQuaterlies", "AmountToPay", c => c.Long(nullable: false));
        }
    }
}
