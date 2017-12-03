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
    public class YearlyBillingHistoryController : ApiController
    {
        private ApplicationDbContext Db;
        public YearlyBillingHistoryController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> Get(int Id)
        {
            var yearlyHistory = await Db.BillingYearly.Where(i => i.ProjectId == Id).Include(d => d.BillingStatus).ToListAsync();
            return Ok(yearlyHistory);
        }
    }
}
