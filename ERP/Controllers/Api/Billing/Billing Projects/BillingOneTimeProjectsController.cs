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
    public class BillingOneTimeProjectsController : ApiController
    {
        private ApplicationDbContext Db;
        public BillingOneTimeProjectsController()
        {
            Db = new ApplicationDbContext();
        }
        async public Task<IHttpActionResult> Get()
        {
            //var oneTimeProjects = await Db.Projects.Where(p => p.ProjectBillingTypeId == 1).ToListAsync();
            var oneTimeProjects = await Db.BillingOneTime.Include(p => p.Project).Include(s => s.BillingStatus).Where(e=>e.Project.ProjectBillingTypeId==1).ToListAsync();
            return Ok(oneTimeProjects);
        }
    }
}
