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
    public class PreviousComplaintsController : ApiController
    {
        private ApplicationDbContext Db;

        public PreviousComplaintsController()
        {
            Db = new ApplicationDbContext();
        }

        [HttpGet]
        async public Task<IHttpActionResult> ViewPrevious()
        {
            var complaints = await Db.ComplaintManagements.Include(e=>e.Employee).Include(a=>a.Project).ToListAsync();
            return Ok(complaints);
        }
    }
}
