using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {


        public DbSet<Employee> Employees { get; set; }
        public DbSet<Years> Years { get; set; }
        public DbSet<Months> Months { get; set; }
        public DbSet<Designations> Designations { get; set; }
        public DbSet<AssignVehicle> AssignVehicles { get; set; }
        public DbSet<VehicleType> VehicleTypes { get; set; }
        public DbSet<VehicleRecord> VehicleRecords { get; set; }
        public DbSet<CableRoll> CableRolls { get; set; }
        public DbSet<StockCableIn> StockCablesIn { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<StockEquipmentIn> StockEquipmentsIn { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectBillingType> ProjectBillingTypes { get; set; }
        public DbSet<ProjectService> ProjectServices { get; set; }
        public DbSet<StockCableOut> StockCableOut { get; set; }
        public DbSet<StockEquipmentOut> StockEquipmentOut { get; set; }
        public DbSet<ProjectComission> ProjectComission { get; set; }
        public DbSet<AdvanceSalary> AdvanceSalary { get; set; }
        public DbSet<FuelExpense> FuelExpense { get; set; }
        public DbSet<SalaryStatus> SalaryStatus { get; set; }
        public DbSet<VehicleStatus> VehicleStatus { get; set; }
        public DbSet<MonthlySalary> MonthlySalarys { get; set; }
        public DbSet<BillingStatus> BillingStatus { get; set; }
        public DbSet<BillingMonthly> BillingMonthly { get; set; }
        public DbSet<BillingQuaterly> BillingQuaterly { get; set; }
        public DbSet<BillingYearly> BillingYearly { get; set; }
        public DbSet<BillingOneTime> BillingOneTime { get; set; }






        public ApplicationDbContext()
            : base("ApplicationDbContext", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}