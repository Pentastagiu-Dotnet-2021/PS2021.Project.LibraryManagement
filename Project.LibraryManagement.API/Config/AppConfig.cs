using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project.LibraryManagement.API.Config
{
    public class AppConfig : IAppConfig
    {
        private string _connectionString;
        public static AppConfig Instance { get; }
        public static IConfiguration Configuration { get; set; }

        private AppConfig()
        {
        }

        static AppConfig()
        {
            Instance = new AppConfig();
        }

        public string ConnectionString => _connectionString ??= Configuration.GetConnectionString("LibraryManagementConnection");
    }
}
