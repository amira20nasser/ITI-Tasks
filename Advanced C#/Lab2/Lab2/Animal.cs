using System;
using System.Collections.Generic;
using System.Net.Cache;
using System.Text;

namespace Lab2
{
    public class Animal
    {
        public int Age { get; set; }
        public required string Name { get; set; }
    }

    public class Lion : Animal { 
        public void Roar()
        {
            Console.WriteLine($"{Name} --> {Age} roar");
        }
    }
    public class Sparrow : Animal
    {
        public void Fly()
        {
            Console.WriteLine($"{Name} --> {Age} is flying..");
        }
    }

    public class Cage<T> where T : Animal
    {
        public void Arrive(T resident)
        {
            if (resident.Age > 8)
            {
                throw new Exception("Invalid Age Exception");
            }
            Console.WriteLine($"Added {resident.Name}");
        }
    }
}
