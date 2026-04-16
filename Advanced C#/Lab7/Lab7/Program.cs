using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Lab7
{
    public class Program
    {
        static void EnsureFileExists(string path)
        {
            if (!File.Exists(path))
            {
                File.Create(path).Close();
            }
        }

        static void AddStudents(string path)
        {
            while (true)
            {
                Console.Write("Enter student name: ");
                string? name = Console.ReadLine();

                File.AppendAllLines(path, new[] { name ?? "" });

                Console.Write("Continue? (yes/no): ");
                string? answer = Console.ReadLine()?.ToLower();

                if (answer != "yes")
                    break;
            }
        }
        static void ViewStudents(string path)
        {
            string[] students = File.ReadAllLines(path);

            Console.WriteLine("\n--- Students List ---");

            foreach (var student in students)
            {
                Console.WriteLine(student);
            }
        }

        static void SearchStudent(string path)
        {
            Console.Write("Enter name to search: ");
            string? search = Console.ReadLine()?.ToLower();

            var students = File.ReadAllLines(path);

            bool found = false;

            foreach (var student in students)
            {
                if (student.ToLower().Contains(search ?? ""))
                {
                    Console.WriteLine($"Found: {student}");
                    found = true;
                }
            }

            if (!found)
                Console.WriteLine("Student not found.");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            #region Assignment 1 Threading
            //Number.Value = 3;
            //Console.WriteLine("=== Same Thread (Multicast Delegate) ===");
            //ThreadStart threadStart = Number.Factorial;
            //threadStart += Number.Sum;
            //Thread t1 = new Thread(threadStart);
            //t1.Start();
            //t1.Join();

            //Console.WriteLine("\n=== Separate Threads ===");

            //Thread t2 = new Thread(Number.Factorial);
            //Thread t3 = new Thread(Number.Sum);
            //t2.Start();
            //t3.Start();
            //t2.Join();
            //t3.Join();

            //Console.WriteLine("\n==========Finished...===========\n");
           
            #endregion

            string path = "D:\\ITI\\Advanced C#\\Lab7\\Lab7\\students.txt";
            #region Assignment 2 File
            //EnsureFileExists(path);
            //Console.WriteLine("Enter Your name");
            //string? name = Console.ReadLine();
            //List<string> list = new List<string>();
            //if (name != null)
            //{
            //    list.Add(name);
            //    File.AppendAllLines(path, list);
            //}

            //var names = File.ReadAllLines(path);
            //Console.WriteLine("The name of stuents");
            //if (names != null)
            //    foreach (var studentName in names)
            //    {
            //        Console.WriteLine(studentName);
            //    }
            #endregion

            #region Code Enhancement
            //EnsureFileExists(path);
            //AddStudents(path);
            //ViewStudents(path);
            #endregion

            #region Menu
            EnsureFileExists(path);

            while (true)
            {
                Console.Clear();
                Console.WriteLine("\n==== MENU ====");
                Console.WriteLine("1. Add Student");
                Console.WriteLine("2. View Students");
                Console.WriteLine("3. Search Student");
                Console.WriteLine("4. Exit");

                Console.Write("Choose: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddStudents(path);
                        break;
                    case "2":
                        ViewStudents(path);
                        Console.WriteLine("Press Any Key to Continue");
                        Console.ReadLine();
                        break;
                    case "3":
                        SearchStudent(path);
                        Console.WriteLine("Press Any Key to Continue");
                        Console.ReadLine();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }
            }
            #endregion
        }

    }
}
