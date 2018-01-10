namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class a9 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ComplaintManagements",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        ComplaintDate = c.DateTime(nullable: false),
                        ComplaintEntertainedDate = c.DateTime(nullable: false),
                        EmployeeId = c.Int(nullable: false),
                        SignalStrengthBefore = c.Int(nullable: false),
                        SignalStrengthAfter = c.Int(nullable: false),
                        IssueDetails = c.String(),
                        IssueResolvedDetails = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId)
                .Index(t => t.EmployeeId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ComplaintManagements", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ComplaintManagements", "EmployeeId", "dbo.Employees");
            DropIndex("dbo.ComplaintManagements", new[] { "EmployeeId" });
            DropIndex("dbo.ComplaintManagements", new[] { "ProjectId" });
            DropTable("dbo.ComplaintManagements");
        }
    }
}
