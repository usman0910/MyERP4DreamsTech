using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERP.Controllers.Api.Billing.Billing_History
{
    public class MonthlyBillingHistoryController : ApiController
    {
        private ApplicationDbContext Db;
        public MonthlyBillingHistoryController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> Get(int Id)
        {
            var monthlyHistory = await Db.BillingMonthly.Where(i=>i.ProjectId==Id).Include(d=>d.BillingStatus).ToListAsync();
            return Ok(monthlyHistory);
        }
    }
}
