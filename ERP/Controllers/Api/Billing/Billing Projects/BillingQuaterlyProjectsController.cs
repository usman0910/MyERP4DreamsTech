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
    public class BillingQuaterlyProjectsController : ApiController
    {
        private ApplicationDbContext Db;
        public BillingQuaterlyProjectsController()
        {
            Db = new ApplicationDbContext();
        }
        async public Task<IHttpActionResult> Get()
        {
            var quaterlyProjects = await Db.Projects.Where(p => p.ProjectBillingTypeId == 3).ToListAsync();

            return Ok(quaterlyProjects);
        }
    }
}
