using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.ViewModels
{
    public class AdvanceSalaryVM
    {
        public AdvanceSalary AdvanceSalary { get; set; }
        public FuelExpense FuelExpense { get; set; }
        public IEnumerable<Employee> Employees { get; set; }

    }
}