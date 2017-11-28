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

            var ProjectVM = new ProjectRegisterGetVM()
            {
                ProjectBillingTypes = BillingTypes,
                Employees = employees

            };

            return Ok(ProjectVM);

        }

        [HttpPost]
        async public Task<IHttpActionResult> New(ProjectRegisterPostVM projectPost)
        {

            Db.Projects.Add(projectPost.Project);
            Db.Clients.Add(projectPost.Client);
            Db.ProjectComission.Add(projectPost.ProjectComission);
            
            if (projectPost.Project.ProjectBillingTypeId==1)
            {
                var billOneTime = new BillingOneTime()
                {
                    BillingStatusId = 2
                };
                Db.BillingOneTime.Add(billOneTime);
            }
            else if (projectPost.Project.ProjectBillingTypeId == 2)
            {
                var billMonthly = new BillingMonthly()
                {
                    BillingStatusId = 2,
                    From = projectPost.Project.StartingDate,
                    To = projectPost.Project.StartingDate.AddMonths(1)
                };
                Db.BillingMonthly.Add(billMonthly);
            }
            else if (projectPost.Project.ProjectBillingTypeId == 3)
            {
                var billQuaterly = new BillingQuaterly()
                {
                    BillingStatusId = 2,
                    From = projectPost.Project.StartingDate,
                    To = projectPost.Project.StartingDate.AddMonths(3)
                };
                Db.BillingQuaterly.Add(billQuaterly);
            }
            
            else if (projectPost.Project.ProjectBillingTypeId == 4)
            {
                var billyearly = new BillingYearly()
                {
                    BillingStatusId = 2,
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
