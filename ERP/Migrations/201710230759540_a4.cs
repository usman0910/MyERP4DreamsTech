namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a4 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProjectComissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        Year = c.DateTime(nullable: false),
                        Month = c.DateTime(nullable: false),
                        ComissionAmount = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ProjectComissions", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectComissions", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.ProjectComissions", new[] { "EmployeeId" });
            DropIndex("dbo.ProjectComissions", new[] { "ProjectId" });
            DropTable("dbo.ProjectComissions");
        }
    }
}
