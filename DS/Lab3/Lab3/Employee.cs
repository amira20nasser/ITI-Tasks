using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Employee :  IComparable<Employee>
    {
        private static int counter = 1;   

        public int Id { get; private set; }  
        public  string Name { get; set; }

        public double Salary { get; set; }
        public DateTime HireDate { get; set; }

        public Employee(string name, double salary, DateTime hiredate)
        {
            Id = counter++;
            Name = name;
            Salary = salary;
            HireDate = hiredate;
        }

        public override string ToString()
        {
            return $"Employee #{Id} {Name} {Salary} {HireDate.ToShortDateString()}";
        }

        public int CompareTo(Employee? other)
        {
            if(other == null)   return 0 ;
            return this.HireDate.CompareTo(other.HireDate) ;
        }


    }
}
