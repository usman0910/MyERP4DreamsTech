using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class ComplaintManagement
    {
        public int Id { get; set; }
        
        public Project Project { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public Client Client { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public DateTime ComplaintDate { get; set; }

        public DateTime ComplaintEntertainedDate { get; set; }

        public Employee Employee { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public int SignalStrengthBefore { get; set; }

        public int SignalStrengthAfter { get; set; }

        public string IssueDetails { get; set; }

        public string IssueResolvedDetails { get; set; }

    }
}