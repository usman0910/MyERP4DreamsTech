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
    public class GetDateForComplaintManagementController : ApiController
    {
        private ApplicationDbContext Db;

        public GetDateForComplaintManagementController()
        {
            Db = new ApplicationDbContext();
        }
        [HttpGet]
        async public Task<IHttpActionResult> Get(int Id)
        {
            var complaintData = await Db.ComplaintManagements.SingleOrDefaultAsync(e=>e.Id==Id);
            var comVm = new ComplaintVm2()
            {
                ComplaintDate=complaintData.ComplaintEntertainedDate,
                ProId=complaintData.ProjectId
            };
            return Ok(comVm);
        }
    }
}
