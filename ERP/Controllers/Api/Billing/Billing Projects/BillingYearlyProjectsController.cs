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
    public class BillingYearlyProjectsController : ApiController
    {
        private ApplicationDbContext Db;
        public BillingYearlyProjectsController()
        {
            Db = new ApplicationDbContext();
        }
        async public Task<IHttpActionResult> Get()
        {

            var yearlyProjects = await Db.Projects.Where(p => p.ProjectBillingTypeId == 4).ToListAsync();

            return Ok(yearlyProjects);

        }
        [HttpPost]
        async public Task<IHttpActionResult> Update(UpdateBilling billingYearly)
        {
            var SpecificBill = await Db.BillingYearly.SingleOrDefaultAsync(e => e.Id == billingYearly.Id);

            SpecificBill.AmountPaid = SpecificBill.AmountPaid + billingYearly.AmountPaid;
            SpecificBill.Tax = SpecificBill.Tax + billingYearly.Tax;
            SpecificBill.RemainingArrears = SpecificBill.TotalAmountToPay - SpecificBill.AmountPaid- SpecificBill.Tax;

            var billing = await Db.BillingYearly.SingleOrDefaultAsync(e => e.Id == billingYearly.Id);
            var project = await Db.Projects.SingleOrDefaultAsync(i => i.Id == billing.ProjectId);
            var comissionEmployee = (await Db.ProjectComission.SingleOrDefaultAsync(e => e.Id == billing.ProjectComissionId)).EmployeeId;

            var billHistory = new YearlyHistoryDetails()
            {
                BillingYearlyId = billingYearly.Id,
                AmountAdded = billingYearly.AmountPaid,
                TaxAdded = billingYearly.Tax,
                Date = DateTime.Now.Date

            };

            var comissionAdd = new ProjectComission()
            {
                EmployeeId = comissionEmployee,
                Date = DateTime.Now.Date,
                ComissionAmount = (billingYearly.AmountPaid * project.ComissionPercentage) / 100,
                ProjectId = project.Id
            };


            Db.ProjectComission.Add(comissionAdd);
            Db.YearlyHistoryDetails.Add(billHistory);
            await Db.SaveChangesAsync();

            return Ok();

            //await Db.SaveChangesAsync();

            //return Ok();
        }
    }
}
