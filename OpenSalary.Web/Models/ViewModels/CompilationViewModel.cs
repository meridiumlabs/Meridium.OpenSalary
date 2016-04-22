using System;
using System.Collections.Generic;
using OpenSalary.Web.Core.Entities;

namespace OpenSalary.Web.Models.ViewModels {
    public class CompilationViewModel {
        public List<User> AllEmployees { get; set; }
        public string CurrentSortBy { get; set; }       
    }
}