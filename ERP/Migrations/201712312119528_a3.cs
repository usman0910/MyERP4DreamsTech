namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BillingQuaterlies", "QuaterlyAmount", c => c.Long(nullable: false));
            AddColumn("dbo.BillingQuaterlies", "Arrears", c => c.Long(nullable: false));
            AddColumn("dbo.BillingQuaterlies", "TotalAmountToPay", c => c.Long(nullable: false));
            AddColumn("dbo.BillingQuaterlies", "AmountPaid", c => c.Long(nullable: false));
            AddColumn("dbo.BillingQuaterlies", "RemainingArrears", c => c.Long(nullable: false));
            AddColumn("dbo.BillingYearlies", "YearlyAmount", c => c.Long(nullable: false));
            AddColumn("dbo.BillingYearlies", "Arrears", c => c.Long(nullable: false));
            AddColumn("dbo.BillingYearlies", "TotalAmountToPay", c => c.Long(nullable: false));
            AddColumn("dbo.BillingYearlies", "AmountPaid", c => c.Long(nullable: false));
            AddColumn("dbo.BillingYearlies", "RemainingArrears", c => c.Long(nullable: false));
            DropColumn("dbo.BillingOneTimes", "AmountToPay");
            DropColumn("dbo.BillingOneTimes", "AmountPaid");
        }
        
        public override void Down()
        {
            AddColumn("dbo.BillingOneTimes", "AmountPaid", c => c.Long(nullable: false));
            AddColumn("dbo.BillingOneTimes", "AmountToPay", c => c.Long(nullable: false));
            DropColumn("dbo.BillingYearlies", "RemainingArrears");
            DropColumn("dbo.BillingYearlies", "AmountPaid");
            DropColumn("dbo.BillingYearlies", "TotalAmountToPay");
            DropColumn("dbo.BillingYearlies", "Arrears");
            DropColumn("dbo.BillingYearlies", "YearlyAmount");
            DropColumn("dbo.BillingQuaterlies", "RemainingArrears");
            DropColumn("dbo.BillingQuaterlies", "AmountPaid");
            DropColumn("dbo.BillingQuaterlies", "TotalAmountToPay");
            DropColumn("dbo.BillingQuaterlies", "Arrears");
            DropColumn("dbo.BillingQuaterlies", "QuaterlyAmount");
        }
    }
}
