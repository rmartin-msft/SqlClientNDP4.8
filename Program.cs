using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Data.Common;

namespace SqlClientNDP4_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string database_name = ConfigurationManager.AppSettings["databaseName"];
            string server_name = ConfigurationManager.AppSettings["databaseServerName"];
            string user_id = ConfigurationManager.AppSettings["userID"];
            string password = ConfigurationManager.AppSettings["password"];
                        
            string connectionString = $"Server={server_name};Authentication=Active Directory Service Principal; Encrypt=True;Database={database_name}; User Id={user_id}; Password={password}";

            Console.WriteLine(connectionString);

            // https://www.nuget.org/packages/Microsoft.EntityFramework.SqlServer/

            //using (SqlConnection conn = new SqlConnection(connectionString))
            //{
            //    conn.Open();
            //}
        }
    }
}
