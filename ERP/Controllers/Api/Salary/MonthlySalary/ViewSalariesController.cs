using ERP.Models;
using ERP.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERP.Controllers.Api.Salary.MonthlySalary
{
    public class ViewSalariesController : ApiController
    {
        private ApplicationDbContext Db;

        public ViewSalariesController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpPost]
        async public Task<IHttpActionResult> GetSalaries(SalaryDateVM salaryDate)
        {
            var MonthlySalaries = await Db.MonthlySalaries.Where(e => e.Month == salaryDate.M && e.Year == salaryDate.Y).Include(f => f.Employee.Designations).Include(b => b.SalaryStatus).ToListAsync();

            return Ok(MonthlySalaries);
        }
    }
}
