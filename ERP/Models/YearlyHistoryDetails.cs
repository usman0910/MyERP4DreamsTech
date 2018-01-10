using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class YearlyHistoryDetails
    {
        public int Id { get; set; }

        public BillingYearly BillingYearly { get; set; }
        [ForeignKey("BillingYearly")]
        public int BillingYearlyId { get; set; }

        public DateTime Date { get; set; }

        public long AmountAdded { get; set; }

        public int TaxAdded { get; set; }
    }
}