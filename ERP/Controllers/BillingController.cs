﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class BillingController : Controller
    {
        // GET: Billing
        public ActionResult ProjectsBilling()
        {
            return View();
        }
    }
}