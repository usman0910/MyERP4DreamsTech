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

namespace ERP.Controllers.Api.Project
{
    public class ProjectDetailsController : ApiController
    {
        private ApplicationDbContext Db;

        public ProjectDetailsController()
        {
            Db = new ApplicationDbContext();
        }

        [HttpGet]
        async public Task<IHttpActionResult> Details(int Id)
        {
            var project = await Db.Projects.Include(c=>c.Client).Include("ProjectBillingType").SingleOrDefaultAsync(p => p.Id == Id);
            var projectCommision = await Db.ProjectComission.Include(e => e.Employee).FirstOrDefaultAsync(p => p.ProjectId == Id);
            var stockEquiOut = await Db.StockEquipmentOut.Include(e => e.Equipment).Include(a => a.EquipmentType).Where(s => s.IsFirstTime == true && s.ProjectId == Id).ToListAsync();
            var stockCableOut = await Db.StockCableOut.Include(e => e.CableRoll).Where(c => c.IsFirstTime == true && c.ProjectId == Id).ToListAsync();

            var projectVM = new ProjectDetailsVM()
            {
                Project = project,
                ProjectComission = projectCommision,
                StockCableOuts = stockCableOut,
                StockEquipmentOuts = stockEquiOut


            };
            return Ok(projectVM);
        }
    }
}
