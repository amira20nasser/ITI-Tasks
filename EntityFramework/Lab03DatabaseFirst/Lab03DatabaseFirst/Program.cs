using Lab03DatabaseFirst.Models;

namespace Lab03DatabaseFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            using (var context = new AppDbContext())
            {

                Console.WriteLine("==============Data Before=============");
                var allEmployees = context.Employees;
                foreach (var item in allEmployees)
                {
                    Console.WriteLine($"{item.Fname} {item.Lname} {item.Salary} {item.DeptNo}");
                }
                Console.WriteLine();
                // Create Data
                var Department = new Department { DeptNo="d100",DeptName = "IT" };
                var employee = new Employee {EmpNo=1, Fname = "AMIRA", Lname = "Nasser" };
                Department.Employees.Add(employee);
                context.Departments.Add(Department);
                context.SaveChanges();


                //// Read Data
                Console.WriteLine("==============Data After Add New One =============");
                foreach (var item in allEmployees)
                {
                    Console.WriteLine($"{item.Fname} {item.Lname} {item.Salary} {item.DeptNo}");
                }
                Console.WriteLine();
                // update Data
                var emp = context.Employees.Find(1);
                if (emp != null)
                {
                    emp.Fname = "Amira";
                    emp.Salary = 1000;
                    context.SaveChanges();
                }
                Console.WriteLine("==============Data After update =============");
                foreach (var item in allEmployees)
                {
                    Console.WriteLine($"{item.Fname} {item.Lname} {item.Salary} {item.DeptNo}");
                }
                Console.WriteLine();
                //Delete Data
                var emp2 = context.Employees.Find(1);
                if (emp2 != null)
                { 
                     context.Employees.Remove(emp2);
                    context.SaveChanges();
                }
                Console.WriteLine("==============Data After Delete =============");
                foreach (var item in allEmployees)
                {
                    Console.WriteLine($"{item.Fname} {item.Lname} {item.Salary} {item.DeptNo}");
                }
                Console.WriteLine();
            }
        }
    }
}
