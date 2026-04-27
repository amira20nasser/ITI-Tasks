using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CompanyApp.Models
{
    public enum Gender
    {
        Female,Male
    }
    public class Employee
    {
        [MaxLength(50)]
        public required string FName { get; set; }
        [MaxLength(50)]
        public required string LName { get; set; }
        public required Gender gender { get; set; }
        public string? Address { get; set; }
        public string SSN { get; private set; }
        public  string? MGR_SSN { get; set; }
        public DateTime BDate { get; set; } 
        public int? DeptNum { get; set; }
        public decimal? Salary { get; set; }

        public virtual Department Department { get; set; }
        public virtual Employee Manager { get; set; }
        public virtual ICollection<Employee>? Subordinates { get; set; } = new List<Employee>();

        public override string ToString()
        {
            return $"Name: {FName} {LName}, Gender: {gender}, Salary: {Salary?.ToString("C") ?? "N/A"}, DeptId: {DeptNum}, ManagerId: {MGR_SSN ?? "N/A"}";
        }
    }

}
