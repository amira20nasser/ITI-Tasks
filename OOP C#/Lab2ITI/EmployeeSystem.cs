using System;
namespace Lab2ITI;

class EmployeeSystem
{
    private static int ChooseIndex(Employee[] employees)
    {
        Console.WriteLine("Choose Employee Index:(0-8)");
        int index = int.Parse(Console.ReadLine());
        if (index < 0 || index >= 9)
        {
            Console.WriteLine("Invalid Index");
            ChooseIndex(employees);
        }
        if (employees[index].Name != null)
        {
            Console.WriteLine("Index Already Taken, Choose Another Index");
            ChooseIndex(employees);
        }
        return index;
    }
    public static void Run()
    {

        Employee[] employees = new Employee[9];
        char choice;
        do
        {
            Console.WriteLine("Welcome to Employee Management System");

            int index = ChooseIndex(employees);
            Console.WriteLine("Enter Employee Id:");
            employees[index].Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Employee Name:");
            employees[index].Name = Console.ReadLine();
            Console.WriteLine("Enter Employee Salary:");
            employees[index].Salary = double.Parse(Console.ReadLine());
            Console.WriteLine("Employee Added Successfully!");

            Console.WriteLine("Do You Want to Continue? (y/n)");
            choice = Console.ReadKey().KeyChar;
        } while (choice != 'n');
        Console.WriteLine("\n**********Employee List:****************");
        for (int i = 0; i < employees.Length; i++)
        {
            if (employees[i].Id != 0)
            {
                Console.Write(employees[i].Id);
                Console.Write("\t");
                Console.Write(employees[i].Name);
                Console.Write("\t");
                Console.WriteLine(employees[i].Salary);
            }
        }
        Console.WriteLine("****************************************");
    }
}