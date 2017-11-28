namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b13 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clients", "SpokePersonId", "dbo.SpokePersons");
            DropIndex("dbo.Clients", new[] { "SpokePersonId" });
            AddColumn("dbo.Projects", "SpokePersonName", c => c.String());
            AddColumn("dbo.Projects", "SpokePersonContactNumber", c => c.String());
            DropColumn("dbo.Clients", "SpokePersonId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Clients", "SpokePersonId", c => c.Int(nullable: false));
            DropColumn("dbo.Projects", "SpokePersonContactNumber");
            DropColumn("dbo.Projects", "SpokePersonName");
            CreateIndex("dbo.Clients", "SpokePersonId");
            AddForeignKey("dbo.Clients", "SpokePersonId", "dbo.SpokePersons", "Id", cascadeDelete: true);
        }
    }
}
