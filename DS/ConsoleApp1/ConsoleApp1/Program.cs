namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //5.	Use Built in LinkedList & explore it is Functionalities 
            Console.WriteLine("Hello, World!");
            Employee e1 = new Employee() { Id=1,Salary=1200,Name="Amira"};
            Employee e2 = new Employee() { Id = 2, Salary = 43432, Name = "Nasser" };
            Employee e3 = new Employee() { Id = 3, Salary = 12040, Name = "Sayed" };
            DoubleLinkedList<Employee> l = new DoubleLinkedList<Employee>();
            l.AddFirst(e2);
            l.AddFirst(e1);
            l.AddLast(e3);
            l.AddLast(e3); l.AddLast(e3); l.AddLast(e3); l.AddLast(e3);
            //l.RemoveFirst();
            //l.RemoveLast();
            
            //5.	Use Built in LinkedList & explore it is Functionalities 
            Console.WriteLine("=======================");
            Console.WriteLine("Built In");
            Console.WriteLine("=======================");
            LinkedList<Employee> es = new LinkedList<Employee>();   
            es.AddLast(e3);
            es.AddFirst(e2);
            es.AddFirst(e1);

            StackDoubleLinkedList<Employee> s = new StackDoubleLinkedList<Employee>();
            s.Push(e1);
            s.Push(e2);
            s.Push(e3);

            s.Pop();
            s.Pop();

            s.Display();



            QueueDoubleLinkedList<Employee> q = new QueueDoubleLinkedList<Employee>();
            q.Push(e1);
            q.Push(e2);
            q.Push(e3);

            q.Pop();
            q.Display();
        }
    }
}
