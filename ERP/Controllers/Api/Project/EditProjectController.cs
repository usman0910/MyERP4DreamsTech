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

namespace ERP.Controllers.Api.Project
{
    public class EditProjectController : ApiController
    {
        private ApplicationDbContext Db;

        public EditProjectController()
        {
            Db = new ApplicationDbContext();
        }

        [HttpGet]
        async public Task<IHttpActionResult> Edit(int Id)
        {
            var project = await Db.Projects.Include(b=>b.ProjectBillingType).SingleOrDefaultAsync(p => p.Id == Id);
            var client = await Db.Clients.SingleOrDefaultAsync(c => c.ProjectId == Id);
            var projectComission = await Db.ProjectComission.Include(e=>e.Employee).SingleOrDefaultAsync(p => p.ProjectId == Id);


            var ProjectVM = new ProjectRegisterPostVM()
            {
                Project = project,
                Client = client,
                ProjectComission = projectComission

            };

            return Ok(ProjectVM);

        }

        [HttpPost]
        async public Task<IHttpActionResult> Edit(ProjectRegisterPostVM projectPost)
        {

            var project = await Db.Projects.SingleOrDefaultAsync(p=>p.Id==projectPost.Project.Id);
            var client = await Db.Clients.SingleOrDefaultAsync(c=>c.ProjectId== projectPost.Project.Id);

            project.Name = projectPost.Project.Name;
            project.WorkingLocation = projectPost.Project.WorkingLocation;
            project.SpokePersonName = projectPost.Project.SpokePersonName;
            project.SpokePersonContactNumber = projectPost.Project.SpokePersonContactNumber;

            client.CompanyName = projectPost.Client.CompanyName;
            client.CompanyEmail = projectPost.Client.CompanyEmail;
            client.OfficeLocation = projectPost.Client.OfficeLocation;
            client.CompanyContactNumber = projectPost.Client.CompanyContactNumber;


            await Db.SaveChangesAsync();

            return Ok();

        }
    }
}
