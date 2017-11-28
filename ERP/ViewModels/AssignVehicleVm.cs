using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.ViewModels
{
    public class AssignVehicleVm
    {
        public AssignVehicle AssignVehicle { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<VehicleRecord> Vehicles { get; set; }

    }
}