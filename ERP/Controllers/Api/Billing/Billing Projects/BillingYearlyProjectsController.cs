using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERP.Controllers.Api.Billing.Billing_Projects
{
    public class BillingYearlyProjectsController : ApiController
    {
        private ApplicationDbContext Db;
        public BillingYearlyProjectsController()
        {
            Db = new ApplicationDbContext();
        }
        async public Task<IHttpActionResult> Get()
        {

            var yearlyProjects = await Db.Projects.Where(p => p.ProjectBillingTypeId == 4).ToListAsync();

            return Ok(yearlyProjects);

        }
        [HttpPost]
        async public Task<IHttpActionResult> UpdateStatus(BillingYearly billingYearly)
        {
            var statusUpdate = await Db.BillingYearly.SingleOrDefaultAsync(e => e.Id == billingYearly.Id);

            statusUpdate.BillingStatusId = billingYearly.BillingStatusId;

            await Db.SaveChangesAsync();

            return Ok();
        }
    }
}
