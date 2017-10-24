using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class FuelExpense
    {
        public int Id { get; set; }

        public Employee Employee { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public Years Years { get; set; }
        [ForeignKey("Years")]
        public int YearsId { get; set; }

        public Months Months { get; set; }
        [ForeignKey("Months")]
        public int MonthsId { get; set; }

        public int FuelPrice { get; set; }

    }
}