﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ERP.Controllers
{
    public class ClientController : Controller
    {

        public ActionResult AddNew()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            return View();
        }
    }
}