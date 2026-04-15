using System.Collections;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab5
{
    internal class Program
    {
        static List<Dictionary<string, object>> m()
        {
            return new List<Dictionary<string, object>>
            {
                new Dictionary<string, object> { { "Key1", "Value1" } },
                new Dictionary<string, object> { { "Key2", 42 } }
            };
        }

        static void Main(string[] args)
        {
            #region Task 1
                var data = m();
                data.Add(new Dictionary<string, object>() { { "amira", "value3" } });
                Console.WriteLine(data.Count);
                foreach (var dict in data)
                {
                    foreach(var item in dict)
                        Console.WriteLine($"{item.Key} {item.Value}");
                }
            #endregion

            #region Task 2
                var email1 = "amira@example.com";
                var email2 = "not-an-email";

                Console.WriteLine(email1.IsValidEmail());
                Console.WriteLine(email2.IsValidEmail());

                List<int> l = new List<int>() { 1, 2, 3, 4 };
                foreach (var item in l.GetAboveAverage())
                {
                    Console.WriteLine(item);
                }

                DateTime d = new DateTime(2026, 4, 12);
                Console.WriteLine(d.ToFriendlyDate());
            #endregion

            #region Task 3
            Zoo z = new Zoo();
            z.AddAnimal("Lion");
            z.AddAnimal("Monkey");
            z.AddAnimal("Girrafe");
            foreach (var item in z)
            {
                Console.WriteLine(item);
            }
            #endregion



        }
    }

    public static class StringExtension
    {
        extension(string input)
        {
            public bool IsValidEmail()
            {
                if (string.IsNullOrWhiteSpace(input))
                {
                    return false;
                }
                return Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$", RegexOptions.IgnoreCase);
            }
        }
    }

    public static class IEnumerableExtention
    {
        extension(IEnumerable<int> input)
        {
            public List<int> GetAboveAverage()
            {
                if (input == null || !input.Any())
                    return Enumerable.Empty<int>().ToList<int>();

                double average = input.Average();
                return input.Where(x => x > average).ToList();
            }
        }
    }

    public static class DateTimeExtension
    {
        extension(DateTime input)
        {
            public string ToFriendlyDate()
            {
                var today = DateTime.Today;

                if (input.Date == today)
                    return "Today";
                else if (input.Date == today.AddDays(-1))
                    return "Yesterday";
                else if (input.Date == today.AddDays(1))
                    return "Tomorrow";
                else
                    return input.ToString("dd/MM/yyyy");
            }
        }
    }


    class Zoo : IEnumerable<string>
    {
        private List<string> animals = new List<string>();

        public void AddAnimal(string animalName)
        {
            animals.Add(animalName);
        }
        public IEnumerator<string> GetEnumerator()
        {
            return animals.GetEnumerator();

            //foreach (var animal in animals)
            //{
            //    yield return animal;
            //}
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}
