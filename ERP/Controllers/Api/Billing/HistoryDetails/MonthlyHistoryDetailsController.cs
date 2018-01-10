using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERP.Controllers.Api.Billing.HistoryDetails
{
    public class MonthlyHistoryDetailsController : ApiController
    {
        private ApplicationDbContext Db;
        public MonthlyHistoryDetailsController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> Get(int Id)
        {
            var details = await Db.MonthlyHistoryDetails.Where(e=>e.BillingMonthlyId==Id).ToListAsync();
            return Ok(details);
        }
    }
}
