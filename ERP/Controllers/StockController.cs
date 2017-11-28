using ERP.Models;
using ERP.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class StockController : Controller
    {
        private ApplicationDbContext Db;

        public StockController()
        {
            Db = new ApplicationDbContext();
        }

        // GET: Stock
        async public Task<ActionResult> New()
        {
            var cables = await Db.CableRolls.ToListAsync();
            var equipments = await Db.Equipments.ToListAsync();
            var equipmentTypes = await Db.EquipmentTypes.ToListAsync();

            var stockVm = new StockVM()
            {
                Cables = cables,
                Equipments = equipments,
                EquipmentTypes = equipmentTypes
            };

            return View(stockVm);
        }
        [HttpPost]
        async public Task<ActionResult> New(StockVM stockVM)
        {

            if (stockVM.StockCableIn.CableRollId != 0 && stockVM.StockEquipmentIn.EquipmentId != 0)
            {
                Db.StockEquipmentsIn.Add(stockVM.StockEquipmentIn);
                Db.StockCablesIn.Add(stockVM.StockCableIn);

                var equipment = await Db.Equipments.SingleOrDefaultAsync(e => e.Id == stockVM.StockEquipmentIn.EquipmentId);
                equipment.StockAvailable = equipment.StockAvailable + stockVM.StockEquipmentIn.Quantity;

                var cable = await Db.CableRolls.SingleOrDefaultAsync(c => c.Id == stockVM.StockCableIn.CableRollId);
                cable.StockAvailable = cable.StockAvailable + stockVM.StockCableIn.Totalfeets;
            }

            else if (stockVM.StockCableIn.CableRollId == 0)
            {
                Db.StockEquipmentsIn.Add(stockVM.StockEquipmentIn);

                var equipment = await Db.Equipments.SingleOrDefaultAsync(e => e.Id == stockVM.StockEquipmentIn.EquipmentId);

                equipment.StockAvailable = equipment.StockAvailable + stockVM.StockEquipmentIn.Quantity;
            }
            else if (stockVM.StockEquipmentIn.EquipmentId == 0)
            {
                Db.StockCablesIn.Add(stockVM.StockCableIn);

                var cable = await Db.CableRolls.SingleOrDefaultAsync(c => c.Id == stockVM.StockCableIn.CableRollId);

                cable.StockAvailable = cable.StockAvailable + stockVM.StockCableIn.Totalfeets;
            }

            

            

            await Db.SaveChangesAsync();

            return RedirectToAction("New");
        }

        async public Task<ActionResult> ViewAll()
        {
            var equipments = await Db.Equipments.ToListAsync();
            var cables = await Db.CableRolls.ToListAsync();
            var stockVm = new StockVM()
            {
                Cables = cables,
                Equipments = equipments
            };
            return View(stockVm);
        }
        public ActionResult Update()
        {
            return View();
        }
    }
}