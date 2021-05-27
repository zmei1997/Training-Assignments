using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration.Json;

namespace Data.Repository
{
    public class DbHelper
    {
        public static string GetConnectionString()
        {
            IConfigurationBuilder conf = new ConfigurationBuilder();
            IConfigurationRoot root = conf.AddJsonFile("appsettings.json").Build();
            return root.GetConnectionString("MinionsDB");
        }
    }
}
