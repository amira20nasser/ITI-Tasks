using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApp.Models
{
    public class Project
    {
        public required string Name { get; set; }
        public string? Location { get; set; }

        public int ProjectNumber { get; private set; }
        public int DepartmentNum { get; set; }
        public  virtual Department Department { get; set; }
        public  virtual ICollection<WorksOn> EmployeeProject { get; set; }

    }
}
