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
    public class AddClientController : ApiController
    {
        private ApplicationDbContext Db;

        public AddClientController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpPost]
        async public Task<IHttpActionResult> AddNew(Models.Client client)
        {
            Db.Clients.Add(client);
            await Db.SaveChangesAsync();
            return Ok();
        }
    }
}
