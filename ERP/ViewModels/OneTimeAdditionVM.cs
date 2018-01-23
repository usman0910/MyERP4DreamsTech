using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.ViewModels
{
    public class OneTimeAdditionVM
    {
        public IEnumerable<StockEquipmentOut> EquipmentOuts { get; set; }
        public IEnumerable<StockCableOut> CablesOuts { get; set; }
        public IEnumerable<ProjectService> Services { get; set; }


    }
}