using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.ViewModels
{
    public class ComplaintDetailsVM
    {
        public ComplaintManagement Complaint { get; set; }
        public IEnumerable<StockEquipmentOut> StockEquipmentsOut { get; set; }
        public IEnumerable<StockCableOut> StockCablesOut { get; set; }
    }
}