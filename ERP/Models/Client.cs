using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class Client
    {
        public int Id { get; set; }

        public string CompanyName { get; set; }

        public string CompanyContactNumber { get; set; }

        public string CompanyEmail { get; set; }

        public string OfficeLocation { get; set; }

        public Project Project { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

    }
}