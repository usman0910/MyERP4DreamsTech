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
            var BillingTypes = await Db.ProjectBillingTypes.ToListAsync();
            var employees = await Db.Employees.Where(e => e.DesignationId == 2).ToListAsync();
            var status = await Db.BillingStatus.ToListAsync();

            var ProjectVM = new ProjectRegisterGetVM()
            {
                ProjectBillingTypes = BillingTypes,
                Employees = employees,
                BillingStatuses = status

            };

            return Ok(ProjectVM);

        }

        [HttpPost]
        async public Task<IHttpActionResult> New(ProjectRegisterPostVM projectPost)
        {

            Db.Projects.Add(projectPost.Project);
            Db.Clients.Add(projectPost.Client);
            Db.ProjectComission.Add(projectPost.ProjectComission);

            if (projectPost.Project.ProjectBillingTypeId == 1)
            {
                var billOneTime = new BillingOneTime()
                {
                    BillingStatusId = projectPost.Project.BillingStatusId
                };
                Db.BillingOneTime.Add(billOneTime);
            }
            else if (projectPost.Project.ProjectBillingTypeId == 2)
            {

                if (projectPost.Project.StartingDate.Date.Month < DateTime.Now.Month)
                {
                    var testMonths = (DateTime.Now).Subtract(projectPost.Project.StartingDate);
                    var years = testMonths.Days / 365;
                    var test2 = testMonths.Days - (years * 365);
                    var month2 = test2 / 30;
                    var count = (years*12) + (month2);
                    DateTime teeeet = projectPost.Project.StartingDate.AddMonths(1);
                    for (int i = 0; i < count; i++)
                    {
                        var billMonthly2 = new BillingMonthly()
                        {
                            BillingStatusId = projectPost.Project.BillingStatusId,
                            From = projectPost.Project.StartingDate.AddMonths(i),
                            To = teeeet.AddMonths(i)
                        };
                        Db.BillingMonthly.Add(billMonthly2);
                    }

                    
                }
                else
                {
                    var billMonthly = new BillingMonthly()
                    {
                        BillingStatusId = projectPost.Project.BillingStatusId,
                        From = projectPost.Project.StartingDate,
                        To = projectPost.Project.StartingDate.AddMonths(1)
                    };
                    Db.BillingMonthly.Add(billMonthly);
                }
                
            }
            else if (projectPost.Project.ProjectBillingTypeId == 3)
            {
                var billQuaterly = new BillingQuaterly()
                {
                    BillingStatusId = projectPost.Project.BillingStatusId,
                    From = projectPost.Project.StartingDate,
                    To = projectPost.Project.StartingDate.AddMonths(3)
                };
                Db.BillingQuaterly.Add(billQuaterly);
            }

            else if (projectPost.Project.ProjectBillingTypeId == 4)
            {
                var billyearly = new BillingYearly()
                {
                    BillingStatusId = projectPost.Project.BillingStatusId,
                    From = projectPost.Project.StartingDate,
                    To = projectPost.Project.StartingDate.AddYears(1)
                };
                Db.BillingYearly.Add(billyearly);
            }

            await Db.SaveChangesAsync();
            var IdData = (await Db.Projects.SingleOrDefaultAsync(p => p.Name == projectPost.Project.Name)).Id;


            return Ok(IdData);

        }

    }
}
