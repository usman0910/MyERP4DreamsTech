using ERP.Models;
using ERP.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class EmployeeController : Controller
    {
        private ApplicationDbContext Db;

        public EmployeeController()
        {
            Db = new ApplicationDbContext();
        }
        // GET: Employee
        async public Task<ActionResult> New()
        {
            var designations = await Db.Designations.ToListAsync();
            var empVm = new EmployeeVM()
            {
                Designations=designations
            };
            return View(empVm);
        }
        [HttpPost]
        async public Task<ActionResult> New(EmployeeVM employeeVm)
        {
            if (employeeVm.Employee.Id==0)
            {
                Db.Employees.Add(employeeVm.Employee);
                await Db.SaveChangesAsync();
                return RedirectToAction("AllEmployees");
            }
            else
            {
                var emp = await Db.Employees.SingleOrDefaultAsync(e => e.Id == employeeVm.Employee.Id);
                emp.FullName = employeeVm.Employee.FullName;
                emp.CNIC = employeeVm.Employee.CNIC;
                emp.DesignationId = employeeVm.Employee.DesignationId;
                emp.BasicSalary = employeeVm.Employee.BasicSalary;
                emp.BirthDate = employeeVm.Employee.BirthDate;
                emp.JoiningDate = employeeVm.Employee.JoiningDate;
                emp.City = employeeVm.Employee.City;
                emp.PermanentAddress = employeeVm.Employee.PermanentAddress;
                emp.ContactNumber = employeeVm.Employee.ContactNumber;

                await Db.SaveChangesAsync();

                return RedirectToAction("AllEmployees");
            }
        }

        async public Task<ActionResult> EmployeeDetail(int Id)
        {
            var employee = await Db.Employees.Include("Designations").FirstOrDefaultAsync(e=>e.Id==Id);
            return View(employee);
        }

        async public Task<ActionResult> AllEmployees()
        {
            var employees = await Db.Employees.Include("Designations").ToListAsync();
            return View(employees);
        }

        [Authorize(Roles = "CanManage")]
        async public Task<ActionResult> EditEmployee(int Id)
        {
            var employee = await Db.Employees.Include("Designations").SingleOrDefaultAsync(e=>e.Id==Id);
            var designations = await Db.Designations.ToListAsync();
            var empVM = new EmployeeVM()
            {
                Employee = employee,
                Designations = designations
            };
            return View(empVM);
        }

        [Authorize(Roles = "CanManage")]
        async public Task<ActionResult> Delete(int Id)
        {
            var emp = await Db.Employees.SingleOrDefaultAsync(e=>e.Id==Id);
            Db.Employees.Remove(emp);

            var allotmntcheck = await Db.AssignVehicles.CountAsync(e => e.EmployeeId == emp.Id);

            if (allotmntcheck>0)
            {
                var allotmnt = await Db.AssignVehicles.SingleOrDefaultAsync(e => e.EmployeeId == emp.Id);
                
                Db.AssignVehicles.Remove(allotmnt);

                var veh = await Db.VehicleRecords.SingleOrDefaultAsync(e => e.Id == allotmnt.VehicleRecordId);
                veh.VehicleStatusId = 2; 
            }
            
            await Db.SaveChangesAsync();
            return RedirectToAction("AllEmployees");


        }
    }
}