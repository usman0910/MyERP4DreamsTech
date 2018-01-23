using ERP.Models;
using ERP.ViewModels;
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
    public class OneTimeAdditionDetailsController : ApiController
    {
        private ApplicationDbContext Db;

        public OneTimeAdditionDetailsController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> ViewDetails(int Id)
        {
            var stockEquipments = await Db.StockEquipmentOut.Where(e => e.ProjectId == Id && e.ForComplaintManagement == false && e.IsFirstTime == false).Include(c=>c.Equipment).Include(d=>d.EquipmentType).ToListAsync();
            var stockCable = await Db.StockCableOut.Where(e => e.ProjectId == Id && e.ForComplaintManagement == false && e.IsFirstTime == false).Include(c=>c.CableRoll).ToListAsync();
            var service = await Db.ProjectServices.Where(e => e.ProjectId == Id && e.IsFirstTime == false).ToListAsync();
            var detailsVM = new OneTimeAdditionVM()
            {
                EquipmentOuts=stockEquipments,
                CablesOuts=stockCable,
                Services=service
            };
            return Ok(detailsVM);
        }
    }
}
