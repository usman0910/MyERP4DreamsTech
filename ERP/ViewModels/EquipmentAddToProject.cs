using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.ViewModels
{
    public class EquipmentAddToProject
    {
        public IEnumerable<Equipment> Equipments { get; set; }
        public IEnumerable<EquipmentType> EquipmentTypes { get; set; }
        public IEnumerable<Project> Projects { get; set; }
    }
}