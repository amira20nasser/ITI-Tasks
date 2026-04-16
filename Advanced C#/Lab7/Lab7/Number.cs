using System;
using System.Collections.Generic;
using System.Text;

namespace Lab7
{
    public class Number
    {
        public static int Value;

        public static void Factorial()
        {
            Console.WriteLine("Factorial started...");
            Thread.Sleep(3000);

            long result = 1;
            for (int i = 1; i <= Value; i++)
                result *= i;

            Console.WriteLine($"Factorial of {Value} = {result}");
        }

        public static void Sum()
        {
            Console.WriteLine("Sum started...");

            int sum = 0;
            for (int i = 1; i <= Value; i++)
                sum += i;

            Console.WriteLine($"Sum of 1 to {Value} = {sum}");
        }
    }
}
