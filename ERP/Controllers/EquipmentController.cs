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
        [Authorize(Roles = "CanManage")]
        [HttpGet]
        public ActionResult EditEquipment(int Id)
        {
            var equip = Db.Equipments.SingleOrDefault(e=>e.Id==Id);
            return View(equip);
        }
        [Authorize(Roles = "CanManage")]
        [HttpPost]
        public ActionResult EditEquipment(Equipment equipment)
        {
            var equip = Db.Equipments.SingleOrDefault(e=>e.Id==equipment.Id);
            equip.Name = equipment.Name;
            equip.Brand = equipment.Brand;
            equip.UnitPrice = equipment.UnitPrice;

            Db.SaveChanges();
            return RedirectToAction("ViewAllEquipments");
        }
        [Authorize(Roles = "CanManage")]
        public ActionResult DeleteEquipment(int Id)
        {
            var equip = Db.Equipments.SingleOrDefault(e => e.Id == Id);
            Db.Equipments.Remove(equip);
            Db.SaveChanges();
            return RedirectToAction("ViewAllEquipments");
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
        [Authorize(Roles = "CanManage")]
        [HttpGet]
        public ActionResult EditCable(int Id)
        {
            var cable = Db.CableRolls.SingleOrDefault(e => e.Id == Id);
            return View(cable);
        }
        [Authorize(Roles = "CanManage")]
        [HttpPost]
        public ActionResult EditCable(CableRoll cableRoll)
        {
            var equip = Db.CableRolls.SingleOrDefault(e => e.Id == cableRoll.Id);
            equip.Brand = cableRoll.Brand;
            equip.FeetPrice = cableRoll.FeetPrice;

            Db.SaveChanges();
            return RedirectToAction("ViewAllCables");
        }
        [Authorize(Roles = "CanManage")]
        public ActionResult DeleteCable(int Id)
        {
            var cable = Db.CableRolls.SingleOrDefault(e => e.Id == Id);
            Db.CableRolls.Remove(cable);
            Db.SaveChanges();
            return RedirectToAction("ViewAllCables");
        }
    }
}