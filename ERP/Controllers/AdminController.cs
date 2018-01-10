using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    
    public class AdminController : Controller
    {

        private ApplicationDbContext Db;
        public AdminController()
        {
            Db = new ApplicationDbContext();
        }


        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }
    }
}