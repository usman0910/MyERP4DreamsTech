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

namespace ERP.Controllers.Api.ComplaintMangement
{
    public class ComplaintDetailsController : ApiController
    {
        private ApplicationDbContext Db;

        public ComplaintDetailsController()
        {
            Db = new ApplicationDbContext();
        }

        [HttpGet]
        async public Task<IHttpActionResult> GetDetails(int Id)
        {
            var complaint = await Db.ComplaintManagements.Include(e => e.Employee).Include(a => a.Project).SingleOrDefaultAsync(e => e.Id == Id);
            var stockEquiOut = await Db.StockEquipmentOut.Include(e => e.Equipment).Include(a => a.EquipmentType).Where(s => s.ForComplaintManagement == true && s.ProjectId == complaint.ProjectId && s.Date == complaint.ComplaintEntertainedDate).ToListAsync();
            var stockCableOut = await Db.StockCableOut.Include(e => e.CableRoll).Where(c => c.ForComplaintManagement == true && c.ProjectId == complaint.ProjectId && c.Date == complaint.ComplaintEntertainedDate).ToListAsync();
            var ComplaintVm = new ComplaintDetailsVM()
            {
                Complaint=complaint,
                StockCablesOut=stockCableOut,
                StockEquipmentsOut=stockEquiOut

            };
            return Ok(ComplaintVm);

        }
    }
}
