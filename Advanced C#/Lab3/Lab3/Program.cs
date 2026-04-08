namespace Lab3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1. Event Exercise
            Company company = new Company("Tech Corp", 100000);

            Employee e1 = new Employee("Amira", 5000);
            Employee e2 = new Employee("Nasser", 6000);

            company.employees.Add(e1);
            company.employees.Add(e2);
            e1.SalaryIncreasedBy += company.OnSalaryIncreasedBy;
            e2.SalaryIncreasedBy += company.OnSalaryIncreasedBy;

            e1.IncreaseSalaryBy(0.25f);
            e2.IncreaseSalaryBy(0.3f);
            #endregion

            #region 2. Delegates Exercise
            List<Employee> highSalary = company.FilterEmployees(emp => emp.Salary > 5000);
            Console.WriteLine("================");
            foreach (Employee e in highSalary)
            {
                Console.WriteLine("Name "+e.Name+" "+e.Salary);
            }
            Console.WriteLine("===========");
            List<Employee> amiraOnly = company.FilterEmployees(emp => emp.Name == "Amira");
            #endregion

            #region 3. Book Library System
            List<Book> books = new List<Book>()
            {
                    new Book("1", "C# Basics", new string[] {"Ali"}, new DateTime(2020,1,1), 100),
                    new Book("2", "Advanced C#", new string[] {"Amira"}, new DateTime(2022,5,10), 200)
            };
            // Delegate
            //LibraryEngine.BookDelegate del = BookFunctions.GetAuthors;
            LibraryEngine.ProcessBooks(books, BookFunctions.GetAuthors);

            // BCL Delegate
            Func<Book, string> fPtr = delegate (Book b)
            {
                return b.Title;
            };
            LibraryEngine.ProcessBooks(books, fPtr);

            //Anon Method
            LibraryEngine.ProcessBooks(books, delegate (Book book) {return book.ISBN; });
            // Lambda 
            LibraryEngine.ProcessBooks(books, B => B.PublicationDate.ToString());
            #endregion
        }
    }
}
