using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Employee
    {
        public int Id { get; set; }
        public  string Name { get; set; }

        public double Salary { get; set; }

        public override string ToString()
        {
            return $"Employee #{Id} {Name} {Salary}";
        }
    }
}
