using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class OneTimeHistoryDetails
    {
        public int Id { get; set; }

        public BillingOneTime BillingOneTime { get; set; }
        [ForeignKey("BillingOneTime")]
        public int BillingOneTimeId { get; set; }

        public DateTime Date { get; set; }

        public long AmountAdded { get; set; }

        public int TaxAdded { get; set; }
    }
}