using ManoPirmasDotNetProjektas.Paskaitos.AdoNet;
using ManoPirmasDotNetProjektas.Paskaitos.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.EntityFramework
{
    public class EntityFrameworkExecutor : ITema
    {
        private readonly BookStoreContext _bookContext;
        private readonly ILoggerServise _logger;

        public EntityFrameworkExecutor(BookStoreContext bookContext, ILoggerServise logger)
        {
            _bookContext = bookContext;
            _logger = logger;
        }

        public async Task Run()
        {
            await UpdateUnitTestBook();
        }

        public async Task UpdateUnitTestBook()
        {
            var UnitTestBook = _bookContext.Books.Where(x => x.Name == "Unit Testai" ).FirstOrDefault();

            Console.WriteLine($"page count: {UnitTestBook.PageCount}");

            UnitTestBook.PageCount = 999;

            var newBook = new Book
            {
                Name = "nauja knyga",
                Type = "moksline",
                PageCount = 48,
                OriginalLanguage = "Lietuviu",
                AuthorId = 24
            };

            _bookContext.Books.Add(newBook);

            Console.WriteLine($"page count: {UnitTestBook.PageCount}");

            await _bookContext.SaveChangesAsync();
        }
    }
}
