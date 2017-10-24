namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MoreTablesAdded5 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Customers", newName: "SpokePersons");
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyContactNumber = c.String(),
                        CompanyEmail = c.String(),
                        SpokePersonId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.SpokePersons", t => t.SpokePersonId, cascadeDelete: true)
                .Index(t => t.SpokePersonId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clients", "SpokePersonId", "dbo.SpokePersons");
            DropIndex("dbo.Clients", new[] { "SpokePersonId" });
            DropTable("dbo.Clients");
            RenameTable(name: "dbo.SpokePersons", newName: "Customers");
        }
    }
}
