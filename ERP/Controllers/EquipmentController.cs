using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class EquipmentController : Controller
    {
        private ApplicationDbContext Db;

        public EquipmentController()
        {
            Db = new ApplicationDbContext();
        }
        // GET: Equipment
        public ActionResult AddEquipment()
        {
            return View();
        }
        [HttpPost]
        async public Task<ActionResult> AddEquipment(Equipment equipment)
        {
            Db.Equipments.Add(equipment);
            await Db.SaveChangesAsync();
            return RedirectToAction("AddEquipment");
        }

        async public Task<ActionResult> ViewAllEquipments()
        {
            var equips = await Db.Equipments.ToListAsync();
            return View(equips);
        }
        public ActionResult DeleteEquipment()
        {
            return View();
        }
        public ActionResult AddCable()
        {
            
            return View();
        }
        [HttpPost]
        async public Task<ActionResult> AddCable(CableRoll cable)
        {
            Db.CableRolls.Add(cable);
            await Db.SaveChangesAsync();
            return RedirectToAction("AddCable");
        }

        async public Task<ActionResult> ViewAllCables()
        {
            var cables = await Db.CableRolls.ToListAsync();
            return View(cables);
        }
        public ActionResult DeleteCable()
        {
            return View();
        }
    }
}