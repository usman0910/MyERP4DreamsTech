using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class StockCableIn
    {
        public int Id { get; set; }

        public CableRoll CableRoll { get; set; }

        [ForeignKey("CableRoll")]
        public int CableRollId { get; set; }

        public int Totalfeets { get; set; }
    }
}