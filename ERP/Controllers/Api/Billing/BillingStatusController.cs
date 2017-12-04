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
            var billingStatus = await Db.BillingStatus.ToListAsync();

            return Ok(billingStatus);
        }
    }
}
