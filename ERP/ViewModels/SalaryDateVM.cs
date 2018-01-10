using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.ViewModels
{
    public class SalaryDateVM
    {
        public Months Month { get; set; }
        public Years Year { get; set; }
        public string M { get; set; }
        public string Y { get; set; }
    }
}