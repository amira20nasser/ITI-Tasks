using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Xml.Linq;

namespace CompanyApp.Models
{
    public class Department
    {
        public required string Name { get; set; }
        public int ID {  get; private set; }
        public  string? MGR_SSN { get; set; }
        public required DateTime MGR_StartDate { get; set; }
        public virtual Employee DepartmentManager { get; set; }
        public virtual ICollection<Employee> Employees { get; set; } = new List<Employee>();
        public override string ToString()
        {
            return $"Name: {Name}, ID: {ID}, MGR_StartDate: {MGR_StartDate}, MGR_SSN: {MGR_SSN ?? "N/A"}";
        }
    }
}
