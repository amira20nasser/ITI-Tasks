using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApp.Models
{
    public class DepartmentLocations
    {
        public required string Location { get; set; }
        public required int DepartmentNum { get; set; }
        public virtual  Department Department { get; set; }
    }
}
