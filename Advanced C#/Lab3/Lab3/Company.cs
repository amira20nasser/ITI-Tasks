using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Company
    {
        public string Name { get; set; }
        public float Budget { get; private set; }

        public List<Employee> employees = new List<Employee>();

        public Company(string name,float budget) {
            Name = name;
            Budget = budget;
        }
        // fire
        public void OnSalaryIncreasedBy(float amount)
        {
            Budget  -= amount;
            Console.WriteLine($"Budget decreased {amount}, The New Company Budget = {Budget}");
        }
        public delegate bool EmployeeFilter(Employee emp);
        public List <Employee> FilterEmployees(EmployeeFilter f)
        {
            List<Employee> res =new List<Employee>();
            foreach (var employee in employees)
            {
                if (f(employee))
                {
                    res.Add(employee);
                }
            }
            return res;
        }
    }
}
