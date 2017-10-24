using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class AdvanceSalary
    {
        public int Id { get; set; }

        public Employee Employee { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public DateTime GivenDate { get; set; }

        public int AdvanceAmount { get; set; }

        public string Reason { get; set; }

        public int Status { get; set; }


    }
}