using System;
using System.Data;
using System.Diagnostics;
using System.Net.Http.Headers;
using Microsoft.Data.SqlClient;
using TechBooksPublishing.Models;


 namespace TechBooksPublishing.DataAccessLayer
{
    public class AuthorDAL
    {
        private string connectionString = "Data Source=.;Initial Catalog=pubs;Integrated Security=True;TrustServerCertificate=True;";

        private SqlConnection sqlConnection;
        public AuthorDAL() {
            sqlConnection = new SqlConnection(connectionString);
        }
        public DataTable GetAuthors() // Disconnected Mode
        {
            try
            {

                string sqlQuery = "SELECT * FROM authors";
                SqlDataAdapter adapter = new SqlDataAdapter(sqlQuery, sqlConnection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public void AddAuthor(Author author)
        {
            try {
                // 1. I will get the table into the memory
                string selectQuery = "SELECT * FROM authors";
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, sqlConnection);

                //string insertQuery = @"INSERT INTO authors (au_id, au_fname, au_lname, phone, address, city, state, zip, contract) 
                //                        VALUES(@Id, @FName, @LName, @Phone, @Address, @City, @State, @Zip, @Contract)";
                //adapter.InsertCommand.Connection = sqlConnection;
                //adapter.InsertCommand.CommandText = insertQuery;
                //adapter.InsertCommand.Parameters.Add("@Id", SqlDbType.VarChar, 11).Value = author.Id;
                //adapter.InsertCommand.Parameters.Add("@FName", SqlDbType.VarChar, 20).Value = author.FName;
                //adapter.InsertCommand.Parameters.Add("@LName", SqlDbType.VarChar, 40).Value = author.LName;
                //adapter.InsertCommand.Parameters.Add("@Phone", SqlDbType.Char, 12).Value = author.Phone;
                //adapter.InsertCommand.Parameters.Add("@Address", SqlDbType.VarChar, 40).Value = author.Address;
                //adapter.InsertCommand.Parameters.Add("@City", SqlDbType.VarChar, 20).Value = author.City;
                //adapter.InsertCommand.Parameters.Add("@State", SqlDbType.Char, 2).Value = author.State;
                //adapter.InsertCommand.Parameters.Add("@Zip", SqlDbType.Char, 5).Value = author.ZipCode;
                //adapter.InsertCommand.Parameters.Add("@Contract", SqlDbType.Bit).Value = author.Contract;

                SqlCommandBuilder builder = new SqlCommandBuilder(adapter);

                DataTable table = new DataTable();
                adapter.Fill(table);
                // add itin memory 
                DataRow newRow = table.NewRow();
                newRow["au_id"] = author.Id;
                newRow["au_fname"] = author.FName;
                newRow["au_lname"] = author.LName;
                newRow["phone"] = author.Phone;
                newRow["address"] = author.Address;
                newRow["city"] = author.City;
                newRow["state"] = author.State;
                newRow["zip"] = author.ZipCode;
                newRow["contract"] = author.Contract;

                table.Rows.Add(newRow);

                adapter.Update(table);
            }
            catch (Exception ex) {
                throw;
            }
        }

        public void DeleteAuthorById(string Id)
        {
            try
            {
                string selectQuery = @"SELECT * FROM authors    
                                    WHERE au_id = @Id;";
                SqlDataAdapter adapter = new SqlDataAdapter(selectQuery, sqlConnection);
                string s = adapter.SelectCommand.CommandText;
                Console.WriteLine($"Query of SELECT by Id ${s}");
                adapter.SelectCommand.Parameters.Add("@Id", SqlDbType.VarChar, 11).Value = Id;

                string deletedQuery = @"DELETE FROM authors WHERE au_id = @Id;";
                adapter.DeleteCommand.Connection = sqlConnection;
                adapter.DeleteCommand.CommandText = deletedQuery;
                adapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.VarChar, 11).Value = Id;
                adapter.DeleteCommand.Parameters.Add("@Id", SqlDbType.VarChar, 11, "au_id").SourceVersion = DataRowVersion.Original;
                DataTable table = new DataTable();
                adapter.Fill(table);

                if (table.Rows.Count > 0)
                {
                    table.Rows[0].Delete();

                    adapter.Update(table);
                }
            }
            catch (Exception ex) {
                Console.WriteLine("The EROR"+ex.Message);
                throw;
            }
        }
    }
}
