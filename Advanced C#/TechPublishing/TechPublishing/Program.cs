using System;
using System.Collections.Generic;
using TechBooksPublishing.Models;
using TechBooksPublishing.BusinessLogicLayer;
using System.Text.RegularExpressions;

namespace TechBooksPublishing.PresentationLayer
{
    class Program
    {
        static void Main(string[] args)
        {
            AutherBLL authorBLL = new AutherBLL();

            while (true)
            {
                Console.Clear();
                Console.WriteLine("===== HR MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Add Author");
                Console.WriteLine("2. Delete Author");
                Console.WriteLine("3. Get All Authors");
                Console.WriteLine("4. Exit");
                Console.Write("Enter your choice: ");

                string? choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddAuthor(authorBLL);
                        break;

                    case "2":
                        DeleteAuthor(authorBLL);
                        break;

                    case "3":
                        GetAllAuthors(authorBLL);
                        break;

                    case "4":
                        return;

                    default:
                        Console.WriteLine("Invalid choice!");
                        break;
                }

                Console.WriteLine("\nPress any key to continue...");
                Console.ReadKey();
            }
        }
        public static string ReadRequired(string fieldName)
        {
            string? input;
            do
            {
                Console.Write($"Enter {fieldName}: ");
                input = Console.ReadLine();
            } while (string.IsNullOrWhiteSpace(input));

            return input;
        }
        static void AddAuthor(AutherBLL authorBLL)
        {
            try
            {
                Author author;
                string id;
                do
                {
                    id = ReadRequired("ID");

                    if (Regex.IsMatch(id, @"^\d{3}-\d{2}-\d{4}$"))
                        break;
                    Console.WriteLine("Invalid format! Example: 123-45-6789");

                } while (true);
              
                string fname = ReadRequired("First Name");
                string lname = ReadRequired("Last Name");
                string phone;
                do
                {
                    phone = ReadRequired("Phone");

                    if (phone.Length == 12)
                        break;

                    Console.WriteLine($"Must be exactly 12 characters.");

                } while (true);

                string? address;
                Console.Write("Enter Address: ");
                address = Console.ReadLine();

                string? city;
                Console.Write("Enter City: ");
                city = Console.ReadLine();

                Console.Write("Enter State (2 chars, optional): ");
                string? state = Console.ReadLine();
                state = string.IsNullOrEmpty(state) ? null :
                    (state.Length == 2 ? state : throw new Exception("State must be 2 characters"));

                string? zip;
                do
                {
                    Console.Write("Enter Zip (5 digits, optional): ");
                    zip = Console.ReadLine();
                    
                    if (String.IsNullOrWhiteSpace(zip))
                    {
                        zip = null;
                        break;
                    }
                    if (System.Text.RegularExpressions.Regex.IsMatch(zip, @"^\d{5}$"))
                    {
                        break;
                    }
                    Console.WriteLine("Zip must be 5 digits");
                    
                } while (true);

                Console.Write("Has Contract (true/false): ");
                bool value;

                while (!bool.TryParse(Console.ReadLine(), out value))
                {
                    Console.Write("Invalid. Enter true/false: ");
                }

                author = new Author {
                    Id=id,
                    FName= fname,
                    LName=lname,
                    Phone=phone,
                    Address=address,
                    City=city,
                    Contract=value,
                    State=state,
                    ZipCode=zip
                };

                authorBLL.AddAuthor(author);
                Console.WriteLine("Author added successfully!");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void DeleteAuthor(AutherBLL authorBLL)
        {
            try
            {
                Console.Write("Enter Author ID to delete: ");
                string? id = Console.ReadLine();

                if (authorBLL.DeleteAuthor(id))
                {
                     Console.WriteLine("Author deleted successfully!");
                }
                else
                {
                     Console.WriteLine("This Id doesn't exist");
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        static void GetAllAuthors(AutherBLL authorBLL)
        {
            try
            {
                List<Author> authors = authorBLL.GetAuthors();

                if (authors.Count == 0)
                {
                    Console.WriteLine("No authors found.");
                    return;
                }

                foreach (var a in authors)
                {
                    Console.WriteLine("----------------------------------");
                    Console.WriteLine($"ID: {a.Id}");
                    Console.WriteLine($"Name: {a.FName} {a.LName}");
                    Console.WriteLine($"Phone: {a.Phone}");
                    Console.WriteLine($"City: {a.City}");
                    Console.WriteLine($"Contract: {a.Contract}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
    }
}