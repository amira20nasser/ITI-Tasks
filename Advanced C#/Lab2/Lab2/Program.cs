using System.Diagnostics;

namespace Lab2
{
    public class Program
    {
        public static Dictionary<string, List<int>> studentGrades = new Dictionary<string, List<int>>();
        public static void AddStudent(string studentName, int grade)
        {
            if (!studentGrades.ContainsKey(studentName)) { 
                studentGrades[studentName] = new List<int>();
            }
             studentGrades[studentName].Add(grade);
        }
        public static double AvgStudentGrades(string name)
        {
            if (studentGrades.ContainsKey(name))
            {
               int sum =  studentGrades[name].Sum();
                return (double) sum / studentGrades[name].Count;
            }
            throw new Exception("Invalid Student Name");
        }
        public static void DisplayHighestAvgGrade()
        {
            double maxAvg = -1;
            string name ="";
            foreach (var item in studentGrades)
            {
                double avg =  AvgStudentGrades(item.Key);
                if(maxAvg < avg)
                {
                    maxAvg = avg;
                    name = item.Key;
                }
            }
            Console.WriteLine($"Highest Student is {name} = {maxAvg}");
        }

       public  static Queue<string> tasks = new Queue<string>();
        public static void AddTask(string name)
        {
            tasks.Enqueue(name);
            int total = tasks.Count;
            Console.WriteLine("a new task is adding...");
            foreach (var item in tasks)
            {
                Console.WriteLine(item);   
            }
            Console.WriteLine($"\nYou have {total} tasks");
            Console.WriteLine("===================");
        }
        public static void RemoveTask(string name) {
           Queue<string> newQueue = new Queue<string>();
            foreach (var item in tasks)
            {
                if (item != name)
                {
                    newQueue.Enqueue(item);
                }
            }
            tasks = newQueue;
        }

        public static Dictionary<string, Contact> phones = new Dictionary<string, Contact>();
        
        public static void SearchContactName(string name)
        {
            if (phones.ContainsKey(name))
            {
                Console.WriteLine($"Name is {name} phone {phones[name]}");
                return;
            }
            Console.WriteLine($"{name} Doesn't Exist");

        }
        public static void AddP(string name, Contact c)
        {

            if (!phones.ContainsKey(name))
            {
                if (phones.ContainsValue(c))
                    Console.WriteLine("This Contact already exist");
                else
                    phones[name] = c;
            }
            else
            {
                Console.WriteLine("This Name Already Exist");
            }
        }

        public class Contact
        {
            public  required string PhoneNumber { get; set; }
            public required string Address { get; set; }

            public override bool Equals(object? obj)
            {
                if(obj== null) return false;

                if (obj.GetType() != this.GetType())
                    return false;

                Contact other = (obj as Contact)!;
                //Console.WriteLine(GetHashCode());
                //Console.WriteLine(other.GetHashCode());
                return this.PhoneNumber.Equals(other.PhoneNumber);
            }
            public override string ToString()
            {
                return $"{PhoneNumber} - {Address}";
            }

            public override int GetHashCode()
            {
                return this.PhoneNumber.GetHashCode();
            }
        }
        
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            Cage<Lion>  c = new Cage<Lion>();
            Sparrow s = new Sparrow() { Name="Bird", Age=1};
            //c.Arrive(s);
            Lion l = new Lion() { Name="Scar",Age=12};
            //c.Arrive(l);
            l.Age = 4;
            c.Arrive(l);

            // =======
            //AddStudent("Amira", 80);
            //AddStudent("Amira", 90);
            //AddStudent("Amira", 101);

            //AddStudent("Nasser", 10);
            //AddStudent("Nasser", 20);
            //AddStudent("Nasser", 30);
            //Console.WriteLine(AvgStudentGrades("Amira"));
            //DisplayHighestAvgGrade();

            //====
            AddTask("DS");
            AddTask("AI");
            AddTask("Algo");
            AddTask("CS");
            RemoveTask("Algo");
            AddTask("anu");

            SearchContactName("Amira");

            //===
            //AddP("amira", new Contact()
            //{
            //    PhoneNumber = "010260547543",
            //    Address = "Cairo"
            //});

            //AddP("nasser", new Contact()
            //{
            //    PhoneNumber = "01222324",
            //    Address = "Cairo"
            //});
            //AddP("sayed", new Contact()
            //{
            //    PhoneNumber = "010260547543",
            //    Address = "Cairo"
            //});
        }

    }
    class Browser
    {
        static Stack<Page> history = new Stack<Page>();
        public static void Visit(Page page)
        {
            history.Push(page);
        }
        public static void Return()
        {
            history.Pop();
        }

    }
    class Page {
        public string name { get; set; }

    }
}
