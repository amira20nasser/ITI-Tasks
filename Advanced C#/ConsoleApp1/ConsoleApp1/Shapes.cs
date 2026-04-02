using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    internal class Regctangle : IColor, IShape
    {
        public double Width
        {
            get; set; 
        }
       public double Height { get; set; }
        public double CalculateArea()
        {
            double res = Width * Height;
            return res;
        }

        public double CalculatePerimeter()
        {
            double res = 2*(Width + Height);
            return res;
        }

        public string GetColor()
        {
            return "Blue";
        }

    }

    internal class Square : IColor, IShape
    {
        public double Side { get; set; }
        public double CalculateArea()
        {
            return Side * 2;
        }

        public double CalculatePerimeter()
        {
            return Side * 4;
        }

        public string GetColor()
        {
            return "Red";
        }
    }

    internal class Circle : IColor, IShape
    {
        public double Radius { get; set; }
        public double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        public double CalculatePerimeter()
        {
            return Math.PI * Radius * 2;
        }

        public string GetColor()
        {
            return "green";
        }
    }
}
