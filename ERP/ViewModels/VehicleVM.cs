using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.ViewModels
{
    public class VehicleVM
    {
        public VehicleRecord Vehicle { get; set; }
        public IEnumerable<VehicleType> VehicleTypes { get; set; }

    }
}