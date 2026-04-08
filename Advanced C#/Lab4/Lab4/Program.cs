using System.Data;
using TechBooksPublishing.DataAccessLayer;
using TechBooksPublishing.Models;

namespace Lab4
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int effectedRows;
            AuthorDAL d = new AuthorDAL();
            
            effectedRows = d.AddAuthor(new Author()
            {
                Id = "100-10-1000",
                Address = null,
                FName = "test",
                LName = "test",
                City = null,
                Contract = false,
                Phone = "01222466368",
                State = null,
                ZipCode = null
            });
            Console.WriteLine("Added "+effectedRows+" Rows");
            effectedRows = d.DeleteAuthorById("100-10-1000");
            Console.WriteLine("Deleted "+effectedRows+" Rows");

            DataTable q = d.GetAuthors();
            foreach (DataRow row in q.Rows)
            {
                string name = row["au_fname"].ToString();
                Console.WriteLine(name);
            }



 
        }
    }
}
