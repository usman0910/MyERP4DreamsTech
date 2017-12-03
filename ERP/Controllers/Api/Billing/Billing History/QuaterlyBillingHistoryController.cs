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
    public class QuaterlyBillingHistoryController : ApiController
    {
        private ApplicationDbContext Db;
        public QuaterlyBillingHistoryController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> Get(int Id)
        {
            var quaterlyHistory = await Db.BillingQuaterly.Where(i => i.ProjectId == Id).Include(d => d.BillingStatus).ToListAsync();
            return Ok(quaterlyHistory);
        }
    }
}
