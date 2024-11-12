using Lab1_ASPNetConnectedMode.BLL;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace Lab1_ASPNetConnectedMode.DAL
{
    public class EmployeeDB
    {
        //VERSION2
        public static void SaveRecord(BLL.Employee emp)
        {
            SqlConnection connDB = UtilityDB.GetDBConnection();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = connDB;
            cmd.CommandText = "INSERT INTO Employees (EmployeeId, FirstName, LastName, JobTitle) " +
                              "VALUES (@EmployeeId, @FirstName, @LastName, @JobTitle)";

            // Using parameterized queries to prevent SQL injection
            cmd.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmd.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmd.Parameters.AddWithValue("@LastName", emp.LastName);
            cmd.Parameters.AddWithValue("@JobTitle", emp.JobTitle);

            cmd.ExecuteNonQuery();
            connDB.Close();
        }


        public static List<BLL.Employee> GetAllRecords()
        {
            SqlConnection connDB = UtilityDB.GetDBConnection();
            SqlCommand cmdSelectAll = new SqlCommand("SELECT * FROM Employees", connDB);
            SqlDataReader reader = cmdSelectAll.ExecuteReader();

            List<BLL.Employee> empList = new List<BLL.Employee>();
            while (reader.Read())
            {
                BLL.Employee emp = new BLL.Employee();
                    emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                    emp.FirstName = reader["FirstName"].ToString();
                    emp.LastName = reader["LastName"].ToString();
                    emp.JobTitle = reader["JobTitle"].ToString();
                    empList.Add(emp);             
            }

            connDB.Close();
            connDB.Dispose();   
            return empList;
        }

        public static BLL.Employee SearchRecord(int id)
        {
            BLL.Employee emp = new BLL.Employee();
            // connect DB
            SqlConnection conn = UtilityDB.GetDBConnection();
            string sql = "SELECT * FROM Employees " +
                         " WHERE EmployeeId = @EmployeeId";
            SqlCommand cmdSearch = new SqlCommand(sql, conn);
            cmdSearch.Parameters.AddWithValue("@EmployeeId", id);
            SqlDataReader reader = cmdSearch.ExecuteReader();
            if (reader.Read())
            {
                emp.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                emp.FirstName = reader["FirstName"].ToString();
                emp.LastName = reader["LastName"].ToString();
                emp.JobTitle = reader["JobTitle"].ToString();
            }
            else
            {
                emp = null;

            }
            conn.Close();
            conn.Dispose();
            return emp;
        }

        public static bool IsDuplicateId(int id)
        {
            BLL.Employee employee = SearchRecord(id);
            if (employee != null)
            {
                return true;
            }
            return false;
        }


        public static List<BLL.Employee> SearchRecord(string searchTerm, string searchField)
        {
            List<BLL.Employee> listE = new List<BLL.Employee>();
            SqlConnection conn = UtilityDB.GetDBConnection();

            // Adjust SQL based on the search field
            string sql = $"SELECT * FROM Employees WHERE {searchField} = @SearchTerm";
            SqlCommand cmdSelectByField = new SqlCommand(sql, conn);
            cmdSelectByField.Parameters.AddWithValue("@SearchTerm", searchTerm);

            SqlDataReader reader = cmdSelectByField.ExecuteReader();
            while (reader.Read())
            {
                BLL.Employee employee = new BLL.Employee();
                employee.EmployeeId = Convert.ToInt32(reader["EmployeeId"]);
                employee.FirstName = reader["FirstName"].ToString();
                employee.LastName = reader["LastName"].ToString();
                employee.JobTitle = reader["JobTitle"].ToString();
                listE.Add(employee);
            }
            conn.Close();
            conn.Dispose();
            return listE;
        }

        public static void UpdateRecord(BLL.Employee emp)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdUpdate = new SqlCommand();
            cmdUpdate.Connection = conn;
            string sql = "UPDATE Employees " + 
                         "SET     FirstName = @FirstName," + 
                         "        LastName = @LastName, " +
                         "        JobTitle = @JobTitle " +
                         "WHERE EmployeeId = @EmployeeId";

            cmdUpdate.CommandText = sql;

            cmdUpdate.Parameters.AddWithValue("@EmployeeId", emp.EmployeeId);
            cmdUpdate.Parameters.AddWithValue("@FirstName", emp.FirstName);
            cmdUpdate.Parameters.AddWithValue("@LastName", emp.LastName);
            cmdUpdate.Parameters.AddWithValue("@JobTitle", emp.JobTitle);

            cmdUpdate.ExecuteNonQuery();
            conn.Close();

        }

        public static void DeleteRecord(int empId)
        {
            SqlConnection conn = UtilityDB.GetDBConnection();
            SqlCommand cmdDelete = new SqlCommand();
            cmdDelete.Connection = conn;

            string sql = "DELETE FROM Employees WHERE EmployeeId = @EmployeeId";
            cmdDelete.CommandText = sql;

            cmdDelete.Parameters.AddWithValue("@EmployeeId", empId);
            cmdDelete.ExecuteNonQuery();
            conn.Close();   
        }
       
        
    }
}