using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.Settings
{
    public class AppSettings
    {
        public string BookStoreConnection { get; }

        public AppSettings(IConfiguration configuration)
        {
            BookStoreConnection = configuration.GetConnectionString("BookStoreConnection");
        }        
    }
}
