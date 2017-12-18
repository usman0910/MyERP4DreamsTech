using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERP.Controllers.Api.Salary.AdvanceSalary
{
    public class AdvanceSalaryController : ApiController
    {
        private ApplicationDbContext Db;

        public AdvanceSalaryController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> AddAdvance()
        {
            var employees = await Db.Employees.ToListAsync();
            return Ok(employees);
        }
        [HttpPost]
        async public Task<IHttpActionResult> AddAdvance(Models.AdvanceSalary advanceSalary)
        {
            Db.AdvanceSalary.Add(advanceSalary);
            await Db.SaveChangesAsync();
            return Ok();
        }
    }
}
