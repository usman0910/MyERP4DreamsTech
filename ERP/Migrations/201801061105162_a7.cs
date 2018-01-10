namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a7 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.BillingMonthlies", "Editable", c => c.Boolean(nullable: true));
            AddColumn("dbo.BillingQuaterlies", "Editable", c => c.Boolean(nullable: true));
            AddColumn("dbo.BillingYearlies", "Editable", c => c.Boolean(nullable: true));
        }
        
        public override void Down()
        {
            DropColumn("dbo.BillingYearlies", "Editable");
            DropColumn("dbo.BillingQuaterlies", "Editable");
            DropColumn("dbo.BillingMonthlies", "Editable");
        }
    }
}
