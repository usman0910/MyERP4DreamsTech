namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BillingOneTimes", "OneTimeAmount", c => c.Long(nullable: false));
            AddColumn("dbo.BillingOneTimes", "AmountPaid", c => c.Long(nullable: false));
            AddColumn("dbo.BillingOneTimes", "RemainingArrears", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BillingOneTimes", "RemainingArrears");
            DropColumn("dbo.BillingOneTimes", "AmountPaid");
            DropColumn("dbo.BillingOneTimes", "OneTimeAmount");
        }
    }
}
