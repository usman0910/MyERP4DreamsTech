namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreTablesAdded4 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Employees", "BirthDate", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Employees", "BirthDate");
        }
    }
}
