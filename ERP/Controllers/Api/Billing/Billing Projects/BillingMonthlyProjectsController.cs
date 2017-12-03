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
    public class BillingMonthlyProjectsController : ApiController
    {
        private ApplicationDbContext Db;
        public BillingMonthlyProjectsController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> Get()
        {
            var monthlyProjects = await Db.Projects.Where(p=>p.ProjectBillingTypeId==2).ToListAsync();  

            return Ok(monthlyProjects);
        }
    }
}
