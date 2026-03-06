using System;
namespace Lab2ITI;

class Calculator
{
    public static void Run()
    {
        Console.WriteLine("Simple Calculator");
        Console.Write("Enter first number: ");
        double num1 = double.Parse(Console.ReadLine());
        Console.Write("Enter second number: ");
        double num2 = double.Parse(Console.ReadLine());
        Console.Write("Enter operation (+, -, *, /): ");
        char operation = Console.ReadKey().KeyChar;
        Console.WriteLine();
        double? result = null;
        switch (operation)
        {
            case '+':
                result = num1 + num2;
                break;
            case '-':
                result = num1 - num2;
                break;
            case '*':
                result = num1 * num2;
                break;
            case '/':
                if (num2 == 0)
                {
                    Console.WriteLine("Error: Division by zero is not allowed.");
                    Run();
                    return;
                }
                result = num1 / num2;
                break;
            default:
                Console.WriteLine("Invalid operation.");
                Run();
                break;
        }
        if (result != null)
        {
            Console.WriteLine($"Result: {result}");
        }
    }
}