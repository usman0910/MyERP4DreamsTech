using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class StockEquipmentIn
    {
        public int Id { get; set; }

        public Equipment Equipment { get; set; }

        [ForeignKey("Equipment")]
        public int EquipmentId { get; set; }

        public EquipmentType EquipmentType { get; set; }
        
        [ForeignKey("EquipmentType")]
        public int EquipmentTypeId { get; set; }

        public int Quantity { get; set; }



    }
}