using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Text;

namespace Lab3
{
    public class Employee
    {
        public string Name { get; set; }
        public float Salary { get; private set; }

        public event Action<float>? SalaryIncreasedBy;
        public Employee(string name,float salary) {
            Name=name;
            Salary=salary;
        }


        public void IncreaseSalaryBy(float precentage)
        {
            if (precentage <= 0)
            {
                throw new Exception("precentage must be positive");
            }
            Salary = precentage*Salary + Salary;
            SalaryIncreasedBy?.Invoke(Salary);
        }
    }
}
