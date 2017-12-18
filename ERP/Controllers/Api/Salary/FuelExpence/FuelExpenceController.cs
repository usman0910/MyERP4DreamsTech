using ERP.Models;
using ERP.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERP.Controllers.Api.Salary.FuelExpence
{
    public class FuelExpenceController : ApiController
    {
        private ApplicationDbContext Db;

        public FuelExpenceController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> AddFuelExpence()
        {
            var employees = await Db.Employees.ToListAsync();
            return Ok(employees);
        }
        [HttpPost]
        async public Task<IHttpActionResult> AddFuelExpence(FuelExpense fuelExpense)
        {
            Db.FuelExpense.Add(fuelExpense);
            await Db.SaveChangesAsync();
            return Ok();
        }
    }
}
