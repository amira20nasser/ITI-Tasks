namespace Lab2ITI;

using System;

class Program
{


    static void ReadWrite2DArray()
    {
        int rows = 3;
        int cols = 4;
        int[,] matrix = new int[rows, cols];

        Console.WriteLine("Enter elements of the 2D array:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write($"Element [{i},{j}]: ");
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        Console.WriteLine("The 2D array is:");
        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < cols; j++)
            {
                Console.Write(matrix[i, j] + "\t");
            }
            Console.WriteLine();
        }
    }

    static void RunImaginaryNumbers()
    {
        char choice;
        do
        {
            Console.WriteLine("*****************************************************************");
            ComplexNumber c1 = new ComplexNumber();
            Console.WriteLine("Enter first complex number:\n**************************");
            Console.Write("Real part: ");
            c1.Real = int.Parse(Console.ReadLine());
            Console.Write("Imaginary part: ");
            c1.Imaginary = int.Parse(Console.ReadLine());

            ComplexNumber c2 = new ComplexNumber();
            Console.WriteLine("Enter second complex number:\n**************************");
            Console.Write("Real part: ");
            c2.Real = int.Parse(Console.ReadLine());
            Console.Write("Imaginary part: ");
            c2.Imaginary = int.Parse(Console.ReadLine());
            ComplexNumber c3 = c1.Add(c2);
            Console.WriteLine($"Result is : {c3.ToString()}");
            Console.WriteLine("Do You Want to Continue? (y/n) ");
            choice = Console.ReadKey().KeyChar;
        } while (choice != 'n');
    }
    static void OneStudentReadWrite()
    {
        Student student = new Student();
        Console.WriteLine("\n*******************");
        Console.WriteLine("Enter Id of Student");
        student.Id = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter Name of Student");
        student.Name = Console.ReadLine();
        Console.WriteLine("Enter GPA of Student");
        student.GPA = double.Parse(Console.ReadLine());
        Console.WriteLine("**********The Data of Student*********");
        Console.WriteLine(student.ToString());
    }


    static void MultipleStudentsReadWrite()
    {
        Student[] students = new Student[3];
        for (int i = 0; i < students.Length; i++)
        {
            Console.WriteLine($"Enter The  Student #{i + 1}");
            students[i] = new Student();
            Console.WriteLine("\n*******************");
            Console.WriteLine("Enter Id of Student");
            students[i].Id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name of Student");
            students[i].Name = Console.ReadLine();
            Console.WriteLine("Enter GPA of Student");
            students[i].GPA = double.Parse(Console.ReadLine());
            Console.WriteLine("*********************************");
        }

        Console.WriteLine("**********The Data of Students*********");
        for (int i = 0; i < students.Length; i++)
        {
            Console.WriteLine(students[i].ToString());
            Console.WriteLine("*********************************");
        }
    }
    static void Main()
    {
        int[] arr = { 1, 2 };
        int[] arr2 = { 1, 2, 3 };
        arr = arr2;
        Console.WriteLine(arr.Length); // Output: 3
        Console.WriteLine(arr2.Length);

        arr = new int[] { 4, 5, 6, 7, 8 };
        Console.WriteLine(arr.Length); // Output: 5
        Console.WriteLine(arr2.Length); // Output: 5

        // RunImaginaryNumbers();
        // OneStudentReadWrite();
        // MultipleStudentsReadWrite();
        // Program1D.Run();

        // 2d array 3,4 read and write
        // ReadWrite2DArray();

        // simple calculator
        // Calculator.Run();

        // Employee Management 
        // EmployeeSystem.Run();

        //Age Calculation
        // AgeCalculation.Run();



    }
}
