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
            //await DeleteBookByName("nauja knyga");

            var book = await FindBookByName("Unit Testai");
            book.Author = _bookContext.Authors.Where(a => a.Id == book.AuthorId).FirstOrDefault();
        }

        private async Task DeleteBookByName(string bookNameToDelete)
        {
            var UnitTestBook = _bookContext.Books.Where(x => x.Name == bookNameToDelete).FirstOrDefault();

            if (UnitTestBook != null)
            {
                Console.WriteLine($"Book to be deleted: {UnitTestBook.Name}");

                _bookContext.Books.Remove(UnitTestBook);

                await _logger.LogDebug($"book \"{UnitTestBook.Name}\" has been deleted.");

                await _bookContext.SaveChangesAsync();
            }
            else
            {
                Console.WriteLine($"There is not book in database with Name: \"{bookNameToDelete}\"");
                await _logger.LogWarning($"There is not book in database with Name: \"{bookNameToDelete}\"");
            }
        }
        private async Task<Book> FindBookByName(string bookName)
        {
            var book = _bookContext.Books.Where(book => book.Name == bookName).FirstOrDefault();

            if(book is null)
            {
                Console.WriteLine($"Cannot find book with name {bookName}");
                await _logger.LogDebug($"Cannot find book with name {bookName}");
            }

            Console.WriteLine(book);

            return book;
        }
    }
}
