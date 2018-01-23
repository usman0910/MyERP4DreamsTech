using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERP.Controllers.Api.OneTimeAddition
{
    public class OneTimeProjectsController : ApiController
    {
        private ApplicationDbContext Db;

        public OneTimeProjectsController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> ViewAllOneTimes()
        {
            var oneTimeProjects = await Db.Projects.Where(e=>e.ProjectBillingTypeId==1).Include(i=>i.Client).ToListAsync();
            return Ok(oneTimeProjects);
        }
    }
}
