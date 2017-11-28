using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class Equipment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public int StockAvailable { get; set; }
        public float UnitPrice { get; set; }

    }
}