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
    public class SalaryController : Controller
    {
        private ApplicationDbContext Db;

        public SalaryController()
        {
            Db = new ApplicationDbContext();
        }
        
        public ActionResult GenerateSalary()
        {
            return View();
        }
        public ActionResult ViewSalary()
        {
            return View();
        }


        async public Task<ActionResult> AddFuelExpence()
        {
            var employees = await Db.Employees.ToListAsync();
            var advanceSalaryVm = new AdvanceSalaryVM()
            {
                Employees = employees
            };
            return View(advanceSalaryVm);
        }
        [HttpPost]
        async public Task<ActionResult> AddFuelExpence(AdvanceSalaryVM fuel)
        {
            Db.FuelExpense.Add(fuel.FuelExpense);
            await Db.SaveChangesAsync();
            return RedirectToAction("AddFuelExpence");
        }


        async public Task<ActionResult> AddAdvance()
        {
            var employees = await Db.Employees.ToListAsync();
            var advanceSalaryVm = new AdvanceSalaryVM()
            {
                Employees=employees
            };
            return View(advanceSalaryVm);
        }
        [HttpPost]
        async public Task<ActionResult> AddAdvance(AdvanceSalary advanceSalary)
        {
            Db.AdvanceSalary.Add(advanceSalary);
            await Db.SaveChangesAsync();
            return RedirectToAction("AddAdvance");
        }


        
    }
}