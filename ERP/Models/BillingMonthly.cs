using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class BillingMonthly
    {
        public int Id { get; set; }

        public Project Project { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public BillingStatus BillingStatus { get; set; }
        [ForeignKey("BillingStatus")]
        public int BillingStatusId { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}