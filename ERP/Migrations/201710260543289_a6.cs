namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a6 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Projects", "Name", c => c.String());
            AddColumn("dbo.Projects", "WorkingLocation", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Projects", "WorkingLocation");
            DropColumn("dbo.Projects", "Name");
        }
    }
}
