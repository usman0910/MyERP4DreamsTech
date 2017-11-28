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
    public class ProjectController : Controller
    {
        private ApplicationDbContext Db;

        public ProjectController()
        {

            Db = new ApplicationDbContext();
        }


        public ActionResult NewProject()
        {
            return View();

        }
        public ActionResult PreviousProjects()
        {
            return View();

        }

        public ActionResult AddEquipment(int Id)
        {
            return View();

        }
        public ActionResult AddCable(int Id)
        {
            return View();

        }
        public ActionResult AddService(int Id)
        {
            return View();

        }
        public ActionResult ViewProjectDetails(int Id)
        {
            return View();
        }

        public ActionResult EditProject(int Id)
        {
            return View();
        }


        public ActionResult EquipmentAddToProject()
        {
            return View();
        }
        public ActionResult CableAddToProject()
        {
            return View();
        }


        public ActionResult ServicesAddToProject()
        {
            return View();
        }
    }
}