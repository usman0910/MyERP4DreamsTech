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
    public class BillingQuaterlyProjectsController : ApiController
    {
        private ApplicationDbContext Db;
        public BillingQuaterlyProjectsController()
        {
            Db = new ApplicationDbContext();
        }
        async public Task<IHttpActionResult> Get()
        {
            var quaterlyProjects = await Db.Projects.Where(p => p.ProjectBillingTypeId == 3).ToListAsync();

            return Ok(quaterlyProjects);
        }
        [HttpPost]
        async public Task<IHttpActionResult> Update(UpdateBilling billingQuaterly)
        {
            var SpecificBill = await Db.BillingQuaterly.SingleOrDefaultAsync(e => e.Id == billingQuaterly.Id);

            SpecificBill.AmountPaid = SpecificBill.AmountPaid + billingQuaterly.AmountPaid;
            SpecificBill.Tax = SpecificBill.Tax + billingQuaterly.Tax;
            SpecificBill.RemainingArrears = SpecificBill.TotalAmountToPay - SpecificBill.AmountPaid- SpecificBill.Tax;

            var billing = await Db.BillingQuaterly.SingleOrDefaultAsync(e => e.Id == billingQuaterly.Id);
            var project = await Db.Projects.SingleOrDefaultAsync(i => i.Id == billing.ProjectId);
            var comissionEmployee = (await Db.ProjectComission.SingleOrDefaultAsync(e => e.Id == billing.ProjectComissionId)).EmployeeId;

            var billHistory = new QuaterlyHistoryDetails()
            {
                BillingQuaterlyId = billingQuaterly.Id,
                AmountAdded = billingQuaterly.AmountPaid,
                TaxAdded = billingQuaterly.Tax,
                Date = DateTime.Now.Date

            };

            var comissionAdd = new ProjectComission()
            {
                EmployeeId = comissionEmployee,
                Date = DateTime.Now.Date,
                ComissionAmount = (billingQuaterly.AmountPaid * project.ComissionPercentage) / 100,
                ProjectId = project.Id
            };


            Db.ProjectComission.Add(comissionAdd);
            Db.QuaterlyHistoryDetails.Add(billHistory);
            await Db.SaveChangesAsync();

            return Ok();

            //var billing = await Db.BillingQuaterly.SingleOrDefaultAsync(e => e.Id == billingQuaterly.Id);

            //var comissionProjectUpdate = await Db.ProjectComission.SingleOrDefaultAsync(e => e.Id == billing.ProjectComissionId);

            //comissionProjectUpdate.Date = DateTime.Now.Date;

            //var projectComissionPercentage = (await Db.Projects.SingleOrDefaultAsync(i => i.Id == billing.ProjectId)).ComissionPercentage;

            //comissionProjectUpdate.ComissionAmount = (billingQuaterly.AmountPaid * projectComissionPercentage) / 100;

            //await Db.SaveChangesAsync();

            //return Ok();
        }
    }
}
