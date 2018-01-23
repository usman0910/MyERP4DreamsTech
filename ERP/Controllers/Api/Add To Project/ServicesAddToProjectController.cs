using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERP.Controllers.Api.Add_To_Project
{
    public class ServicesAddToProjectController : ApiController
    {
        private ApplicationDbContext Db;
        public ServicesAddToProjectController()
        {
            Db = new ApplicationDbContext();
        }

        [HttpGet]
        async public Task<IHttpActionResult> Add()
        {
            var projects = await Db.Projects.Where(e => e.ProjectBillingTypeId == 1).Include(e => e.Client).ToListAsync();
            
            return Ok(projects);
        }

        [HttpPost]
        public IHttpActionResult Add(ProjectService projectService)
        {

            Db.ProjectServices.Add(projectService);

            Db.SaveChangesAsync();
            return Ok();
        }
    }
}
