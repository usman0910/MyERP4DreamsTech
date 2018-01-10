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

        public string WorkingLocationA { get; set; }
        
        public DateTime StartingDate { get; set; }

        public string SpokePersonName { get; set; }

        public string WorkingLocationB { get; set; }

        public long BillingAmount { get; set; }

        public Client Client { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public long Arrears { get; set; }
        [Range(0, 100, ErrorMessage = "Can only be between 0 and 100")]
        public byte ComissionPercentage { get; set; }
        
        public string SpokePersonContactNumber { get; set; }

        public ProjectBillingType ProjectBillingType { get; set; }
        [ForeignKey("ProjectBillingType")]
        public int ProjectBillingTypeId { get; set; }

    }

}