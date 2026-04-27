using CompanyApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace CompanyApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
           
            #region Insert Data

            using (var context = new AppDbContext())
            {

                //var dept = new Department
                //{
                //    Name = "IT",
                //    MGR_SSN = null,
                //    MGR_StartDate = DateTime.Now
                //};
                //var dept2 = new Department
                //{
                //    Name = "Data Engineering",
                //    MGR_SSN = null,
                //    MGR_StartDate = DateTime.Now
                //};
                //context.Departments.Add(dept);
                //context.Departments.Add(dept2);

                //var emp1 = new Employee
                //{
                //    FName = "Misk",
                //    LName = "Ahmed",
                //    gender = Gender.Female,
                //    DeptNum = dept.ID,
                //};
                //var emp2 = new Employee
                //{
                //    FName = "Amira",
                //    LName = "Nasser",
                //    gender = Gender.Female,
                //    DeptNum = dept2.ID,
                //};
                //var emp3 = new Employee
                //{
                //    FName = "Salah",
                //    LName = "Tarek",
                //    gender = Gender.Male,
                //    DeptNum = null,
                //};
                //context.Employees.Add(emp1);
                //context.Employees.Add(emp2);
                //context.Employees.Add(emp3);

                //var project = new Project
                //{
                //    Name = "E-Commerce App",
                //    Location = "Cairo",
                //    DepartmentNum = dept.ID
                //};
                //context.Projects.Add(project);

                //var EmployeeProject = new WorksOn
                //{
                //    EmployeeSSN = emp2.SSN,
                //    ProjectNumber = project.ProjectNumber,
                //    NumberOfHours = 2
                //};
                //context.WorksOn.Add(EmployeeProject);

                //var location = new DepartmentLocations
                //{
                //    DepartmentNum = dept.ID,
                //    Location = "Cairo",
                //};
                //context.DepartmentLocations.Add(location);

                //var dependent = new Dependent
                //{
                //    EmployeeSSN = emp2.SSN,
                //    Name = "Sara",
                //    gender = Gender.Female,
                //    BDate = DateOnly.FromDateTime(new DateTime(2003, 10, 12)),
                //    Relationship = "Sister"
                //};
                //context.Dependents.Add(dependent);
                //context.SaveChanges();
            }

            #endregion

            #region Update Data
            //using (var context = new AppDbContext())
            //{
            //    var emp = context.Employees.SingleOrDefault(e => e.FName == "Amira");
            //    emp.BDate = DateOnly.FromDateTime(new DateTime(2003, 4, 12));
            //    emp.MGR_SSN = context.Employees.SingleOrDefault(e => e.FName == "Salah")?.SSN;
            //    context.SaveChanges();
            //}
            #endregion

            #region Read Data
            //Console.WriteLine("Default Navigation Properties \n The Employees: ");
            //using (var context = new AppDbContext())
            //{
            //    var emps = context.Employees;
            //    // 
            //    foreach (var item in emps)
            //    {
            //        Console.WriteLine(item);
            //        //foreach (var item1 in item.EmployeeProject)
            //        //{
            //        //    Console.WriteLine("  Works for "+item1.NumberOfHours+" hours");
            //        //}
            //        if (item.Department != null)
            //        {
            //            Console.WriteLine(" His/Her Department " + item.Department.Name);
            //        }
            //    }
            //}
            #endregion

            #region Navigation Prperty Loading 

            #region Lazy
            //Console.WriteLine("\nThe Employees: ");
            //using (var context = new AppDbContext())
            //{
            //    // ERROR For Lazy Loading 1 Query for Employees and n for WorksOn (one per employee)
            //    //There is already an open DataReader associated with this Connection which must be closed first.'
            //    //var emps = context.Employees; 
            //    // Solution with Lazy Loading but Bad Performance
            //    var emps = context.Employees.ToList();
            //    Console.WriteLine(emps.FirstOrDefault(e => e.FName == "Misk")?.Department.GetHashCode());
            //    Console.WriteLine(emps.FirstOrDefault(e => e.FName == "Salah")?.Department.GetHashCode());
            //    Console.WriteLine(ReferenceEquals(emps.FirstOrDefault(e => e.FName == "Misk")?.Department, emps.FirstOrDefault(e => e.FName == "Salah")?.Department));
            //    foreach (var item in emps)
            //    {
            //        Console.WriteLine(item);
            //        //foreach (var item1 in item.EmployeeProject)
            //        //{
            //        //    Console.WriteLine("  Works for "+item1.NumberOfHours+" hours");
            //        //}
            //        if (item.Department != null)
            //        {
            //            Console.WriteLine(" His/Her Department " + item.Department.Name);
            //        }
            //    }
            //}
            #endregion

            #region Eager
            //Console.WriteLine("\nEager Loading \n The Employees: ");
            //using (var context = new AppDbContext())
            //{
            //    // The Above same Object same reference in memory for the same department.
            //    //When add AsNoTracking the same object will be loaded twice in memory with different reference and hash code.
            //    var emps = context.Employees
            //    .Include(e => e.EmployeeProject)
            //    .ThenInclude(ep => ep.Project)
            //    .Include(e => e.Department).ToList();

            //    //var emps = context.Employees.AsSplitQuery().Include(e => e.EmployeeProject)
            //    //    .ThenInclude(ep => ep.Project).AsSplitQuery()
            //    //    .Include(e => e.Department).AsSplitQuery().ToList();


            //    Console.WriteLine("Misk Department => " + emps.FirstOrDefault(e => e.FName == "Misk").Department.Name);
            //    Console.WriteLine(emps.FirstOrDefault(e => e.FName == "Misk").Department.GetHashCode());
            //    Console.WriteLine("Salah Department => " + emps.FirstOrDefault(e => e.FName == "Salah").Department.Name);
            //    Console.WriteLine(emps.FirstOrDefault(e => e.FName == "Salah").Department.GetHashCode());
            //    Console.WriteLine(ReferenceEquals(emps.FirstOrDefault(e => e.FName == "Misk").Department, emps.FirstOrDefault(e => e.FName == "Salah").Department));



            //    foreach (var item in emps)
            //    {
            //        Console.WriteLine(item);
            //        foreach (var item1 in item.EmployeeProject)
            //        {
            //            Console.WriteLine("  Works for " + item1.NumberOfHours + " hours");
            //        }
            //        if (item.Department != null)
            //        {
            //            Console.WriteLine(" His/Her Department " + item.Department.Name);
            //            Console.WriteLine(" His/Her Department " + item.Department.GetHashCode());
            //        }
            //        else
            //        {
            //            Console.WriteLine("  not Loaded");
            //        }
            //    }
            //}
            #endregion

            #region Explicit
            //using (var context = new AppDbContext())
            //{
            //    var emps = context.Employees.ToList();
            //    // Explicit Loading with Bad Performance it is like Lazy Loading but you have control when to load the navigation property and you can load it for specific entities not all of them.
            //    Console.WriteLine("Misk Department => " + emps.FirstOrDefault(e => e.FName == "Misk")?.Department?.Name);
            //    Console.WriteLine(emps.FirstOrDefault(e => e.FName == "Misk")?.Department?.GetHashCode());
            //    Console.WriteLine("Salah Department => " + emps.FirstOrDefault(e => e.FName == "Salah")?.Department?.Name);
            //    Console.WriteLine(emps.FirstOrDefault(e => e.FName == "Salah")?.Department?.GetHashCode());
            //    Console.WriteLine(ReferenceEquals(emps.FirstOrDefault(e => e.FName == "Misk")?.Department, emps.FirstOrDefault(e => e.FName == "Salah")?.Department));

            //    Console.WriteLine("\nExplicit Loading \n The Employees: ");

            //    foreach (var item in emps)
            //    {
            //        context.Entry(item).Reference(e => e.Department).Load();
            //        context.Entry(item).Collection(d => d.EmployeeProject).Load();
            //        Console.WriteLine(item);
            //        foreach (var item1 in item.EmployeeProject)
            //        {
            //            Console.WriteLine("  Works for " + item1.NumberOfHours + " hours");
            //        }
            //        if (item.Department != null)
            //        {
            //            Console.WriteLine(" His/Her Department " + item.Department.Name);
            //            Console.WriteLine(" His/Her Department " + item.Department.GetHashCode());
            //        }
            //        Console.WriteLine();
            //    }
            //}
            #endregion

            #endregion
        }
    }
}
