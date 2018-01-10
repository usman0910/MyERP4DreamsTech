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

namespace ERP.Controllers.Api.Billing.Billing_Projects
{
    public class BillingMonthlyProjectsController : ApiController
    {
        private ApplicationDbContext Db;
        public BillingMonthlyProjectsController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> Get()
        {
            var monthlyProjects = await Db.Projects.Include(c=>c.Client).Where(p => p.ProjectBillingTypeId == 2).ToListAsync();

            return Ok(monthlyProjects);
        }
        [HttpPost]
        async public Task<IHttpActionResult> Update(UpdateBilling billingMonthly)
        {
            var SpecificBill = await Db.BillingMonthly.SingleOrDefaultAsync(e=>e.Id==billingMonthly.Id);

            SpecificBill.AmountPaid = SpecificBill.AmountPaid + billingMonthly.AmountPaid;
            SpecificBill.Tax = SpecificBill.Tax + billingMonthly.Tax;
            SpecificBill.RemainingArrears = SpecificBill.TotalAmountToPay - SpecificBill.AmountPaid - SpecificBill.Tax;

            

            var billing = await Db.BillingMonthly.SingleOrDefaultAsync(e=>e.Id== billingMonthly.Id);
            var project = await Db.Projects.SingleOrDefaultAsync(i => i.Id == billing.ProjectId);
            var comissionEmployee = (await Db.ProjectComission.SingleOrDefaultAsync(e => e.Id == billing.ProjectComissionId)).EmployeeId;

            var billHistory = new MonthlyHistoryDetails()
            {
                BillingMonthlyId = billingMonthly.Id,
                AmountAdded = billingMonthly.AmountPaid,
                TaxAdded = billingMonthly.Tax,
                Date = DateTime.Now.Date

            };

            var comissionAdd = new ProjectComission()
            {
                EmployeeId = comissionEmployee,
                Date= DateTime.Now.Date,
                ComissionAmount= (billingMonthly.AmountPaid * project.ComissionPercentage) / 100,
                ProjectId= project.Id
            };
            

            Db.ProjectComission.Add(comissionAdd);
            Db.MonthlyHistoryDetails.Add(billHistory);

            await Db.SaveChangesAsync();

            return Ok();
        }
    }
}
