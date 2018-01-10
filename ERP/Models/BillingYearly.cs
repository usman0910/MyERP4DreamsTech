using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class BillingYearly
    {
        public int Id { get; set; }

        public Project Project { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        public long YearlyAmount { get; set; }

        public bool Editable { get; set; }

        public long Tax { get; set; }

        public long Arrears { get; set; }

        public long TotalAmountToPay { get; set; }

        public long AmountPaid { get; set; }

        public long RemainingArrears { get; set; }

        public ProjectComission ProjectComission { get; set; }
        [ForeignKey("ProjectComission")]
        public int ProjectComissionId { get; set; }
    }
}