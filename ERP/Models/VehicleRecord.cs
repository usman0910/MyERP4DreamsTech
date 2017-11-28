using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class VehicleRecord
    {
        public int Id { get; set; }

        public VehicleType VehicleType { get; set; }
        [ForeignKey("VehicleType")]
        public int VehicleTypeId { get; set; }

        public VehicleStatus VehicleStatus { get; set; }
        [ForeignKey("VehicleStatus")]
        public int VehicleStatusId { get; set; }

        public string RegistrationNumber { get; set; }


    }
}