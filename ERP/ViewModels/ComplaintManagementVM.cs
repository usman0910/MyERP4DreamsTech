﻿using ERP.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ERP.ViewModels
{
    public class ComplaintManagementVM
    {
        public IEnumerable<Project> Projects { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public IEnumerable<Client> Clients { get; set; }
    }
}