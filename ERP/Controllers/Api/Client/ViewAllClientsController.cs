using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERP.Controllers.Api.Client
{
    public class ViewAllClientsController : ApiController
    {
        private ApplicationDbContext Db;

        public ViewAllClientsController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> ViewAll()
        {
            var clients = await Db.Clients.ToListAsync();
            return Ok(clients);
        }
    }
}
