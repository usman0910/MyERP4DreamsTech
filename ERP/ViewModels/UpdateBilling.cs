using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.ViewModels
{
    public class UpdateBilling
    {
        public int Id { get; set; }
        public long AmountPaid { get; set; }
        public int Tax { get; set; }

    }
}