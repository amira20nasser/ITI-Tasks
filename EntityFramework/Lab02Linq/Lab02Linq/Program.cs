using L2O___D09;
using System.Collections;
using System.Collections.Concurrent;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text.RegularExpressions;
using System.Xml.Linq;
using static System.Net.WebRequestMethods;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Lab02Linq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            #region LINQ - Restriction Operators
            //1. Find all products that are out of stock.
            var productsOutOfStock = ListGenerators.ProductList.Where(product => product.UnitsInStock == 0);
            foreach (var item in productsOutOfStock)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            // 2. Find all products that are in stock and cost more than 3.00 per unit.
            var productsMoreThan3Cents = ListGenerators.ProductList.Where(product => product.UnitsInStock > 0 && product.UnitPrice > 3);
            foreach (var item in productsMoreThan3Cents)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            ////3.Returns digits whose name is shorter than their value.
            string[] Arr = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            var result = 
            Arr.Select((element, index) => new { Name = element, Value = index }).Where(x => x.Name.Length < x.Value);

            foreach (var item in result)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion
            
            #region LINQ - Element Operators
            // 1. Get first Product out of Stock 
            var firstOutOfStock = ListGenerators.ProductList.First(product => product.UnitsInStock > 0);
            Console.WriteLine(firstOutOfStock);
            Console.WriteLine();
            //2. Return the first product whose Price > 1000, unless there is no match, in which case null is returned.
            var x = ListGenerators.ProductList.FirstOrDefault(product => product.UnitsInStock > 0 && product.UnitPrice > 1000);
            Console.WriteLine(x);
            Console.WriteLine();
            //3. Retrieve the second number greater than 5 
            int[] Arr2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var y = Arr2.Where(e => e > 5).OrderBy(x => x).Skip(1).FirstOrDefault();
            Console.WriteLine(y);
            Console.WriteLine();
            #endregion

            #region LINQ - Set Operators
            // 1. Find the unique Category names from Product List
            var distinctCategories = ListGenerators.ProductList.Distinct(new ProductCategoryComparer());
            Console.WriteLine($"===== {distinctCategories.ToList().Count} Categories: =====");
            foreach (var item in distinctCategories)
            {
                Console.WriteLine(item.Category);
            }
            Console.WriteLine();

            // 2. Produce a Sequence containing the unique first letter from both product and customer names.
            var productFirstLetters= ListGenerators.ProductList.Select(p => p.ProductName[0]).Distinct();

            var customerFirstLetters = ListGenerators.CustomerList
                .Select(c => c.CustomerID[0]).Distinct();

            var result2 = productFirstLetters
                .Union(customerFirstLetters);
            foreach (var item in result2)
            {
                Console.Write(item+" ");
            }
            Console.WriteLine();
            //3. Create one sequence that contains the common first letter from both product and customer names.
            var common = productFirstLetters.Select(c => char.ToUpper(c)).Intersect(customerFirstLetters.Select(c => char.ToUpper(c)));
            foreach (var item in common)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            //4. Create one sequence that contains the first letters of product names that are not also first letters of customer names.
            var execpt = productFirstLetters.Except(customerFirstLetters);
            foreach (var item in execpt)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            //5. Create one sequence that contains the last Three Characters in each names of all customers and products, including any duplicates
            var p3Chars =  ListGenerators.ProductList
                .Select(e => e.ProductName.Substring(e.ProductName.Length-4, 3));
            var c3Chars = ListGenerators.CustomerList.Select(e => e.CompanyName.Substring(e.CompanyName.Length - 4, 3));
            var unionAll = p3Chars.Concat(c3Chars);
           //var tryx = new List<string>() { "amira", "nasser" }.Concat(new List<string>() { "amira", "metwally" });
           // Output: amira nasser amira metwally
            foreach (var item in unionAll)
            {
                Console.Write(item+" ");
            }
            #endregion

            #region LINQ - Aggregate Operators
            //1. Use Count to get the number of odd numbers in array
            int[] number = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };

            int oddCount  = number.Where(number => number % 2 != 0).Count();
            Console.WriteLine("\n=====================");
            Console.WriteLine("Odd Numbers Count");
            Console.WriteLine(oddCount);
            Console.WriteLine();

            //2.Return a list of customers and how many orders each has.
            //var res = from c in ListGenerators.CustomerList
            //          select new
            //          {
            //              CustomerName = c.CompanyName,
            //              OrderCount = c.Orders.Count()
            //          };
            var res = ListGenerators.CustomerList.Select(c => new { CustomerName = c.CompanyName, OrderCount = c.Orders.Count() });
            Console.WriteLine("=========== Customer and Orders Count ============");
            foreach (var item in res)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            //3.Return a list of categories and how many products each has
            var productsGroupedByCategory = ListGenerators.ProductList.GroupBy(e => e.Category);
            var categoryProductCounts = productsGroupedByCategory.Select(e => new {e.Key ,ProductCount = e.Count() });
            Console.WriteLine("=========== Category and Products Count ============");
            foreach (var i in categoryProductCounts)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            //4.Get the total of the numbers in an array.
            int[] Arr3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            Console.WriteLine("================ Array SUM ===============");
            Console.WriteLine(Arr3.Sum());


            //5.Get the total number of characters of all words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
           var outputFile =  System.IO.File.ReadAllLines("D:\\ITI\\EntityFramework\\Lab02Linq\\Lab02Linq\\dictionary_english.txt");
       
            Console.WriteLine(outputFile.Count());

            //6.Get the total units in stock for each product category.
            var productsGroupedByCategoryI = ListGenerators.ProductList.GroupBy(e => e.Category);
            var categoryStockSum = productsGroupedByCategoryI.Select(e => new { e.Key, TotalUnitsInStock = e.Sum(p => p.UnitsInStock) });
            Console.WriteLine("=========== Category and Total Units In Stock ============");
            foreach (var i in categoryStockSum)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();

            //7. Get the length of the shortest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            var outputFileI = System.IO.File.ReadAllLines("D:\\ITI\\EntityFramework\\Lab02Linq\\Lab02Linq\\dictionary_english.txt");
            Console.WriteLine("============= Min Word Length==========");
            Console.WriteLine(outputFileI.Min(word => word.Length));
            Console.WriteLine();

            //8. Get the cheapest price among each category's products
            var productsGroupedByCategoryII = ListGenerators.ProductList.GroupBy(e => e.Category);
            var cheapestPriceByCategory = productsGroupedByCategoryII.Select(e => new { e.Key, CheapestPrice = e.Min(p => p.UnitPrice) });
            Console.WriteLine("=========== Cheapest Price by Category ============");
            foreach (var item in cheapestPriceByCategory)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //9. Get the products with the cheapest price in each category (Use Let)
            var productsGroupedByCategoryIII = ListGenerators.ProductList.GroupBy(e => e.Category);
            // ToDo
            var allCheapesPriceByCategory = productsGroupedByCategoryII.Select(g => new { g.Key, CheapestProducts = g
                .Where(p=> p.UnitPrice == g.Min(m => m.UnitPrice)) });
            Console.WriteLine("====================== All Products that are Cheap===================");
            foreach (var item in allCheapesPriceByCategory)
            {
                Console.WriteLine("Category ===> "+item.Key);
                foreach (var item1 in item.CheapestProducts)
                {
                    Console.WriteLine("  "+item1.ProductName + " "+item1.UnitPrice);
                }
            }
            //10. Get the length of the longest word in dictionary_english.txt (Read dictionary_english.txt into Array of String First).
            var outputFileII = System.IO.File.ReadAllLines("D:\\ITI\\EntityFramework\\Lab02Linq\\Lab02Linq\\dictionary_english.txt");
            Console.WriteLine("============= Max Word Length==========");
            Console.WriteLine(outputFileII.Max(line => line.Length));
            Console.WriteLine();
            //11.Get the most expensive price among each category's products.
            var expensivePriceByCategory = ListGenerators.ProductList.GroupBy(e=>e.Category).Select(e => new { e.Key,MaxPrice = e.Max(p=>p.UnitPrice)});
            Console.WriteLine("=========== The Most Expensive Price by Category ============");
            foreach (var item in expensivePriceByCategory)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            //12.Get the products with the most expensive price in each category.
            var productsGroupedByCategoryIIII = ListGenerators.ProductList.GroupBy(e => e.Category);
            // ToDo
            var allExpensivePriceByCategory = productsGroupedByCategoryII.Select(g => new {
                g.Key,
                expensiveProducts = g
                .Where(p => p.UnitPrice == g.Max(m => m.UnitPrice))
            });
            Console.WriteLine("====================== All Products that are Cheap===================");
            foreach (var item in allExpensivePriceByCategory)
            {
                Console.WriteLine("Category ===> " + item.Key);
                foreach (var item1 in item.expensiveProducts)
                {
                    Console.WriteLine("  " + item1.ProductName + " " + item1.UnitPrice);
                }
            }
            //13.Get the average length of the words in dictionary_english.txt(Read dictionary_english.txt into Array of String First).
            var outputFileIII = System.IO.File.ReadAllLines("D:\\ITI\\EntityFramework\\Lab02Linq\\Lab02Linq\\dictionary_english.txt");
            Console.WriteLine("============= Avg Words==========");
            Console.WriteLine(outputFileII.Average(line => line.Length));
            Console.WriteLine();
            //14.Get the average price of each category's products.
            var avgPriceByCategory = ListGenerators.ProductList.GroupBy(e => e.Category).Select(e => new { e.Key, AvgPrice = e.Average(p => p.UnitPrice) });
            Console.WriteLine("=========== The Average Price for each Category ============");
            foreach (var item in avgPriceByCategory)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();
            #endregion

            #region LINQ - Ordering Operators
            //1.Sort a list of products by name
            Console.WriteLine("=============== Sort Products By Name ===============");
            ListGenerators.ProductList.OrderBy(p => p.ProductName).ToList().ForEach(e=> Console.Write(e.ProductName+", "));

            //2.Uses a custom comparer to do a case-insensitive sort of the words in an array.
            Console.WriteLine("====================== Case-Insensitive Sort ================");
            string[] Arr4 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            Arr4.OrderBy(a => a,new IncaseSensitiveComperer()).ToList().ForEach(e=> Console.WriteLine(e));
            //3.Sort a list of products by units in stock from highest to lowest.
            Console.WriteLine("====================== products by units in stock from highest to lowest ================");
            ListGenerators.ProductList.OrderByDescending(p => p.UnitsInStock).ToList().ForEach(e=> Console.WriteLine(e.ProductName+" " +e.UnitsInStock));
            //4.Sort a list of digits, first by length of their name, and then alphabetically by the name itself.
              string[] Arr5 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            Console.WriteLine("====================== Sort a list of digits, first by length, and then alphabetically ================");
            Arr5.OrderBy(s => s.Length).ThenBy(s => s).ToList().ForEach(r=> Console.WriteLine(r));
            //5. Sort first by word length and then by a case-insensitive sort of the words in an array.
            string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            Console.WriteLine("====================== Sort first by length and then by a case-insensitive ================");
            words.OrderBy(s => s.Length).ThenBy(s=>s,new IncaseSensitiveComperer()).ToList().ForEach(r=> Console.WriteLine(r));
            // 6. Sort a list of products, first by category, and then by unit price, from highest to lowest.
            Console.WriteLine("===================first by category, and then by unit price, from highest to lowest ================");
            ListGenerators.ProductList.OrderBy(p => p.Category).ThenByDescending(p => p.UnitPrice).ToList().ForEach(e=> Console.WriteLine(e.Category +" "+ e.UnitPrice));
            //7.Sort first by word length and then by a case -insensitive descending sort of the words in an array.
            Console.WriteLine("====================== Sort first by length and then by a case-insensitive descending ================");
            string[] Arr6 = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
            words.OrderBy(s => s.Length).ThenByDescending(s=>s,new IncaseSensitiveComperer()).ToList().ForEach(r=> Console.WriteLine(r));
            //8. Create a list of all digits in the array whose second letter is 'i' that is reversed from the order in the original array.
            string[] Arr7 = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
            Console.WriteLine("====================== second letter is 'i' that is reversed from the order in the original array ================");
            var q = Arr7.Where(e => e.Length>1&&e[1]=='i').Reverse();
            foreach (var item in q)
            {
                Console.WriteLine(item);
            }
            #endregion

            #region LINQ - Partitioning Operators
            //1.Get the first 3 orders from customers in Washington
            Console.WriteLine("Partitioning Q1============");
            ListGenerators.CustomerList.Where(cus => cus.Country == "Washington").Take(3).ToList().ForEach(e=> Console.WriteLine(e));
            //2.Get all but the first 2 orders from customers in Washington.
            Console.WriteLine("Partitioning Q2============");
            ListGenerators.CustomerList.Where(cus => cus.Country == "Washington").Skip(2).ToList().ForEach(e=> Console.WriteLine(e));

            //3.Return elements starting from the beginning of the array until a number is hit that is less than its position in the array
              int[] numbers1 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            Console.WriteLine("Partitioning Q3============");
            numbers1.TakeWhile((n, i) => { return n >= i; }).ToList().ForEach(e => Console.WriteLine(e));
            //4.Get the elements of the array starting from the first element divisible by 3.
            int[] numbers2 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            Console.WriteLine("Partitioning Q4============");
            numbers2.SkipWhile((n) => n % 3 !=0 ).ToList().ForEach(e => Console.WriteLine(e));

            //5.Get the elements of the array starting from the first element less than its position.
            int[] numbers3 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            Console.WriteLine("Partitioning Q5============");
            numbers1.SkipWhile((n, i) => { return n >= i; }).ToList().ForEach(e => Console.WriteLine(e));

            #endregion

            #region Projection Operators
            //1.Return a sequence of just the names of a list of products.
            Console.WriteLine("===Projection Q1===");
            ListGenerators.ProductList.Select(p => p.ProductName).ToList().ForEach(e => Console.WriteLine(e));
            //2.Produce a sequence of the uppercase and lowercase versions of each word in the original array(Anonymous Types).
            Console.WriteLine("===Projection Q2===");
            string[] words2 = { "aPPLE", "BlUeBeRrY", "cHeRry" };
            words.Select(w => new { Upper = w.ToUpper(), Lower = w.ToLower() }).ToList().ForEach(e => Console.WriteLine(e));
            //3. Produce a sequence containing some properties of Products, including UnitPrice which is renamed to Price in the resulting type.
            Console.WriteLine("===Projection Q3===");
            ListGenerators.ProductList.Select(p => new { p.ProductName, p.ProductID, p.Category,Price=p.UnitPrice }).ToList().ForEach(e => Console.WriteLine(e));

            //4. Determine if the value of ints in an array match their position in the array.
            Console.WriteLine("===Projection Q4===");
            int[] Arr9 = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            Arr9.Select((x, i) => new { x, InPlace = x == i }).ToList().ForEach(e=> Console.WriteLine(e));
            //5.Returns all pairs of numbers from both arrays such that the number from numbersA is less than the number from numbersB.
            Console.WriteLine("===Projection Q5===");
            int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
            int[] numbersB = { 1, 3, 5, 7, 8 };
            numbersA.SelectMany(a => numbersB, (a, b) => new { a, b }).Where(x => x.a < x.b).ToList().ForEach(e => Console.WriteLine(e));

            //6.Select all orders where the order total is less than 500.00.
            Console.WriteLine("===Projection Q6===");
            ListGenerators.CustomerList.SelectMany(c => c.Orders).Where(e=>e.Total<500m).ToList().ForEach(e=> Console.WriteLine(e));
            //7.Select all orders where the order was made in 1998 or later.
            Console.WriteLine("\n\n===Projection Q7===\n");
            ListGenerators.CustomerList.SelectMany(c => c.Orders).Where(e => e.OrderDate.Year >=1998).ToList().ForEach(e => Console.WriteLine(e));

            #endregion

            #region LINQ - Quantifiers
            //1. Determine if any of the words in dictionary_english.txt (Read dictionary_english.txt into Array of String First) contain the substring 'ei'.
            Console.WriteLine("============================");
            Console.WriteLine("Any Contains ei ?");
            Console.WriteLine(outputFile.Any(i => i.Contains("ei")));

            //2.Return a grouped a list of products only for categories that have at least one product that is out of stock.
            Console.WriteLine("======= Quantifiers Q2========");
            ListGenerators.ProductList.GroupBy(p => p.Category).Where(p => p.Any(x=>x.UnitsInStock==0)).ToList().ForEach(e=> { 
                Console.WriteLine(e.Key); 
                foreach (var item in e)
                {
                    Console.WriteLine("    "+item.ProductID + "   " +item.UnitsInStock);
                }
            });
            //3.Return a grouped a list of products only for categories that have all of their products in stock.
            Console.WriteLine("======= Quantifiers Q3========");
            ListGenerators.ProductList.GroupBy(p => p.Category).Where(p => p.All(x => x.UnitsInStock >0)).ToList().ForEach(e => {
                Console.WriteLine(e.Key);
                foreach (var item in e)
                {
                    Console.WriteLine("    " + item.ProductID + "   " + item.UnitsInStock);
                }
            });
            #endregion

            #region LINQ - Grouping Operators
            //1. Use group by to partition a list of numbers by their remainder when divided by 5
            Console.WriteLine("==== Grouping Q1===");
            int[] numbers4 = {0,5,10,1,6,11,7,2,12,3,8,13,4,9,14 };
            numbers4.GroupBy(x => x % 5).ToList().ForEach(e =>
            {
                Console.Write($"Numbers with a reminder of {e.Key} with 5==> ");
                foreach (var item in e)
                {
                    Console.Write(item+" ");
                }
                Console.WriteLine();
            });
            //2. Uses group by to partition a list of words by their first letter.
            Console.WriteLine("==== Grouping Q2===");
            string [] a = { "apple", "alice","box","book","misk","mall","boy","milk"};
            a.GroupBy(x => x[0]).ToList().ForEach(e =>
            {
                Console.Write($"Words With Letter {e.Key} ==> ");
                foreach (var item in e)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            });
            //3.Consider this Array as an Input
            string[] Arr10 = { "from   ", " salt", " earn ", "  last   ", " near ", " form  " };
            // Use Group By with a custom comparer that matches words that are consists of the same Characters Together
            Console.WriteLine("==== Grouping Q3===");
            Arr10.GroupBy(e => e, new GroupByComparer()).ToList().ForEach(e =>
            {
                Console.Write($"Key{{e.Key}}= ");
                foreach (var item in e)
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            });

            Console.WriteLine(new string("salt".Trim().OrderBy(c => c).ToArray()));

            #endregion
        }

        class ProductCategoryComparer : IEqualityComparer<Product>
        {
            public bool Equals(Product? x, Product? y)
            {
                if (x == null || y == null) return false;
                if(ReferenceEquals(x, y)) return true;
                return x.Category.Equals( y.Category);
            }

            public int GetHashCode(Product obj)
            {
                return obj.Category.GetHashCode();
            }
        }
        class IncaseSensitiveComperer : IComparer<string>
        {
            public int Compare(string? x, string? y)
            {
                return string.Compare(x, y, StringComparison.OrdinalIgnoreCase);
            }
        }

        class GroupByComparer : IEqualityComparer<string>
        {
            public bool Equals(string? x, string? y)
            {
                if(x==null || y== null) return false;
                string newX = new string(x.Trim().OrderBy(c => c).ToArray());
                string newY = new string(y.Trim().OrderBy(c => c).ToArray());
                return newX.Equals(newY);

            }

            public int GetHashCode([DisallowNull] string obj)
            {
                string newObj = new string(obj.Trim().OrderBy(c => c).ToArray());
                return newObj.GetHashCode();
            }
        }
    }
}
