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
    public class EquipmentCountController : ApiController
    {
        private ApplicationDbContext Db;
        public EquipmentCountController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> Get(int Id)
        {
            
                var EquipmentCount = (await Db.Equipments.SingleOrDefaultAsync(i => i.Id == Id)).StockAvailable;
                return Ok(EquipmentCount);
        }
    }
}
