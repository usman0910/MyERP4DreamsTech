using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class Project
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string WorkingLocation { get; set; }

        public DateTime StartingDate { get; set; }

        public string SpokePersonName { get; set; }

        public int BillingAmount { get; set; }

        public string SpokePersonContactNumber { get; set; }

        public ProjectBillingType ProjectBillingType { get; set; }
        [ForeignKey("ProjectBillingType")]
        public int ProjectBillingTypeId { get; set; }

    }

}