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
                    var TotalSpan = (DateTime.Now).Subtract(projectPost.Project.StartingDate);
                    var years = TotalSpan.Days / 365;
                    var DaysWithOutYears = TotalSpan.Days - (years * 365);
                    var months = DaysWithOutYears / 30;
                    var TotalMonths = (years*12) + (months);
                    DateTime ToDate = projectPost.Project.StartingDate.AddMonths(1);
                    for (int i = 0; i < TotalMonths; i++)
                    {
                        var billMonthly = new BillingMonthly()
                        {
                            BillingStatusId = projectPost.Project.BillingStatusId,
                            From = projectPost.Project.StartingDate.AddMonths(i),
                            To = ToDate.AddMonths(i)
                        };
                        Db.BillingMonthly.Add(billMonthly);
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
                if (projectPost.Project.StartingDate.Date.Month < DateTime.Now.Month)
                {
                    var TotalSpan = (DateTime.Now).Subtract(projectPost.Project.StartingDate);
                    var years = TotalSpan.Days / 365;
                    var DaysWithOutYears = TotalSpan.Days - (years * 365);
                    var quaters = DaysWithOutYears / 90;
                    var TotalQuaters = (years * 4) + (quaters);
                    DateTime ToDate = projectPost.Project.StartingDate.AddMonths(3);
                    for (int i = 0; i < TotalQuaters; i++)
                    {
                        var billQuaterly = new BillingQuaterly()
                        {
                            BillingStatusId = projectPost.Project.BillingStatusId,
                            From = projectPost.Project.StartingDate.AddMonths(i*3),
                            To = ToDate.AddMonths(i*3)
                        };
                        Db.BillingQuaterly.Add(billQuaterly);
                    }
                }
                else
                {
                    var billQuaterly = new BillingQuaterly()
                    {
                        BillingStatusId = projectPost.Project.BillingStatusId,
                        From = projectPost.Project.StartingDate,
                        To = projectPost.Project.StartingDate.AddMonths(3)
                    };
                    Db.BillingQuaterly.Add(billQuaterly);
                }
                
            }

            else if (projectPost.Project.ProjectBillingTypeId == 4)
            {
                if (projectPost.Project.StartingDate.Date.Year < DateTime.Now.Year)
                {
                    var TotalSpan = (DateTime.Now).Subtract(projectPost.Project.StartingDate);
                    var years = TotalSpan.Days / 365;;
                    DateTime ToDate = projectPost.Project.StartingDate.AddYears(1);
                    for (int i = 0; i < years; i++)
                    {
                        var billYearly = new BillingYearly()
                        {
                            BillingStatusId = projectPost.Project.BillingStatusId,
                            From = projectPost.Project.StartingDate.AddYears(i),
                            To = ToDate.AddYears(i)
                        };
                        Db.BillingYearly.Add(billYearly);
                    }
                }
                else
                {
                    var billyearly = new BillingYearly()
                    {
                        BillingStatusId = projectPost.Project.BillingStatusId,
                        From = projectPost.Project.StartingDate,
                        To = projectPost.Project.StartingDate.AddYears(1)
                    };
                    Db.BillingYearly.Add(billyearly);
                }
                
            }

            await Db.SaveChangesAsync();
            var IdData = (await Db.Projects.SingleOrDefaultAsync(p => p.Name == projectPost.Project.Name)).Id;


            return Ok(IdData);

        }

    }
}
