using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class MonthlySalary
    {
        public int Id { get; set; }

        public Employee Employee { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public string Month { get; set; }

        public long BasicSalary { get; set; }

        public string Year { get; set; }

        public long TotalComission { get; set; }

        public double TotalMonthSalary { get; set; }

        public int Advance { get; set; }

        public int FuelExpence { get; set; }

        public SalaryStatus SalaryStatus { get; set; }
        [ForeignKey("SalaryStatus")]
        public int SalaryStatusId { get; set; }


    }
}