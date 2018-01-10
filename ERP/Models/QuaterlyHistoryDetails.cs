using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class QuaterlyHistoryDetails
    {
        public int Id { get; set; }

        public BillingQuaterly BillingQuaterly { get; set; }
        [ForeignKey("BillingQuaterly")]
        public int BillingQuaterlyId { get; set; }

        public DateTime Date { get; set; }

        public long AmountAdded { get; set; }

        public int TaxAdded { get; set; }
    }
}