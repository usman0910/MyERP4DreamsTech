using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class ProjectComission
    {
        public int Id { get; set; }

        public Employee Employee { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public DateTime Date { get; set; }

        public long ComissionAmount { get; set; }

        public Project Project { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

    }
}