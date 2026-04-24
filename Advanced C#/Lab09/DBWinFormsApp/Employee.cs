using System;
using System.Collections.Generic;
using System.Text;

namespace DBWinFormsApp
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }

        public override string ToString()
        {
            return $"Id : {Id}, Name: {Name}, Age: {Age}";
        }
    }
}
