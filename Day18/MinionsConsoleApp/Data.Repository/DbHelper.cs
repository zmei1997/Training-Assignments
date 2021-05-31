using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Data.Repository
{
    public class DbHelper
    {
        public static string GetConnectionString()
        {
            return new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("MinionsDB");
        }

        public SqlConnection GetConnection()
        {
            string str = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("MinionsDB");
            return new SqlConnection(str);
        }
    }
}
