using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.ViewModels
{
    public class SalaryVM
    {
        public Months Month { get; set; }
        public Years Year { get; set; }
        public MonthlySalary MonthlySalary { get; set; }
        public IEnumerable<Months> Months { get; set; }
        public IEnumerable<Years> Years { get; set; }
        


    }
}