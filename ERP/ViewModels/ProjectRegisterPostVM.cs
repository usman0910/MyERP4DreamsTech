using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.ViewModels
{
    public class ProjectRegisterPostVM
    {
        public Project Project { get; set; }
        public Client Client { get; set; }
        public ProjectComission ProjectComission { get; set; }


    }
}