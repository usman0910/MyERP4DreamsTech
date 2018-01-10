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

namespace ERP.Controllers.Api.ComplaintMangement
{
    public class AddComplaintController : ApiController
    {
        private ApplicationDbContext Db;

        public AddComplaintController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> AddNew()
        {
            var projects = await Db.Projects.Where(e => e.ProjectBillingTypeId == 2 || e.ProjectBillingTypeId == 3 || e.ProjectBillingTypeId == 4).ToListAsync();
            var employees = await Db.Employees.Where(e=>e.DesignationId==1).ToListAsync();

            var complaintVm = new ComplaintManagementVM()
            {
                Projects= projects,
                Employees=employees
            };
            return Ok(complaintVm);
        }

        [HttpPost]
        async public Task<IHttpActionResult> AddNew(ComplaintManagement complaintManagement)
        {
            Db.ComplaintManagements.Add(complaintManagement);
            await Db.SaveChangesAsync();

            var ComId = (await Db.ComplaintManagements.FirstOrDefaultAsync(e => e.ProjectId == complaintManagement.ProjectId && e.ComplaintDate == complaintManagement.ComplaintDate && e.ComplaintEntertainedDate == complaintManagement.ComplaintEntertainedDate)).Id;

            return Ok(ComId);
        }

    }
}
