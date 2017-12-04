using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class BillingController : Controller
    {
        // GET: Billing
        public ActionResult BillingMonthlyProjects()
        {
            return View();
        }
        public ActionResult BillingOneTimeProjects()
        {
            return View();
        }
        public ActionResult BillingQuaterlyProjects()
        {
            return View();
        }
        public ActionResult BillingYearlyProjects()
        {                                         
            return View();                        
        }     
        public ActionResult MonthlyBillingHistory(int Id)
        {
            return View();
        }
        public ActionResult QuaterlyBillingHistory(int Id)
        {
            return View();
        }
        public ActionResult YearlyBillingHistory(int Id)
        {
            return View();
        }
        public ActionResult ChangeMonthlyBillingStatus(int Id)
        {
            return View();
        }
        public ActionResult ChangeQuaterlyBillingStatus(int Id)
        {
            return View();
        }
        public ActionResult ChangeYearlyBillingStatus(int Id)
        {
            return View();
        }
    }
}