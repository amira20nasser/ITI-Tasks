using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApp.Models
{
    public class WorksOn
    {
        public required string EmployeeSSN { get;  set; }
        public  required int ProjectNumber { get;  set; }
        public int? NumberOfHours { get; set; }

        public  virtual Employee Employee { get;  set; }
        public  virtual Project Project { get;  set; }
    }
}
