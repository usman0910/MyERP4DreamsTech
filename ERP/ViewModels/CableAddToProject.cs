using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.ViewModels
{
    public class CableAddToProject
    {
        public IEnumerable<CableRoll> Cables { get; set; }
        public IEnumerable<Project> Projects { get; set; }
    }
}