namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class c18 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.ProjectServices", "SignalStrength");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectServices", "SignalStrength", c => c.Int(nullable: false));
        }
    }
}
