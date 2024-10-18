
using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Linq;
using System.Data.Entity;
using System.Data.Common;
using System.Windows.Forms;
using SqlClientNDP4_8;
using System.Data.Entity.SqlServer;

// For details on setting up Service Principal/Manged Identity to connect to Azure SQL Databases
// see the documentation at:
//
// https://learn.microsoft.com/en-us/azure/azure-sql/database/authentication-aad-service-principal-tutorial?view=azuresql
//
// For details on how to configuring the EF6 SqlClient provider Microsoft.Data.SqlClient provider:
//
// https://www.nuget.org/packages/Microsoft.EntityFramework.SqlServer/
//

namespace SqlClientNDP4_8
{
    public class AppServiceConfiguration : MicrosoftSqlDbConfiguration
    {
        public AppServiceConfiguration()
        {
            SetProviderFactory("System.Data.SqlClient", Microsoft.Data.SqlClient.SqlClientFactory.Instance);
            SetProviderServices("System.Data.SqlClient", MicrosoftSqlProviderServices.Instance);
            SetExecutionStrategy("System.Data.SqlClient", () => new MicrosoftSqlAzureExecutionStrategy());
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connecting to database and reading all records...");

            var ctx = new metal_dbEntities();

            var allMetals = from x in ctx.metals select x;

            foreach (var m in allMetals)
            {
                Console.WriteLine(m.metal_name);
            }            
        }
    }
}
