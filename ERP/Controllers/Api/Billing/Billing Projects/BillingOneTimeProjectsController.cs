using ERP.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERP.Controllers.Api.Billing.Billing_Projects
{
    public class BillingOneTimeProjectsController : ApiController
    {
        private ApplicationDbContext Db;
        public BillingOneTimeProjectsController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> Get()
        {
            
            var oneTimeProjects = await Db.BillingOneTime.Include(p => p.Project).Include(s => s.BillingStatus).Where(e=>e.Project.ProjectBillingTypeId==1).ToListAsync();
            return Ok(oneTimeProjects);
        }
        [HttpPost]
        async public Task<IHttpActionResult> UpdateStatus(BillingOneTime billingOneTime)
        {
            var statusUpdate = await Db.BillingOneTime.SingleOrDefaultAsync(e => e.Id == billingOneTime.Id);

            statusUpdate.BillingStatusId = billingOneTime.BillingStatusId;

            await Db.SaveChangesAsync();

            return Ok();
        }
    }
}
