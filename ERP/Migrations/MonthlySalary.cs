using ERP.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Migrations
{
    public class MonthlySalary
    {
        public int Id { get; set; }

        public Employee Employee { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public AdvanceSalary AdvanceSalary { get; set; }
        [ForeignKey("AdvanceSalary")]
        public int AdvanceSalaryId { get; set; }

        public ProjectComission ProjectComission { get; set; }
        [ForeignKey("ProjectComission")]
        public int ProjectComissionId { get; set; }

        public FuelExpense FuelExpense { get; set; }
        [ForeignKey("FuelExpense")]
        public int FuelExpenseId { get; set; }

        public Years Year { get; set; }
        [ForeignKey("Years")]
        public int YearsId { get; set; }

        public Months Month { get; set; }
        [ForeignKey("Months")]
        public int MonthsId { get; set; }

        public SalaryStatus SalaryStatus { get; set; }
        [ForeignKey("SalaryStatus")]
        public int SalaryStatusId { get; set; }

        public int OverAllSalary { get; set; }



    }
}