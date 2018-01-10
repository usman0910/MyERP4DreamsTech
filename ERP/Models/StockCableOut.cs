using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class StockCableOut
    {
        public int Id { get; set; }

        public CableRoll CableRoll { get; set; }

        [ForeignKey("CableRoll")]
        public int CableRollId { get; set; }

        public int Totalfeets { get; set; }

        public Project Project { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public bool IsFirstTime { get; set; }

        public bool ForComplaintManagement { get; set; }

        public DateTime Date { get; set; }


    }
}