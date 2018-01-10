using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERP.Controllers.Api.Stocks.Counts
{
    public class CableCountController : ApiController
    {
        private ApplicationDbContext Db;
        public CableCountController()
        {
            Db = new ApplicationDbContext();
        }

        [HttpGet]
        async public Task<IHttpActionResult> Get(int Id)
        {
            
                var CableCount = (await Db.CableRolls.SingleOrDefaultAsync(i => i.Id == Id)).StockAvailable;
                return Ok(CableCount);

            
        }

    }
}
