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
            var LastToDate = Db.BillingQuaterly.ToList().LastOrDefault(e => e.ProjectId == Id).To;

            if (LastToDate.Date.AddMonths(3) <= DateTime.Now.Date)
            {
                var billingQuaterly = new BillingQuaterly()
                {
                    BillingStatusId = 2,
                    From = LastToDate.Date,
                    To = LastToDate.Date.AddMonths(3),
                    ProjectId = Id

                };
                Db.BillingQuaterly.Add(billingQuaterly);
                await Db.SaveChangesAsync();
            }
            var quaterlyHistory = await Db.BillingQuaterly.Where(i => i.ProjectId == Id).Include(d => d.BillingStatus).ToListAsync();
            return Ok(quaterlyHistory);
        }
    }
}
