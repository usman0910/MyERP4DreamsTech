using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERP.Controllers.Api.Billing
{
    public class BillingStatusController : ApiController
    {
        private ApplicationDbContext Db;
        public BillingStatusController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> Get()
        {
            //var billingStatus = await Db.BillingStatus.ToListAsync();
            var MonthlySalaries = await Db.MonthlySalaries.Where(e => e.Month == "December" && e.Year == "2017").Include(f => f.Employee.Designations).Include(b => b.SalaryStatus).ToListAsync();

            return Ok(/*billingStatus*/ MonthlySalaries);
        }
    }
}
