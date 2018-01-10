namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.ProjectComissions", "ComissionAmount", c => c.Long(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.ProjectComissions", "ComissionAmount");
        }
    }
}
