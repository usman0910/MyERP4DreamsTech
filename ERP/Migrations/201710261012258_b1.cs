namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b1 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Projects", "ProjectServiceId");
            DropColumn("dbo.Projects", "ProjectSuppliesId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Projects", "ProjectSuppliesId", c => c.Int(nullable: false));
            AddColumn("dbo.Projects", "ProjectServiceId", c => c.Int(nullable: false));
        }
    }
}
