namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b15 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectComissions", "Date", c => c.DateTime(nullable: false));
            DropColumn("dbo.ProjectComissions", "Year");
            DropColumn("dbo.ProjectComissions", "Month");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectComissions", "Month", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProjectComissions", "Year", c => c.DateTime(nullable: false));
            DropColumn("dbo.ProjectComissions", "Date");
        }
    }
}
