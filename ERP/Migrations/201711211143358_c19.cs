namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c19 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectServices", "SignalStrength", c => c.Single(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectServices", "SignalStrength");
        }
    }
}
