using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyApp.Models
{
    public class Dependent
    {
        public required string EmployeeSSN { get; set; }
        public  required  string Name { get; set; }
        public required Gender gender { get; set; }
        public DateOnly? BDate { get; set; }
        
        public string? Relationship { get; set; }
        public  virtual Employee Employee { get; set; }  
    }
}
