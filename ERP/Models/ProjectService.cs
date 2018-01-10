using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class ProjectService
    {
        public int Id { get; set; }

        public int VisitCharges { get; set; }

        public int EquipmentRepairCharges { get; set; }

        public int EquipmentReplacementCharges { get; set; }

        public int TowerPaintAndMaintenanceCharges { get; set; }

        [Required]
        [Range(-100, 100, ErrorMessage = "Can only be between 100 .. -100")]
        public float SignalStrength { get; set; }

        public Project Project { get; set; }
        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public bool IsFirstTime { get; set; }

        public int EquipmentInstallationCharges { get; set; }

        public int OtherCharges { get; set; }

        public DateTime Date { get; set; }

    }
}