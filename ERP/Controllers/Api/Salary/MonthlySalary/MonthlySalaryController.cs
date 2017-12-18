using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ERP.Controllers.Api.Salary.MonthlySalary
{
    public class MonthlySalaryController : ApiController
    {
        private ApplicationDbContext Db;

        public MonthlySalaryController()
        {
            Db = new ApplicationDbContext();
        }
    }
}
