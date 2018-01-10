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
    public class QuaterlyBillingHistoryController : ApiController
    {
        private ApplicationDbContext Db;
        public QuaterlyBillingHistoryController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> Get(int Id)
        {
            var LastToDate = Db.BillingQuaterly.ToList().LastOrDefault(e => e.ProjectId == Id);

            if (LastToDate.To.Date <= DateTime.Now.Date)
            {
                LastToDate.Editable = false;

                var projectAmountToPay = Db.Projects.SingleOrDefault(p => p.Id == Id).BillingAmount;
                var billingQuaterly = new BillingQuaterly()
                {
                    From = LastToDate.To.Date,
                    To = LastToDate.To.Date.AddMonths(3),
                    ProjectId = Id,
                    Editable = true,
                    Arrears = LastToDate.RemainingArrears,
                    QuaterlyAmount = projectAmountToPay,
                    TotalAmountToPay = LastToDate.RemainingArrears + projectAmountToPay,
                    RemainingArrears = LastToDate.RemainingArrears + projectAmountToPay - 0

                };

                Db.BillingQuaterly.Add(billingQuaterly);

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
            var quaterlyHistory = await Db.BillingQuaterly.Where(i => i.ProjectId == Id).ToListAsync();
            return Ok(quaterlyHistory);
        }
    }
}
