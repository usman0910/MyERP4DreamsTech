using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERP.Controllers.Api.Billing.Billing_History
{
    public class MonthlyBillingHistoryController : ApiController
    {
        private ApplicationDbContext Db;
        public MonthlyBillingHistoryController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> Get(int Id)
        {

            var LastToDate = Db.BillingMonthly.ToList().LastOrDefault(e => e.ProjectId == Id);

            if (LastToDate.To.Date <= DateTime.Now.Date)
            {
                LastToDate.Editable = false;

                var projectAmountToPay = (await Db.Projects.SingleOrDefaultAsync(p => p.Id == Id)).BillingAmount;
                var billingMonthly = new BillingMonthly()
                {
                    From = LastToDate.To.Date,
                    To = LastToDate.To.Date.AddMonths(1),
                    ProjectId = Id,
                    Arrears = LastToDate.RemainingArrears,
                    MonthlyAmount = projectAmountToPay,
                    AmountPaid = 0,
                    Editable = true,
                    TotalAmountToPay = LastToDate.RemainingArrears + projectAmountToPay,
                    RemainingArrears = LastToDate.RemainingArrears + projectAmountToPay - 0
                     
                };
                var comissionEmployee = (await Db.ProjectComission.FirstOrDefaultAsync(p => p.ProjectId == Id)).EmployeeId;
                var comissionMonthly = new ProjectComission()
                {
                    EmployeeId=comissionEmployee,
                    Date= LastToDate.To.Date,
                    ComissionAmount = 0,
                    ProjectId=Id
                };
                Db.BillingMonthly.Add(billingMonthly);
                Db.ProjectComission.Add(comissionMonthly);
                await Db.SaveChangesAsync();
            }
            var monthlyHistory = await Db.BillingMonthly.Where(i => i.ProjectId == Id).Include(p=>p.Project).ToListAsync();
            return Ok(monthlyHistory);

        }
    }
}
