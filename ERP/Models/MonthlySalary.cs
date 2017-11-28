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

        public DateTime Month { get; set; }

        public DateTime Year { get; set; }
        
        public double TotalMonthSalary { get; set; }

        public double Advance { get; set; }

        public double FuelExpence { get; set; }

        public SalaryStatus SalaryStatus { get; set; }
        [ForeignKey("SalaryStatus")]
        public int SalaryStatusId { get; set; }


    }
}