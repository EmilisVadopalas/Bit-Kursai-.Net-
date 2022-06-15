using ManoPirmasDotNetProjektas.Paskaitos.AdoNet.CustomOrm;
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
        private readonly DatabaseEngine _dbEngine;

        public AdoNetExecutor(
            AppSettings settings,
            ILoggerServise logger,
            DatabaseEngine dbEngine)
        {
            _connectionString = settings.BookStoreConnection;
            _logger = logger;
            _dbEngine = dbEngine;
        }

        public async Task Run()
        {
            //await PrintBooks();

            //foreach (var book in await GetBookList())
            //{
            //    Console.WriteLine(book);
            //}

            var x = await _dbEngine.SelectAll<Book>();
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

        //private async Task<IEnumerable<Knygos>> GetBookList()
        //{
        //    var books = new List<Knygos>();

        //    using var conn = new SqlConnection(_connectionString);
        //    var sqlCmd = new SqlCommand("SELECT [KnygosID]," +
        //        "[Pavadinimas]," +
        //        "[Žanras]," +
        //        "[Puslapių_kiekis]," +
        //        "[Originalo_kalba]," +
        //        "[AutoriusID] " +
        //        $"FROM [Knygos]", conn);

        //    await conn.OpenAsync();
        //    using var reader = await sqlCmd.ExecuteReaderAsync();

        //    while (await reader.ReadAsync())
        //    {
        //        books.Add(new Knygos(
        //            reader.GetInt32(0), //"KnygosID"
        //            reader.GetString(1), //Pavadinimas
        //            reader.GetString(2), //Žanras
        //            reader.GetInt32(3), //Puslapių_kiekis
        //            reader.GetString(4), //Originalo_kalba
        //            reader.GetInt32(5))); //AutoriusID
        //    }

        //    return books;
        //}
                
    }
}
