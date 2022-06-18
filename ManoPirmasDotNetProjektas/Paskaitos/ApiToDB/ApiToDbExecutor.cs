using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.ApiToDB
{
    internal class ApiToDbExecutor : ITema
    {
        private readonly string _booksEndpoint = "https://openlibrary.org/books/";
        private readonly string _authorEndpoint = "https://openlibrary.org/authors/";

        private readonly int _bookLimit = 38247449;

        public async Task Run()
        {           
            var ListofRandomBookUrl = GenerateRandomBookUrl(1000);
        }

        private string[] GenerateRandomBookUrl(int quantity)
        {
            var random = new Random();

            var bookIds= new List<int>();

            while (bookIds.Count() < quantity)
            {
                int id = Convert.ToInt32(random.NextDouble() * (_bookLimit - 1) + 1);

                if (!bookIds.Contains(id))
                {
                    bookIds.Add(id);
                }
            }

            var booksUrl = new string[quantity];

            for (int i = 0; i < quantity; i++)
            {
                booksUrl[i] = $"{_booksEndpoint}OL{bookIds[i]}M.json";
            }

            return booksUrl;
        }
    }
}
