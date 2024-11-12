using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Lab1_ASPNetConnectedMode.DAL
{
    public class UtilityDB
    {
        public static SqlConnection GetDBConnection()
        {
            SqlConnection conn = new SqlConnection();
            conn.ConnectionString = ConfigurationManager.ConnectionStrings["ConnectDB"].ConnectionString;
            conn.Open();
            return conn;
        }
    }
}