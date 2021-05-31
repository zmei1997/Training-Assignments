using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;
namespace DapperTutorial.Data.Repository
{
    class DBHelper
    {
        public SqlConnection GetConnection()
        {
            //    IConfigurationBuilder builder = new ConfigurationBuilder();
            //    builder.AddJsonFile("appsettings.json");
            //    IConfigurationRoot root = builder.Build();
            //    string str = root.GetConnectionString("CompanyDB");

            string str = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetConnectionString("CompanyDB");
            return new SqlConnection(str);
        }
    }
}
