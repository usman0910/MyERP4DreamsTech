using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERP.Controllers.Api.ComplaintMangement
{
    public class GetProjectsController : ApiController
    {
        private ApplicationDbContext Db;

        public GetProjectsController()
        {
            Db = new ApplicationDbContext();
        }

        [HttpGet]
        async public Task<IHttpActionResult> Get(int Id)
        {
            var projects = await Db.Projects.Where(c => c.ClientId == Id).ToListAsync();
            return Ok(projects);
        }
    }
}
