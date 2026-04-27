using CompanyApp.Models;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.ComponentModel.DataAnnotations;
using System.Data;

namespace Lab05
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var appConfig = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var connString = appConfig.GetSection("constr").Value;
            using (var conn = new SqlConnection(connString))
            {
                conn.Open();
                #region Get All
                var sqlGetDepartments = "SELECT * FROM Department";
                // ===== Dynamic Binding ======
                var result = conn.Query(sqlGetDepartments);
                foreach (var row in result)
                {
                    Console.WriteLine(row);
                }
                Console.WriteLine("======================");
                var sqlGetEmployees = "SELECT * FROM Employee";
                var emps = conn.Query<Employee>(sqlGetEmployees);
                foreach (Employee emp in emps)
                {
                    Console.WriteLine(emp);
                }
                Console.WriteLine("==========================");
                #endregion

                #region Return Single Row
                string sqlGetById = "SELECT * FROM Employee WHERE SSN=@Id";
                Console.WriteLine(sqlGetById);
                var employee = conn.QuerySingleOrDefault<Employee>(sqlGetById, new { Id = "F6BDBB96-487D-47E5-BE7D-1845A61BE601" });
                if (employee == null)
                {
                    Console.WriteLine("Employee not found");
                }
                else
                {
                    Console.WriteLine(employee);
                }
                Console.WriteLine("======================");
                #endregion

                #region Return Single Value
                //string sqlGetCount = "SELECT COUNT(*) FROM Employee";
                //Console.WriteLine($"The Result of Query => {sqlGetCount}");
                //int numOfEmps = conn.ExecuteScalar<int>(sqlGetCount);
                //Console.WriteLine(numOfEmps);
                //Console.WriteLine("======================");

                //string sqlHighestSalary = "SELECT Max(Salary) FROM Employee";
                //Console.WriteLine($"The Result of Query => {sqlHighestSalary}");
                //int highestSalary = conn.ExecuteScalar<int>(sqlHighestSalary);
                //Console.WriteLine(highestSalary);
                //Console.WriteLine("======================");

                //string sqlAvgSalary = "SELECT AVG(Salary) FROM Employee";
                //Console.WriteLine($"The Result of Query => {sqlAvgSalary}");
                //int avgSalary = conn.ExecuteScalar<int>(sqlAvgSalary);
                //Console.WriteLine(avgSalary);
                //Console.WriteLine("======================");
                #endregion

                #region Insert
                //string sqlInsert = "INSERT INTO Employee(FName,LName,gender,MGR_SSN,DeptNum) VALUES(@FName,@LName,@gender,@MGR_SSN,@DeptNum)";
                //Employee employee1 = new Employee { FName = "Hamza", LName = "Mekawi", gender = Gender.Male, MGR_SSN = null, DeptNum = 5 };
                //int effectedRows = conn.Execute(sqlInsert, employee1);
                //Console.WriteLine($"Effected Rows {effectedRows}");
                #endregion

                #region Update
                //string sqlUpdate = "UPDATE Employee SET Salary=@Salary WHERE SSN=@Id ";
                //int updatedRows = conn.Execute(sqlUpdate, new { Salary = 1000, Id = "F6BDBB96-487D-47E5-BE7D-1845A61BE601" });
                //Console.WriteLine($"Updated {updatedRows} Rows");

                #endregion

                #region Delete
                //string sqlDelete = "Delete FROM Employee WHERE FName=@FName ";
                //int deletedRows = conn.Execute(sqlDelete, new { FName = "newName" });
                //Console.WriteLine($"Deleted {deletedRows} Rows");
                #endregion

                #region Join - Nav Property
                //string sqlJoin = @"SELECT e.SSN, e.FName, e.LName, d.ID, d.Name
                //                    FROM Employee e INNER JOIN Department d
                //                    ON e.DeptNum = d.ID";
                //var res = conn.Query<Employee, Department,Employee>(sqlJoin,
                //    (emp,dept) => { 
                //        emp.Department=dept;
                //        dept.Employees.Add(emp);
                //        return emp; 
                //    });
                //foreach (var item in res)
                //{
                //    Console.WriteLine($"{item.FName} {item.Department.Name}");
                //}
                #endregion


                #region Stored Procedure
                //int r = conn.Execute("sp_InsertEmployee",
                //    new { FName = "newName", LName = "newLastName", gender = "Male"},
                //    commandType: CommandType.StoredProcedure);
                //Console.WriteLine($"{r} rows ");

                //var res2 = conn.Query<Employee>("sp_GetAllEmployees",
                //    commandType: CommandType.StoredProcedure);
                //foreach (var item in res2)
                //{
                //    Console.WriteLine(item);
                //}
                #endregion
            }
        }
    }
}
