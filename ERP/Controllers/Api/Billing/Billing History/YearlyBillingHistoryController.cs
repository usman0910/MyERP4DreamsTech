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
    public class YearlyBillingHistoryController : ApiController
    {
        private ApplicationDbContext Db;
        public YearlyBillingHistoryController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> Get(int Id)
        {
            var LastToDate = Db.BillingYearly.ToList().LastOrDefault(e => e.ProjectId == Id);

            if (LastToDate.To.Date <= DateTime.Now.Date)
            {
                LastToDate.Editable = false;

                var projectAmountToPay = Db.Projects.SingleOrDefault(p => p.Id == Id).BillingAmount;
                var billingYearly = new BillingYearly()
                {
                    From = LastToDate.To.Date,
                    To = LastToDate.To.Date.AddYears(1),
                    ProjectId = Id,
                    Editable = true,
                    Arrears = LastToDate.RemainingArrears,
                    YearlyAmount = projectAmountToPay,
                    TotalAmountToPay = LastToDate.RemainingArrears + projectAmountToPay,
                    RemainingArrears = LastToDate.RemainingArrears + projectAmountToPay - 0

                };
                Db.BillingYearly.Add(billingYearly);

                var comissionEmployee = (await Db.ProjectComission.SingleOrDefaultAsync(p => p.Id == Id)).EmployeeId;
                var comissionQuaterly = new ProjectComission()
                {
                    EmployeeId = comissionEmployee,
                    Date = LastToDate.To.Date,
                    ComissionAmount = 0,
                    ProjectId = Id
                };
                Db.ProjectComission.Add(comissionQuaterly);
                await Db.SaveChangesAsync();
            }
            var yearlyHistory = await Db.BillingYearly.Where(i => i.ProjectId == Id).ToListAsync();
            return Ok(yearlyHistory);
        }
    }
}
