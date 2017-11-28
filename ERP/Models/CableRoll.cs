using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class CableRoll
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public int StockAvailable { get; set; }
        public float FeetPrice { get; set; }

    }
}