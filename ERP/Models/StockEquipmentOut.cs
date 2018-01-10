using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class StockEquipmentOut
    {
        public int Id { get; set; }

        public Equipment Equipment { get; set; }

        [ForeignKey("Equipment")]
        public int EquipmentId { get; set; }

        public EquipmentType EquipmentType { get; set; }
        
        [ForeignKey("EquipmentType")]
        public int EquipmentTypeId { get; set; }

        public int Quantity { get; set; }

        public Project Project { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public bool IsFirstTime { get; set; }

        public bool ForComplaintManagement { get; set; }

        public DateTime Date { get; set; }

    }
}