namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b3 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectServices", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProjectSupplies", "Date", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectSupplies", "Date");
            DropColumn("dbo.ProjectServices", "Date");
        }
    }
}
