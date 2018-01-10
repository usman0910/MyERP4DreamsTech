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
    public class GenerateCurrentMonthSalaryController : ApiController
    {
        private ApplicationDbContext Db;

        public GenerateCurrentMonthSalaryController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpPost]
        async public Task<IHttpActionResult> CurrentMonthSalary(SalaryDateVM salaryDate)
       {
            var monthlysalary = Db.MonthlySalaries.Count(d => d.Month == salaryDate.Month.Month && d.Year == salaryDate.Year.Year);

            if (monthlysalary == 0)
            {
                var employees = await Db.Employees.ToListAsync();
                foreach (var employee in employees)
                {
                    var advance = 0;
                    var fuelExpence = 0;
                    long comission =0;
                    var basicsalary = 0.0;
                    var checkAdvance = await Db.AdvanceSalary.CountAsync(e => e.EmployeeId == employee.Id && e.GivenDate.Month == salaryDate.Month.Id && e.GivenDate.Year == salaryDate.Year.Id);
                    if (checkAdvance > 0)
                    {
                        advance = (await Db.AdvanceSalary.Where(e => e.EmployeeId == employee.Id && e.GivenDate.Month == salaryDate.Month.Id && e.GivenDate.Year == salaryDate.Year.Id).ToListAsync()).Sum(e => e.AdvanceAmount);

                    }
                    var CheckFuelExpence = await Db.FuelExpense.CountAsync(e => e.EmployeeId == employee.Id && e.Date.Month == salaryDate.Month.Id && e.Date.Year == salaryDate.Year.Id);
                    if (CheckFuelExpence > 0)
                    {
                        fuelExpence = (await Db.FuelExpense.Where(e => e.EmployeeId == employee.Id && e.Date.Month == salaryDate.Month.Id && e.Date.Year == salaryDate.Year.Id).ToListAsync()).Sum(f => f.FuelPrice);

                    }

                    basicsalary = (await Db.Employees.SingleOrDefaultAsync(e => e.Id == employee.Id)).BasicSalary;

                    var checkComission = await Db.ProjectComission.CountAsync(e => e.EmployeeId == employee.Id && e.Date.Month == salaryDate.Month.Id && e.Date.Year == salaryDate.Year.Id);
                    if (checkComission > 0)
                    {
                        comission = (await Db.ProjectComission.Where(e => e.EmployeeId == employee.Id && e.Date.Month == salaryDate.Month.Id && e.Date.Year == salaryDate.Year.Id).ToListAsync()).Sum(e => e.ComissionAmount);
                    }

                    var monthlySalary = new Models.MonthlySalary()
                    {
                        EmployeeId = employee.Id,
                        Advance = advance,
                        FuelExpence = fuelExpence,
                        Month = salaryDate.Month.Month,
                        Year = salaryDate.Year.Year,
                        BasicSalary = Convert.ToInt64(basicsalary),
                        TotalComission = comission,
                        SalaryStatusId = 2,
                        TotalMonthSalary = basicsalary + fuelExpence + comission - advance


                    };

                    Db.MonthlySalaries.Add(monthlySalary);
                    await Db.SaveChangesAsync();
                }
                
            }


            return Ok();
        }
    }
}
