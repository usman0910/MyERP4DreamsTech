namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialDtaEntered : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        CNIC = c.String(),
                        DesignationId = c.Int(nullable: false),
                        BasicSalary = c.Double(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                        City = c.String(),
                        PermanentAddress = c.String(),
                        ContactNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Months",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Month = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Year = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Years");
            DropTable("dbo.Months");
            DropTable("dbo.Employees");
            DropTable("dbo.Designations");
        }
    }
}
