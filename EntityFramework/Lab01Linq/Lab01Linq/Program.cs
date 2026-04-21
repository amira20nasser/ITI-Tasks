using System.IO.Pipes;

namespace Lab01Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region 1. 
            List<int> numbers = new List<int>() { 2, 4, 6, 7, 1, 4, 2, 9, 1 };
            var distinctNumbers = numbers.Distinct();
            var sortedNumbers = distinctNumbers.OrderBy(x => x);
            Console.WriteLine("========= Sorted List ==========");
            foreach (var item in sortedNumbers)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine("========= Multiply ==========");
            var mulitpledNumbers = sortedNumbers.Select(x => {
                return new { Number = x, Multiply = x * x };
            });
            foreach (var item in mulitpledNumbers)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion

            #region 2
            string[] names = { "Tom", "Dick", "Harry",  "Mary","Jay"};
            // Method Expression
            var namesLength3 = names.Where(x=>x.Length == 3);

            // Query Expression
            var namesLength3II = from i in names
                                 where i.Length == 3
                                 select i;
            Console.WriteLine("=========  Method Expression Names With Lenght 3 ========");
            foreach (var item in namesLength3)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("=========  Query Expression Names With Lenght 3 ========");
            foreach (var item in namesLength3II)
            {
                Console.WriteLine(item);
            }

            // Method Expression
            var namesWithA = names.Where(x => x.ToLower().Contains("a")).OrderBy(x => x.Length);
            Console.WriteLine("============== Method Expression Names with A ==============");
            foreach (var item in namesWithA)
            {
                Console.WriteLine(item);
            }
            // Query Expression
            var namesWithAII = from i in names
                               where i.ToLower().Contains("a")
                               orderby i.Length
                               select i;
            Console.WriteLine("============== Query Expression Names with A ==============");
            foreach (var item in namesWithAII)
            {
                Console.WriteLine(item);
            }


            var first2Names = names.Take(2);
            Console.WriteLine("============== Method Expression First 2 Names ==============");
            foreach (var item in first2Names)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine("============== Query Expression First 2 Names ==============");
            var first2NamesII = (from i in names
                                 select i).Take(2);
            foreach (var item in first2NamesII)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion

            #region 3
            List<Student> students = new List<Student>()
            {
                new Student()
                {
                    ID = 1,
                    FirstName = "Ali",
                    LastName = "Mohammed",
                    subjects = new Subject[]
                    {
                        new Subject() { Code = 22, Name = "EF" },
                        new Subject() { Code = 33, Name = "UML" }
                    }
                },

                new Student()
                {
                    ID = 2,
                    FirstName = "Mona",
                    LastName = "Gala",
                    subjects = new Subject[]
                    {
                        new Subject() { Code = 22, Name = "EF" },
                        new Subject() { Code = 34, Name = "XML" },
                        new Subject() { Code = 25, Name = "JS" }
                    }
                },

                new Student()
                {
                    ID = 3,
                    FirstName = "Yara",
                    LastName = "Yousf",
                    subjects = new Subject[]
                    {
                        new Subject() { Code = 22, Name = "EF" },
                        new Subject() { Code = 25, Name = "JS" }
                    }
                },

                new Student()
                {
                    ID = 1,
                    FirstName = "Ali",
                    LastName = "Ali",
                    subjects = new Subject[]
                    {
                        new Subject() { Code = 33, Name = "UML" }
                    }
                }
            };

            Console.WriteLine("================ New List Method Chaining ===========");
            students.Select(s =>
            {
                return new { FullName = s.FirstName + ' ' + s.LastName, NoOfSubjects = s.subjects.Length };
            }).ToList().ForEach(s => Console.WriteLine(s));

            Console.WriteLine("================ Desconding Fitst Name  Acending Last Name ===========");

            students.OrderByDescending(x=>x.FirstName).ThenBy(x => x.LastName)
                .ToList().ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName}"));

            Console.WriteLine("============== Select Many ===============");
            students.SelectMany((s)=>  s.subjects , 
                (student, subject) => new { StudentName = student.FirstName + " " + student.LastName, SubjectName=subject.Name })
                .ToList().ForEach(e=> Console.WriteLine(e));


            Console.WriteLine("============== Group BY + Select Many ===============");
            students.SelectMany(
                (s) => s.subjects, 
                (student, subject) => new { StudentName = student.FirstName + " " + student.LastName, SubjectName = subject.Name })
                .GroupBy(e => e.StudentName)
                .ToList().ForEach(group =>
                {
                    // student Name
                  
                    Console.WriteLine(group.Key);
                    foreach(var subject in group)
                    {
                        Console.WriteLine($"  {subject.SubjectName}");
                    }
                });
            Console.WriteLine();
            #endregion

        }

        class Subject
        {
            public string Name { get; set; }
            public int Code { get; set; }
        }
        class Student
        {
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public Subject[] subjects { get; set; }
            public int ID { get; set; }

        }
    }
}
