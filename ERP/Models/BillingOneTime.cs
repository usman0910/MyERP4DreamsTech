using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class BillingOneTime
    {
        public int Id { get; set; }

        public Project Project { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public BillingStatus BillingStatus { get; set; }
        [ForeignKey("BillingStatus")]
        public int BillingStatusId { get; set; }
        
    }
}