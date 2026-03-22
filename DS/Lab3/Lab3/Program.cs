using ConsoleApp1;

namespace Lab3
{
    internal class Program
    {
        static Employee BinarySearchById(List<Employee> employees, int id)
        {
            int left = 0;
            int right = employees.Count - 1;

            while (left <= right)
            {
                int mid = (left + right) / 2;
                if (employees[mid].Id == id)
                    return employees[mid];

                if (employees[mid].Id < id)
                    left = mid + 1;
                else
                    right = mid - 1;
            }

            return null;
        }
        
        static Employee BinarySearchRecursive(List<Employee> employees, int id, int left, int right)
        {
            if (left > right)
                return null;

            int mid =  (right + left) / 2;

            if (employees[mid].Id == id)
                return employees[mid];

            if (employees[mid].Id < id)
                return BinarySearchRecursive(employees, id, mid + 1, right);

            return BinarySearchRecursive(employees, id, left, mid - 1);
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            List<Employee> employees = new List<Employee>()
            {
                new Employee("Amira",5000,new DateTime(2022,5,1)),
                new Employee("Nasser",6000,new DateTime(2020,3,1)),
                new Employee("Sayed",7000,new DateTime(2021,7,1)),
            };

            employees.Sort();

            foreach (var e in employees)
            {
                Console.WriteLine(e);
            }

            Console.WriteLine("======================");
            Console.WriteLine(BinarySearchById(employees, 2));
            Console.WriteLine("======================");
            Console.WriteLine(BinarySearchRecursive(employees, 2,0,employees.Count-1));
            Console.WriteLine("======================");

            DoubleLinkedList<Employee> es = new DoubleLinkedList<Employee>();
            es.Insert(new Employee("Metwally", 5000, new DateTime(2001, 5, 1)));
            es.Insert(new Employee("Aya", 5000, new DateTime(2022, 5, 1)));
            es.Insert(new Employee("Salah", 5000, new DateTime(2026, 5, 1)));
            es.Insert(new Employee("Ahmed", 5000, new DateTime(1996, 5, 1)));

            es.Display();
        }
    }
}
