using ManoPirmasDotNetProjektas.Paskaitos.Logger;
using ManoPirmasDotNetProjektas.Paskaitos.Settings;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.AdoNet
{
    public class AdoNetExecutor : ITema
    {
        private readonly ILoggerServise _logger;
        private readonly string _connectionString;

        public AdoNetExecutor(AppSettings settings, ILoggerServise logger)
        {
            _connectionString = settings.BookStoreConnection;
            _logger = logger;
        }

        public async Task Run()
        {
            await PrintBooks();

        }

        private async Task PrintBooks()
        {
            string sqlinjectionHacker = "'; Delete From [Knygos] where [KnygosID] = 19 --";

            using var conn = new SqlConnection(_connectionString);
            var sqlCmd = new SqlCommand("SELECT [KnygosID]," +
                "[Pavadinimas]," +
                "[Žanras]," +
                "[Puslapių_kiekis]," +
                "[Originalo_kalba]," +
                "[AutoriusID] " +
                $"FROM [Knygos] where Pavadinimas like '%@SearchTerm%' order by KnygosID desc", conn);

            // 1. Establishing connection
            await conn.OpenAsync();
            sqlCmd.Parameters.Add(new SqlParameter("@SearchTerm", sqlinjectionHacker));

            // 2. Reading data
            using var reader = await sqlCmd.ExecuteReaderAsync();

            Console.WriteLine($"[KnygosID],[Pavadinimas],[Žanras],[Puslapių_kiekis],[Originalo_kalba],[AutoriusID]");

            while (await reader.ReadAsync())
            {
                Console.WriteLine($"{reader.GetValue(0)},{reader.GetValue(1)},{reader.GetValue(2)},{reader.GetValue(3)},{reader.GetValue(4)},{reader.GetValue(5)}");
            }
        }

        private async Task<IEnumerable<Book>> GetBookList()
        {

        }
    }
}
