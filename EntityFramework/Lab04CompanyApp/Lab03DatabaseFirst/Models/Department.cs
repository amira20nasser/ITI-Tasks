using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApp.Models
{
    public class Department
    {
        public required string Name { get; set; }
        public int ID {  get; private set; }
        public  string? MGR_SSN { get; set; }
        public required DateTime MGR_StartDate { get; set; }

        public   virtual Employee DepartmentManager { get; set; }
        public   virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<Project>? Projects { get; set; }
        public virtual ICollection<DepartmentLocations>? Locations { get; set; }

    }
}
