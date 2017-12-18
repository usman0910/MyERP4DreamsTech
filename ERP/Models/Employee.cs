using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class Employee
    {
        
        public int Id { get; set; }

        public string FullName { get; set; }

        public string CNIC { get; set; }

        public Designations Designations { get; set; }

        [ForeignKey("Designations")]
        public int DesignationId { get; set; }

        public double BasicSalary { get; set; }

        public int TotalComission { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime JoiningDate { get; set; }

        public string City { get; set; }

        public string PermanentAddress { get; set; }

        public string ContactNumber { get; set; }



    }
}