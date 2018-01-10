namespace ERP.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AdvanceSalaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        GivenDate = c.DateTime(nullable: false),
                        AdvanceAmount = c.Int(nullable: false),
                        Reason = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FullName = c.String(),
                        CNIC = c.String(),
                        DesignationId = c.Int(nullable: false),
                        BasicSalary = c.Double(nullable: false),
                        BirthDate = c.DateTime(nullable: false),
                        JoiningDate = c.DateTime(nullable: false),
                        City = c.String(),
                        PermanentAddress = c.String(),
                        ContactNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Designations", t => t.DesignationId, cascadeDelete: true)
                .Index(t => t.DesignationId);
            
            CreateTable(
                "dbo.Designations",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AssignVehicles",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        VehicleRecordId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleRecords", t => t.VehicleRecordId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.VehicleRecordId);
            
            CreateTable(
                "dbo.VehicleRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VehicleTypeId = c.Int(nullable: false),
                        VehicleStatusId = c.Int(nullable: false),
                        RegistrationNumber = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.VehicleStatus", t => t.VehicleStatusId, cascadeDelete: true)
                .ForeignKey("dbo.VehicleTypes", t => t.VehicleTypeId, cascadeDelete: true)
                .Index(t => t.VehicleTypeId)
                .Index(t => t.VehicleStatusId);
            
            CreateTable(
                "dbo.VehicleStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.VehicleTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BillingMonthlies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        MonthlyAmount = c.Long(nullable: false),
                        Arrears = c.Long(nullable: false),
                        TotalAmountToPay = c.Long(nullable: false),
                        AmountPaid = c.Long(nullable: false),
                        RemainingArrears = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Projects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        WorkingLocationA = c.String(),
                        StartingDate = c.DateTime(nullable: false),
                        SpokePersonName = c.String(),
                        WorkingLocationB = c.String(),
                        BillingAmount = c.Long(nullable: false),
                        Arrears = c.Long(nullable: false),
                        ComissionPercentage = c.Byte(nullable: false),
                        SpokePersonContactNumber = c.String(),
                        ProjectBillingTypeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ProjectBillingTypes", t => t.ProjectBillingTypeId, cascadeDelete: true)
                .Index(t => t.ProjectBillingTypeId);
            
            CreateTable(
                "dbo.ProjectBillingTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BillingOneTimes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        AmountToPay = c.Long(nullable: false),
                        AmountPaid = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.BillingQuaterlies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        AmountToPay = c.Long(nullable: false),
                        AmountPaid = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.BillingStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BillingYearlies",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ProjectId = c.Int(nullable: false),
                        From = c.DateTime(nullable: false),
                        To = c.DateTime(nullable: false),
                        AmountToPay = c.Long(nullable: false),
                        AmountPaid = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.CableRolls",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Brand = c.String(),
                        StockAvailable = c.Int(nullable: false),
                        FeetPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CompanyName = c.String(),
                        CompanyContactNumber = c.String(),
                        CompanyEmail = c.String(),
                        OfficeLocation = c.String(),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.Equipments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Brand = c.String(),
                        StockAvailable = c.Int(nullable: false),
                        UnitPrice = c.Single(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.EquipmentTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.FuelExpenses",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        FuelPrice = c.Int(nullable: false),
                        Detail = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .Index(t => t.EmployeeId);
            
            CreateTable(
                "dbo.MonthlySalaries",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Month = c.String(),
                        Year = c.String(),
                        TotalMonthSalary = c.Double(nullable: false),
                        Advance = c.Int(nullable: false),
                        FuelExpence = c.Int(nullable: false),
                        SalaryStatusId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.SalaryStatus", t => t.SalaryStatusId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.SalaryStatusId);
            
            CreateTable(
                "dbo.SalaryStatus",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Status = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Months",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        Month = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProjectComissions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EmployeeId = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                        ProjectId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Employees", t => t.EmployeeId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.EmployeeId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.ProjectServices",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        VisitCharges = c.Int(nullable: false),
                        EquipmentRepairCharges = c.Int(nullable: false),
                        EquipmentReplacementCharges = c.Int(nullable: false),
                        TowerPaintAndMaintenanceCharges = c.Int(nullable: false),
                        SignalStrength = c.Single(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        IsFirstTime = c.Boolean(nullable: false),
                        EquipmentInstallationCharges = c.Int(nullable: false),
                        OtherCharges = c.Int(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.StockCableOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CableRollId = c.Int(nullable: false),
                        Totalfeets = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        IsFirstTime = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CableRolls", t => t.CableRollId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.CableRollId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.StockCableIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        CableRollId = c.Int(nullable: false),
                        Totalfeets = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CableRolls", t => t.CableRollId, cascadeDelete: true)
                .Index(t => t.CableRollId);
            
            CreateTable(
                "dbo.StockEquipmentOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipmentId = c.Int(nullable: false),
                        EquipmentTypeId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                        ProjectId = c.Int(nullable: false),
                        IsFirstTime = c.Boolean(nullable: false),
                        Date = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .ForeignKey("dbo.EquipmentTypes", t => t.EquipmentTypeId, cascadeDelete: true)
                .ForeignKey("dbo.Projects", t => t.ProjectId, cascadeDelete: true)
                .Index(t => t.EquipmentId)
                .Index(t => t.EquipmentTypeId)
                .Index(t => t.ProjectId);
            
            CreateTable(
                "dbo.StockEquipmentIns",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        EquipmentId = c.Int(nullable: false),
                        EquipmentTypeId = c.Int(nullable: false),
                        Quantity = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Equipments", t => t.EquipmentId, cascadeDelete: true)
                .ForeignKey("dbo.EquipmentTypes", t => t.EquipmentTypeId, cascadeDelete: true)
                .Index(t => t.EquipmentId)
                .Index(t => t.EquipmentTypeId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Years",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: false),
                        Year = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.StockEquipmentIns", "EquipmentTypeId", "dbo.EquipmentTypes");
            DropForeignKey("dbo.StockEquipmentIns", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.StockEquipmentOuts", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.StockEquipmentOuts", "EquipmentTypeId", "dbo.EquipmentTypes");
            DropForeignKey("dbo.StockEquipmentOuts", "EquipmentId", "dbo.Equipments");
            DropForeignKey("dbo.StockCableIns", "CableRollId", "dbo.CableRolls");
            DropForeignKey("dbo.StockCableOuts", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.StockCableOuts", "CableRollId", "dbo.CableRolls");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ProjectServices", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectComissions", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.ProjectComissions", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.MonthlySalaries", "SalaryStatusId", "dbo.SalaryStatus");
            DropForeignKey("dbo.MonthlySalaries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.FuelExpenses", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Clients", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.BillingYearlies", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.BillingQuaterlies", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.BillingOneTimes", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.BillingMonthlies", "ProjectId", "dbo.Projects");
            DropForeignKey("dbo.Projects", "ProjectBillingTypeId", "dbo.ProjectBillingTypes");
            DropForeignKey("dbo.AssignVehicles", "VehicleRecordId", "dbo.VehicleRecords");
            DropForeignKey("dbo.VehicleRecords", "VehicleTypeId", "dbo.VehicleTypes");
            DropForeignKey("dbo.VehicleRecords", "VehicleStatusId", "dbo.VehicleStatus");
            DropForeignKey("dbo.AssignVehicles", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.AdvanceSalaries", "EmployeeId", "dbo.Employees");
            DropForeignKey("dbo.Employees", "DesignationId", "dbo.Designations");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.StockEquipmentIns", new[] { "EquipmentTypeId" });
            DropIndex("dbo.StockEquipmentIns", new[] { "EquipmentId" });
            DropIndex("dbo.StockEquipmentOuts", new[] { "ProjectId" });
            DropIndex("dbo.StockEquipmentOuts", new[] { "EquipmentTypeId" });
            DropIndex("dbo.StockEquipmentOuts", new[] { "EquipmentId" });
            DropIndex("dbo.StockCableIns", new[] { "CableRollId" });
            DropIndex("dbo.StockCableOuts", new[] { "ProjectId" });
            DropIndex("dbo.StockCableOuts", new[] { "CableRollId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.ProjectServices", new[] { "ProjectId" });
            DropIndex("dbo.ProjectComissions", new[] { "ProjectId" });
            DropIndex("dbo.ProjectComissions", new[] { "EmployeeId" });
            DropIndex("dbo.MonthlySalaries", new[] { "SalaryStatusId" });
            DropIndex("dbo.MonthlySalaries", new[] { "EmployeeId" });
            DropIndex("dbo.FuelExpenses", new[] { "EmployeeId" });
            DropIndex("dbo.Clients", new[] { "ProjectId" });
            DropIndex("dbo.BillingYearlies", new[] { "ProjectId" });
            DropIndex("dbo.BillingQuaterlies", new[] { "ProjectId" });
            DropIndex("dbo.BillingOneTimes", new[] { "ProjectId" });
            DropIndex("dbo.Projects", new[] { "ProjectBillingTypeId" });
            DropIndex("dbo.BillingMonthlies", new[] { "ProjectId" });
            DropIndex("dbo.VehicleRecords", new[] { "VehicleStatusId" });
            DropIndex("dbo.VehicleRecords", new[] { "VehicleTypeId" });
            DropIndex("dbo.AssignVehicles", new[] { "VehicleRecordId" });
            DropIndex("dbo.AssignVehicles", new[] { "EmployeeId" });
            DropIndex("dbo.Employees", new[] { "DesignationId" });
            DropIndex("dbo.AdvanceSalaries", new[] { "EmployeeId" });
            DropTable("dbo.Years");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.StockEquipmentIns");
            DropTable("dbo.StockEquipmentOuts");
            DropTable("dbo.StockCableIns");
            DropTable("dbo.StockCableOuts");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ProjectServices");
            DropTable("dbo.ProjectComissions");
            DropTable("dbo.Months");
            DropTable("dbo.SalaryStatus");
            DropTable("dbo.MonthlySalaries");
            DropTable("dbo.FuelExpenses");
            DropTable("dbo.EquipmentTypes");
            DropTable("dbo.Equipments");
            DropTable("dbo.Clients");
            DropTable("dbo.CableRolls");
            DropTable("dbo.BillingYearlies");
            DropTable("dbo.BillingStatus");
            DropTable("dbo.BillingQuaterlies");
            DropTable("dbo.BillingOneTimes");
            DropTable("dbo.ProjectBillingTypes");
            DropTable("dbo.Projects");
            DropTable("dbo.BillingMonthlies");
            DropTable("dbo.VehicleTypes");
            DropTable("dbo.VehicleStatus");
            DropTable("dbo.VehicleRecords");
            DropTable("dbo.AssignVehicles");
            DropTable("dbo.Designations");
            DropTable("dbo.Employees");
            DropTable("dbo.AdvanceSalaries");
        }
    }
}
