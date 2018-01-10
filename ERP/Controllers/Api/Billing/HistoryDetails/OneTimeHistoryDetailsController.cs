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
    public class OneTimeHistoryDetailsController : ApiController
    {
        private ApplicationDbContext Db;
        public OneTimeHistoryDetailsController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> Get(int Id)
        {
            var details = await Db.OneTimeHistoryDetails.Where(e => e.BillingOneTimeId == Id).ToListAsync();
            return Ok(details);
        }
    }
}
