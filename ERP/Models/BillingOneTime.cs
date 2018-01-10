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

        public ProjectComission ProjectComission { get; set; }
        [ForeignKey("ProjectComission")]
        public int ProjectComissionId { get; set; }

        public long Tax { get; set; }

        public long OneTimeAmount { get; set; }

        public long AmountPaid { get; set; }

        public long RemainingArrears { get; set; }

    }
}