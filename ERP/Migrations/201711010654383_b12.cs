namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class b12 : DbMigration
    {
        public override void Up()
        {
            DropTable("dbo.ServiceAndSuppliesFirstTimes");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ServiceAndSuppliesFirstTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
        }
    }
}
