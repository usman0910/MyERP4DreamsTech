using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.Controllers.Api.Project
{
    public class GetDateController : ApiController
    {
        private ApplicationDbContext Db;

        public GetDateController()
        {
            Db = new ApplicationDbContext();
        }

        [HttpGet]
        public IHttpActionResult New(int Id)
        {
            var date = Db.Projects.SingleOrDefault(p=>p.Id==Id).StartingDate;
            return Ok(date);
        }
    }
}
