using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class ComplaintManagementController : Controller
    {
        // GET: ComplaintManagement
        public ActionResult AddNewComplaint()
        {
            return View();
        }
        public ActionResult PreviousComplaints()
        {
            return View();
        }

        public ActionResult ComplaintDetails(int Id)
        {
            return View();
        }
    }
}