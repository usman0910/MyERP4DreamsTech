using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.ViewModels
{
    public class ProjectDetailsVM
    {
        public Project Project { get; set; }
        public ProjectComission ProjectComission { get; set; }
        public IEnumerable<StockEquipmentOut> StockEquipmentOuts { get; set; }
        public IEnumerable<StockCableOut> StockCableOuts { get; set; }
    }
}