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
    public class EquipmentAddToProjectController : ApiController
    {
        private ApplicationDbContext Db;
        public EquipmentAddToProjectController()
        {
            Db = new ApplicationDbContext();
        }

        [HttpGet]
        async public Task<IHttpActionResult> Add()
        {
            var projects = await  Db.Projects.Where(e=>e.ProjectBillingTypeId==1).Include(e=>e.Client).ToListAsync();
            var equipments = await Db.Equipments.ToListAsync();
            var equipmentTypes = await Db.EquipmentTypes.ToListAsync();

            var equipmentAddToProject = new EquipmentAddToProject()
            {
                EquipmentTypes = equipmentTypes,
                Equipments = equipments,
                Projects = projects


            };
            return Ok(equipmentAddToProject);
        }

        [HttpPost]
        async public Task<IHttpActionResult> Add(StockEquipmentOut equip)
        {
            Db.StockEquipmentOut.Add(equip);
            var equipment = await Db.Equipments.SingleOrDefaultAsync(e => e.Id == equip.EquipmentId);

            if (equipment.StockAvailable > 0)
            {
                equipment.StockAvailable = equipment.StockAvailable - equip.Quantity;
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
