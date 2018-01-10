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
    public class MonthlySalaryController : ApiController
    {
        private ApplicationDbContext Db;

        public MonthlySalaryController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> GetFields()

        {
            var months = await Db.Months.ToListAsync();
            var years = await Db.Years.ToListAsync();
            var latestSalaryDate = DateTime.Now.Date.AddMonths(-1);
            var latestSalaryMonth = latestSalaryDate.Month;
            var latestSalaryYear = latestSalaryDate.Year;
            var thisMonth = DateTime.Now.Date.Month;
            var thisYear = DateTime.Now.Date.Year;
            var CurrentSalaryMonth = await Db.Months.SingleOrDefaultAsync(e => e.Id == latestSalaryMonth);
            var CurrentSalaryYear = await Db.Years.SingleOrDefaultAsync(e => e.Id == latestSalaryYear);

            var salaryVm = new SalaryVM()
            {
                Months = months,
                Years = years,
                Year = CurrentSalaryYear,
                Month = CurrentSalaryMonth

            };

            return Ok(salaryVm);


        }
        [HttpPost]
        async public Task<IHttpActionResult> CurrentMonthSalary(SalaryDateVM salaryDate)
        {


            var empCount = await Db.Employees.CountAsync();
            for (int i = 0; i < empCount; i++)
            {
                var monthlySalary = new Models.MonthlySalary()
                {

                };
            }
            return Ok();
        }
    }
}
