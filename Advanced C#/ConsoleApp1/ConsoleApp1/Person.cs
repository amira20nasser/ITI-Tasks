using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Person
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get => $"{FirstName} {LastName}"; }

        public int Age { get; set; }

        private string _password;
        public string Password { 
            set
            {
                if (value == null || value.Length == 0 || value.IsWhiteSpace())
                {
                    throw new Exception("Password must contain at least one digit ");
                }
                _password = value!;
            } 
        }
    }

}
