namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b6 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AddToProjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            DropColumn("dbo.ProjectServices", "Date");
            DropColumn("dbo.ProjectSupplies", "Date");
        }
        
        public override void Down()
        {
            AddColumn("dbo.ProjectSupplies", "Date", c => c.DateTime(nullable: false));
            AddColumn("dbo.ProjectServices", "Date", c => c.DateTime(nullable: false));
            DropTable("dbo.AddToProjects");
        }
    }
}
