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


        public ActionResult NewProject()
        {
            return View();

        }
        public ActionResult PreviousProjects()
        {
            return View();

        }

        public ActionResult AddEquipment(string Id)
        {
            return View();

        }
        public ActionResult AddCable(string Id)
        {
            return View();

        }
        public ActionResult AddService(string Id)
        {
            return View();

        }
        public ActionResult ViewProjectDetails(int Id)
        {
            return View();
        }

        [Authorize(Roles = "CanManage")]
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

        public ActionResult ViewOneTimeAdditions()
        {
            return View();
        }

        public ActionResult OneTimeAdditionDetails(int Id)
        {
            return View();
        }
        
    }
}