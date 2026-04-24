using Microsoft.Data.SqlClient;
using System.Data.Common;
using System.Transactions;

namespace Lab09
{
    internal class Program
    {
        static (string Name, int Total, double Average) GetStudentStats(dynamic student)
        {
            var marks = (List<int>)student.Marks;
            int total  = marks.Sum();
            
            double avg = marks.Average();

            return (student.Name, total, avg);
        }
        static void Main(string[] args)
        {
            #region Transaction
            using (SqlConnection con = new("Server = . ; Database = DigitalCurrency ; Integrated Security = SSPI ; TrustServerCertificate = True"))
            {
                con.Open();
                SqlTransaction sqlTransaction = con.BeginTransaction();
                try
                {
                    Console.WriteLine("Enter the ID to make a withdraw.");
                    int fromId = int.Parse(Console.ReadLine() ?? "-1");
                    Console.WriteLine("Enter the ID to make a deposit.");
                    int toId = int.Parse(Console.ReadLine() ?? "-1");
                    Console.WriteLine("Enter The Amount of the money:");
                    decimal amount = decimal.Parse(Console.ReadLine() ?? "0");

                    SqlCommand cmdFrom = new SqlCommand("SELECT Id, Balance FROM Wallets WHERE Id = @Id", con, sqlTransaction);

                    cmdFrom.Parameters.AddWithValue("@Id", fromId);

                    Wallet walletFrom = null;
                    using (SqlDataReader reader = cmdFrom.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            walletFrom = new Wallet
                            {
                                Id = reader.GetInt32(0),
                                Balance = reader.GetDecimal(1)
                            };
                        }
                    }
                    if (walletFrom == null)
                        throw new Exception("Sender wallet not found");

                    SqlCommand cmdTo = new SqlCommand("SELECT Id, Balance FROM Wallets WHERE Id = @Id", con, sqlTransaction);
                    cmdTo.Parameters.AddWithValue("@Id", toId);
                    Wallet walletTo = null;
                    using (SqlDataReader reader = cmdTo.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            walletTo = new Wallet
                            {
                                Id = reader.GetInt32(0),
                                Balance = reader.GetDecimal(1)
                            };
                        }
                    }

                    if (walletTo == null)
                        throw new Exception("Receiver wallet not found");
                    if (walletFrom.Balance < amount)
                        throw new Exception("balance is Not Enough");

                    walletFrom.Balance -= amount;
                    walletTo.Balance += amount;

                    SqlCommand updateFrom = new SqlCommand("UPDATE Wallets SET Balance = @Balance WHERE Id = @Id", con, sqlTransaction);
                    updateFrom.Parameters.AddWithValue("@Id", walletFrom.Id);
                    updateFrom.Parameters.AddWithValue("@Balance", walletFrom.Balance);
                    updateFrom.ExecuteNonQuery();

                    SqlCommand updateTo = new SqlCommand("UPDATE Wallets SET Balance = @Balance WHERE Id = @Id", con, sqlTransaction);

                    updateTo.Parameters.AddWithValue("@Id", walletTo.Id);
                    updateTo.Parameters.AddWithValue("@Balance", walletTo.Balance);
                    updateTo.ExecuteNonQuery();

                    sqlTransaction.Commit();
                    Console.WriteLine(" ===== The Transaction has been successfully ====== ");
                }
                catch (Exception ex)
                {
                    sqlTransaction.Rollback();
                    Console.WriteLine(ex.Message);
                }

            }
            #endregion

            #region Tuple
            var student = new
            {
                Name = "Amira",
                Marks = new List<int> { 80, 90, 100 }
            };

            var result = GetStudentStats(student);
            Console.WriteLine($"Name {result.Name} Total Marks: {result.Total} Avgerage: {result.Average}");
            #endregion
        }
    }
}
