using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using TechBooksPublishing.DataAccessLayer;
using TechBooksPublishing.Models;

namespace TechBooksPublishing.BusinessLogicLayer
{
    public class AutherBLL
    {
        private AuthorDAL authorDAL;
        public AutherBLL()
        {
            authorDAL = new AuthorDAL();
        }

        public List<Author> ConvertDataTableToList(DataTable dt)
        {
            List<Author> authors = new List<Author>();

            foreach (DataRow row in dt.Rows)
            {
                authors.Add(ConvertDataRowToAuthor(row));
            }

            return authors;
        }
        public Author ConvertDataRowToAuthor(DataRow row)
        {
            return new Author
            {
                Id = row["au_id"]?.ToString(),
                FName = row["au_fname"]?.ToString(),
                LName = row["au_lname"]?.ToString(),
                Phone = row["phone"]?.ToString(),
                Address = row["address"]?.ToString(),
                City = row["city"]?.ToString(),
                State = row["state"]?.ToString(),
                ZipCode = row["zip"]?.ToString(),
                Contract = row["contract"] != DBNull.Value && Convert.ToBoolean(row["contract"])
            };
        }

        public List<Author> GetAuthors()
        {
            DataTable dt = authorDAL.GetAuthors();
            return ConvertDataTableToList(dt);
        }

        public int AddAuthor(Author author)
        {
            if (author == null)
                throw new ArgumentNullException(nameof(author));

            if (string.IsNullOrWhiteSpace(author.Id))
                throw new Exception("Author ID is required.");

            if (string.IsNullOrWhiteSpace(author.FName))
                throw new Exception("First Name is required.");

            if (string.IsNullOrWhiteSpace(author.LName))
                throw new Exception("Last Name is required.");
            if (author.Phone.Length != 12)
                throw new Exception("Author phone length must equal 12.");

            if (author.Id.Length > 11) // 100-10-1000
                throw new Exception("Author ID exceeds allowed length.");

            try
            {
                return authorDAL.AddAuthor(author);

            }
            catch (Exception ex)
            {
                throw new Exception("Failed to add author. Please try again.", ex);
            }
        }

        public bool DeleteAuthor(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
                throw new Exception("ID cannot be empty.");

            try
            {

                int result = authorDAL.DeleteAuthorById(id);
           
                return result > 0;
            }
            catch (Exception ex)
            {
                throw new Exception($"Failed to delete author. Please try later.{ex.Message}", ex);
            }
        }
    }
}
