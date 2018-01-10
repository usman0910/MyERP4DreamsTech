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
    public class SalaryController : Controller
    {
        private ApplicationDbContext Db;

        public SalaryController()
        {
            Db = new ApplicationDbContext();
        }
        
        public ActionResult ViewSalary()
        {
            return View();
        }


        public ActionResult AddFuelExpence()
        {
            return View();
        }


        public ActionResult AddAdvance()
        {
            return View();
        }



    }
}