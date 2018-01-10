using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class MonthlyHistoryDetails
    {
        public int Id { get; set; }

        public BillingMonthly BillingMonthly { get; set; }
        [ForeignKey("BillingMonthly")]
        public int BillingMonthlyId { get; set; }

        public DateTime Date { get; set; }

        public long AmountAdded { get; set; }

        public int TaxAdded { get; set; }

    }
}