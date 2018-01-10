using ERP.Models;
using ERP.ViewModels;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERP.Controllers.Api.Billing.Billing_Projects
{
    public class BillingOneTimeProjectsController : ApiController
    {
        private ApplicationDbContext Db;
        public BillingOneTimeProjectsController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> Get()
        {
            
            var oneTimeProjects = await Db.BillingOneTime.Include(p => p.Project).Where(e=>e.Project.ProjectBillingTypeId==1).ToListAsync();
            return Ok(oneTimeProjects);
        }
        [HttpPost]
        async public Task<IHttpActionResult> Update(UpdateBilling billingOneTime)
        {
            var SpecificBill = await Db.BillingOneTime.SingleOrDefaultAsync(e => e.Id == billingOneTime.Id);

            SpecificBill.AmountPaid = SpecificBill.AmountPaid + billingOneTime.AmountPaid;
            SpecificBill.Tax = SpecificBill.Tax + billingOneTime.Tax;
            SpecificBill.RemainingArrears = SpecificBill.OneTimeAmount - SpecificBill.AmountPaid - SpecificBill.Tax;

            var billing = await Db.BillingOneTime.SingleOrDefaultAsync(e => e.Id == billingOneTime.Id);
            var project = await Db.Projects.SingleOrDefaultAsync(i => i.Id == billing.ProjectId);
            var comissionEmployee = (await Db.ProjectComission.SingleOrDefaultAsync(e => e.Id == billing.ProjectComissionId)).EmployeeId;

            var billHistory = new OneTimeHistoryDetails()
            {
                BillingOneTimeId = billingOneTime.Id,
                AmountAdded = billingOneTime.AmountPaid,
                TaxAdded = billingOneTime.Tax,
                Date = DateTime.Now.Date

            };

            var comissionAdd = new ProjectComission()
            {
                EmployeeId = comissionEmployee,
                Date = DateTime.Now.Date,
                ComissionAmount = (billingOneTime.AmountPaid * project.ComissionPercentage) / 100,
                ProjectId = project.Id
            };


            Db.ProjectComission.Add(comissionAdd);
            Db.OneTimeHistoryDetails.Add(billHistory);
            await Db.SaveChangesAsync();

            return Ok();


            //await Db.SaveChangesAsync();

            //return Ok();
        }
    }
}
