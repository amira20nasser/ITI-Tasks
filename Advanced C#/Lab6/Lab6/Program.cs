
using System.Reflection;
using System.Text;

[assembly: CLSCompliant(true)]
namespace Lab6
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            DeprecatedMethod();
            NewMethod();
            Console.WriteLine((Gender.Male | Gender.Female));

            Type person2T = typeof(Person2);
            Console.WriteLine(person2T);
            Console.WriteLine(person2T.Name);
           var attributes = person2T.GetCustomAttributes(true);
            foreach (var item in attributes)
            {
                Console.WriteLine($"{item.GetType()} ");
            }
           var  attributes2 = person2T.GetCustomAttributes<StereoTypeAttribute>(true);
            foreach (var item in attributes2)
            {
                Console.WriteLine($"{item.Type} {item.Description} ");
            }
            var methods = person2T.GetMethods();
            foreach (var item in methods)
            {
                Console.WriteLine($"{item.Name} {item.ReturnType} ");
            }

            Console.WriteLine("\nMetaData of primitives types");
            Type t = typeof(int);
            Console.WriteLine(t.Name);
            Console.WriteLine(t.FullName);
            Console.WriteLine(t.Namespace);
            Console.WriteLine(t.BaseType);
            Console.WriteLine(t.GetInterfaces());
            Console.WriteLine(t.GetMethods());
            Console.WriteLine();

            Console.WriteLine("Enum ===>");
            Student student = new Student();
            student.grade = Grade.A;
            Console.WriteLine(student.grade);

            Console.WriteLine();
            StringBuilder s = new StringBuilder();
            s.Append("Hello");
            s.AppendLine(" students");
            s.Insert(5, " Amazing");
            s.Replace("students", "amira");
            s.Remove(5,8);
            Console.WriteLine(s.ToString());

            Console.WriteLine("\n Exception =====>");
            Student s1 = new Student();
            s1.Age = -1;
        }
        [Obsolete("Use NewMethod instead" , false)]
        // true --> error 
        // false --> warning
        static void DeprecatedMethod()
        {
            Console.WriteLine("This is method. unavaliable");
        }
        static void NewMethod()
        {
            Console.WriteLine("This is new method");
        }

        [Flags]
        enum Gender
        {
            Male = 2,
            Female =1 ,
            //None = Male | Female
        }

        [AttributeUsage(AttributeTargets.All,Inherited =true)]
        public class StereoTypeAttribute : Attribute
        {
            public string Type;
            public string Description;
           public StereoTypeAttribute(string type, string description)
           {
                Type = type;
                Description = description;
           }
        }

        [StereoType("Class","This is the Class Model")]
        class Person
        {
            [StereoType("field", "private field")]
            protected string Name = "Person";
            [StereoType("Method", "Getter for private field 'Name'")]

            public string getName() => Name;
        }

        class Person2 : Person
        {

        }
       public class CustomException : Exception
       {
          public  CustomException(): base("Invalid Age Argument")
          {
                Console.WriteLine("Invalid Age Argument");
          }   

        }

       public class Student
        {
            public string Name { get; set; }
            public string Address { get; set; }
            private int age;

            public int Age { 
                get;
                set {
                    if(value < 0)
                        throw new CustomException();
                    else
                    {
                        age = value;
                    }
                } }
            public Grade grade { get; set; }

            static Student()
            {
                Console.WriteLine("This static const Call only once");
            }
            public static void staticMethod()
            {
                Console.WriteLine("Static Method");
            }
        }
       public enum Grade
        {
            A=1,B,C,D
        }
    }
}
