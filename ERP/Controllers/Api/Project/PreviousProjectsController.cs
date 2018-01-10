using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERP.Controllers.Api.Project
{
    public class PreviousProjectsController : ApiController
    {
        private ApplicationDbContext Db;

        public PreviousProjectsController()
        {
            Db = new ApplicationDbContext();
        }

        [HttpGet]
        async public Task<IHttpActionResult> AllProjects()
        {
            var projects = await Db.Projects.Include(e=>e.Client).Include("ProjectBillingType").ToListAsync();
            return Ok(projects);
        }
    }
}
