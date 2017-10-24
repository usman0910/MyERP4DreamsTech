using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class ProjectService
    {
        public int Id { get; set; }
        public int VisitCharges { get; set; }
        public int EquipmentRepairCharges { get; set; }
        public int EquipmentReplacementCharges { get; set; }
        public int TowerPaintAndMaintenanceCharges { get; set; }

    }
}