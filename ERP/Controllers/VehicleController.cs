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
    public class VehicleController : Controller
    {

        private ApplicationDbContext Db;

        public VehicleController()
        {
            Db = new ApplicationDbContext();
        }
        // GET: Vehicle
        async public Task<ActionResult> New()
        {
            var vehicleTypes = await Db.VehicleTypes.ToListAsync();
            var vehicleVM = new VehicleVM()
            {
                VehicleTypes=vehicleTypes
            };
            return View(vehicleVM);
        }
        [HttpPost]
        async public Task<ActionResult> New(VehicleVM vehicleVM)
        {
            vehicleVM.Vehicle.VehicleStatusId = 2;
            Db.VehicleRecords.Add(vehicleVM.Vehicle);

            await Db.SaveChangesAsync();
            return RedirectToAction("ViewAll");
        }
        
        async public Task<ActionResult> ViewAll()
        {
            var vehicles = await Db.VehicleRecords.Include("VehicleType").Include("VehicleStatus").ToListAsync();
            return View(vehicles);
        }
        async public Task<ActionResult> AllotEmployee()
        {
            var employees = await Db.Employees.ToListAsync();
            var vehicleRecords = await Db.VehicleRecords.ToListAsync();
            var assignVehicleVm = new AssignVehicleVm()
            {
                Employees=employees,
                Vehicles= vehicleRecords
            };
            return View(assignVehicleVm);
        }
        [HttpPost]
        async public Task<ActionResult> AllotEmployee(AssignVehicle assignVehicle)
        {
            Db.AssignVehicles.Add(assignVehicle);
            var veh = await Db.VehicleRecords.SingleOrDefaultAsync(e => e.Id == assignVehicle.VehicleRecordId);
            veh.VehicleStatusId = 1;
            await Db.SaveChangesAsync();
            return RedirectToAction("ViewAll");
        }

        async public Task<ActionResult> ViewAllotment()
        {
            var allotments = await Db.AssignVehicles.Include("Employee").Include(l=>l.VehicleRecord.VehicleType).ToListAsync();
            return View(allotments);
        }

        async public Task<ActionResult> CancelAllotment(int Id)
        {
            var allotmnt = await Db.AssignVehicles.SingleOrDefaultAsync(e=>e.Id==Id);
            Db.AssignVehicles.Remove(allotmnt);
            var veh = await Db.VehicleRecords.SingleOrDefaultAsync(e => e.Id == allotmnt.VehicleRecordId);
            veh.VehicleStatusId = 2;
            await Db.SaveChangesAsync();
            return RedirectToAction("ViewAll");
        }
    }
}