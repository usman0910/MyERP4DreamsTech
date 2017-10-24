using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ERP.Models
{
    public class Project
    {
        public int Id { get; set; }

        public Client Client { get; set; }
        [ForeignKey("Client")]
        public int ClientId { get; set; }

        public ProjectBillingType ProjectBillingType { get; set; }
        [ForeignKey("ProjectBillingType")]
        public int ProjectBillingTypeId { get; set; }

        public ProjectService ProjectService { get; set; }
        [ForeignKey("ProjectService")]
        public int ProjectServiceId { get; set; }

        public ProjectSupplies ProjectSupplies { get; set; }
        [ForeignKey("ProjectSupplies")]
        public int ProjectSuppliesId { get; set; }

        public DateTime StartingDate { get; set; }
        

    }
}