namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectServices", "IsFirstTime", c => c.Boolean(nullable: false));
            AddColumn("dbo.ProjectSupplies", "IsFirstTime", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectSupplies", "IsFirstTime");
            DropColumn("dbo.ProjectServices", "IsFirstTime");
        }
    }
}
