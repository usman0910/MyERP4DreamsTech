using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class ProjectSupplies
    {
        public int Id { get; set; }

        public StockCableOut StockCableOut { get; set; }
        [ForeignKey("StockCableOut")]
        public int StockCableOutId { get; set; }

        public StockEquipmentOut StockEquipmentOut { get; set; }
        [ForeignKey("StockEquipmentOut")]
        public int StockEquipmentOutId { get; set; }

    }
}