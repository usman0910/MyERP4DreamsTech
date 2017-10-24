using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class AssignVehicle
    {
        public int Id { get; set; }

        public Employee Employee { get; set; }
        [ForeignKey("Employee")]
        public int EmployeeId { get; set; }

        public VehicleRecord VehicleRecord { get; set; }
        [ForeignKey("VehicleRecord")]
        public int VehicleRecordId { get; set; }

    }
}