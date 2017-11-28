namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b14 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.SpokePersons");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SpokePersons",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        ContactNumber = c.String(),
                        Email = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
