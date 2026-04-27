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
        public decimal? Salary { get; set; }
        public  string? MGR_SSN { get; set; }
        public DateOnly? BDate { get; set; } 
        public int? DeptNum { get; set; } 

        public virtual  Department Department { get; set; }
        public virtual  Employee Manager { get; set; }
        public virtual  ICollection<Employee>? Subordinates { get; set; } = new List<Employee>();
        public  virtual ICollection<Dependent> Dependents { get; set; } = new List<Dependent>();
        public  virtual ICollection<WorksOn> EmployeeProject { get; set; } = new List<WorksOn>();


        public override string ToString()
        {
            return $"Name: {FName} {LName}, Gender: {gender}, DeptId: {DeptNum}, ManagerId: {MGR_SSN ?? "N/A"}, Salary: {Salary?.ToString("C") ?? "N/A"}";
        }
    }

}
