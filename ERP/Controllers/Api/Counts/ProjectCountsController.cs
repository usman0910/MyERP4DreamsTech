using ERP.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace ERP.Controllers.Api.Counts
{
    public class ProjectCountsController : ApiController
    {
        private ApplicationDbContext Db;

        public ProjectCountsController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> AllCounts()
        {
            var totalProjects = await Db.Projects.CountAsync();
            var totalClients = await Db.Clients.CountAsync();
            var totalOneTimeProjects = await Db.Projects.CountAsync(e=>e.ProjectBillingTypeId==1);
            var totalMonthlyProjects = await Db.Projects.CountAsync(e => e.ProjectBillingTypeId == 2);
            var totalQuaterlyProjects = await Db.Projects.CountAsync(e => e.ProjectBillingTypeId == 3);
            var totalYearlyProjects = await Db.Projects.CountAsync(e => e.ProjectBillingTypeId == 4);

            var myCounts = new int[6];
            myCounts[0] = totalProjects;
            myCounts[1] = totalOneTimeProjects;
            myCounts[2] = totalMonthlyProjects;
            myCounts[3] = totalQuaterlyProjects;
            myCounts[4] = totalYearlyProjects;
            myCounts[5] = totalClients;
            
            return Ok(myCounts);
        }
    }
}
