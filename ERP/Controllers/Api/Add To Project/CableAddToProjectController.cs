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

namespace ERP.Controllers.Api.Add_To_Project
{
    public class CableAddToProjectController : ApiController
    {
        private ApplicationDbContext Db;
        public CableAddToProjectController()
        {
            Db = new ApplicationDbContext();
        }

        [HttpGet]
        async public Task<IHttpActionResult> Add()
        {
            var projects = await Db.Projects.ToListAsync();
            var cables = await Db.CableRolls.ToListAsync();

            var cableAddToProject = new CableAddToProject()
            {
                Projects = projects,
                Cables = cables


            };
            return Ok(cableAddToProject);
        }

        [HttpPost]
        async public Task<IHttpActionResult> Add(StockCableOut cbl)
        {
            Db.StockCableOut.Add(cbl);
            var cable = await Db.CableRolls.SingleOrDefaultAsync(e => e.Id == cbl.CableRollId);

            if (cable.StockAvailable > 0)
            {
                cable.StockAvailable = cable.StockAvailable - cbl.Totalfeets;
            }
            else
            {
                return NotFound();
            }
            await Db.SaveChangesAsync();
            return Ok();
        }

        
    }
}
