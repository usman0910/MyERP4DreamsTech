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

namespace ERP.Controllers.Api.New_Project
{
    public class NewProjectController : ApiController
    {
        private ApplicationDbContext Db;

        public NewProjectController()
        {
            Db = new ApplicationDbContext();
        }

        [HttpGet]
        async public Task<IHttpActionResult> New()
        {
            var employees = await Db.Employees.Where(e => e.DesignationId == 2).ToListAsync();
            var BillingTypes = await Db.ProjectBillingTypes.ToListAsync();
            var clients = await Db.Clients.ToListAsync();

            var ProjectVM = new ProjectRegisterGetVM()
            {
                ProjectBillingTypes = BillingTypes,
                Employees = employees,
                Clients=clients
            };

            return Ok(ProjectVM);

        }

        [HttpPost]
        async public Task<IHttpActionResult> New(ProjectRegisterPostVM projectPost)
        {

            Db.Projects.Add(projectPost.Project);
            Db.ProjectComission.Add(projectPost.ProjectComission);
            var emp = await Db.Employees.SingleOrDefaultAsync(e => e.Id == projectPost.ProjectComission.EmployeeId);

            if (projectPost.Project.ProjectBillingTypeId == 1)
            {
                var billOneTime = new BillingOneTime()
                {
                    OneTimeAmount = projectPost.Project.BillingAmount,
                    AmountPaid = projectPost.Project.Arrears,
                    Tax = projectPost.Tax,
                    RemainingArrears = projectPost.Project.BillingAmount - projectPost.Project.Arrears - projectPost.Tax


                };
                var billHistory = new OneTimeHistoryDetails()
                {
                    BillingOneTimeId = billOneTime.Id,
                    AmountAdded = projectPost.Project.Arrears,
                    TaxAdded = Convert.ToInt32(projectPost.Tax),
                    Date = projectPost.Project.StartingDate


                };
                Db.BillingOneTime.Add(billOneTime);
                Db.OneTimeHistoryDetails.Add(billHistory);
            }
            else if (projectPost.Project.ProjectBillingTypeId == 2)
            {
                var billMonthly = new BillingMonthly()
                {
                    From = projectPost.Project.StartingDate,
                    To = projectPost.Project.StartingDate.AddMonths(1),
                    MonthlyAmount = projectPost.Project.BillingAmount,
                    Arrears = 0,
                    Tax = projectPost.Tax,
                    Editable =true,
                    TotalAmountToPay = projectPost.Project.BillingAmount + 0,
                    AmountPaid = projectPost.Project.Arrears,
                    RemainingArrears = projectPost.Project.BillingAmount + 0 - projectPost.Project.Arrears - projectPost.Tax


                };
                var billHistory = new MonthlyHistoryDetails()
                {
                    BillingMonthlyId = billMonthly.Id,
                    AmountAdded = projectPost.Project.Arrears,
                    TaxAdded = Convert.ToInt32(projectPost.Tax),
                    Date = projectPost.Project.StartingDate
                    

                };
                Db.BillingMonthly.Add(billMonthly);
                Db.MonthlyHistoryDetails.Add(billHistory);

            }
            else if (projectPost.Project.ProjectBillingTypeId == 3)
            {
                var billQuaterly = new BillingQuaterly()
                {
                    From = projectPost.Project.StartingDate,
                    To = projectPost.Project.StartingDate.AddMonths(3),
                    QuaterlyAmount = projectPost.Project.BillingAmount,
                    Arrears = 0,
                    Tax = projectPost.Tax,
                    Editable = true,
                    TotalAmountToPay = projectPost.Project.BillingAmount + 0,
                    AmountPaid = projectPost.Project.Arrears,
                    RemainingArrears = projectPost.Project.BillingAmount + 0 - projectPost.Project.Arrears - projectPost.Tax
                };
                var billHistory = new QuaterlyHistoryDetails()
                {
                    BillingQuaterlyId = billQuaterly.Id,
                    AmountAdded = projectPost.Project.Arrears,
                    TaxAdded = Convert.ToInt32(projectPost.Tax),
                    Date = projectPost.Project.StartingDate


                };
                Db.BillingQuaterly.Add(billQuaterly);
                Db.QuaterlyHistoryDetails.Add(billHistory);

            }
            else if (projectPost.Project.ProjectBillingTypeId == 4)
            {
                var billyearly = new BillingYearly()
                {
                    From = projectPost.Project.StartingDate,
                    To = projectPost.Project.StartingDate.AddYears(1),
                    YearlyAmount = projectPost.Project.BillingAmount,
                    Arrears = 0,
                    Tax = projectPost.Tax,
                    Editable = true,
                    TotalAmountToPay = projectPost.Project.BillingAmount + 0,
                    AmountPaid = projectPost.Project.Arrears,
                    RemainingArrears = projectPost.Project.BillingAmount + 0 - projectPost.Project.Arrears - projectPost.Tax
                };
                var billHistory = new YearlyHistoryDetails()
                {
                    BillingYearlyId = billyearly.Id,
                    AmountAdded = projectPost.Project.Arrears,
                    TaxAdded = Convert.ToInt32(projectPost.Tax),
                    Date = projectPost.Project.StartingDate


                };
                Db.BillingYearly.Add(billyearly);
                Db.YearlyHistoryDetails.Add(billHistory);

            }

            await Db.SaveChangesAsync();
            var IdData = (await Db.Projects.SingleOrDefaultAsync(p => p.Name == projectPost.Project.Name && p.ClientId==projectPost.Project.ClientId)).Id;


            return Ok(IdData);

        }

    }
}
