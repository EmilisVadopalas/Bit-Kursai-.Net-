using ManoPirmasDotNetProjektas.Paskaitos.EntityFramework;
using ManoPirmasDotNetProjektas.Paskaitos.Logger;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.ApiToDB
{
    internal class ApiToDbExecutor : ITema
    {      
        private readonly BookStoreContext _bookStoreContext;
        private readonly ILoggerServise _logger;
        private readonly IOpenLibraryAPI _openLibraryAPI;

        public ApiToDbExecutor(
            ILoggerServise logger, 
            BookStoreContext bookStoreContext,
            IOpenLibraryAPI openLibraryAPI)
        {
            _logger = logger;
            _bookStoreContext = bookStoreContext;
            _openLibraryAPI = openLibraryAPI;
        }

        public async Task Run()
        {
            var books = await GetBooksFromUrl(_openLibraryAPI.GenerateRandomBookUrl(10)); //sugeneruojam URL, padarom http GET Json parsinam i klase
            await AddAuthorsToBooks(books); // Knygoms atsisiunciam ju autorius is API, sugeneruojam isparsina i autoriaus klase
            await AddAuthorToDatabase(books); // Pridedam autorius i DB
            await AddBooksToDataBase(books); // Pridedam knygas i DB
        }       

        private async Task<List<BookDto>> GetBooksFromUrl(string[] urls)
        {
            var books = new List<BookDto>();

            foreach (string url in urls)
            {
                books.Add(await _openLibraryAPI.GetBookFromUrl(url));
            }

            return books;
        }

        private async Task AddAuthorsToBooks(List<BookDto> books)
        {
            foreach (var book in books)
            {
                await _openLibraryAPI.AddAuthorToBook(book);
            }
        }

        private async Task AddAuthorToDatabase(BookDto book)
        {
            if (book?.AuthorDto is not null)
            {
                foreach (var authorsDto in book.AuthorDto)
                {
                    var author = new AdoNet.Author(authorsDto);

                    _bookStoreContext.Add(author);
                    await _bookStoreContext.SaveChangesAsync();

                    authorsDto.DatabaseID = author.Id;

                }
            }
        }

        private async Task AddAuthorToDatabase(List<BookDto> books)
        {
            foreach(var book in books)
            {
                await AddAuthorToDatabase(book);
            }
        }

        private async Task AddBookToDataBase(BookDto book)
        {
            if (book is not null)
            {
                var bookdb = new AdoNet.Book(book);
                _bookStoreContext.Add(bookdb);
                await _bookStoreContext.SaveChangesAsync();
                
            }
        }

        private async Task AddBooksToDataBase(IEnumerable<BookDto> books)
        {
            var booklist = new List<AdoNet.Book>();

            foreach (var book in books)
            {
                if (book is not null)
                {
                    booklist.Add(new AdoNet.Book(book));
                }
            }

            _bookStoreContext.AddRange(booklist);
            await _bookStoreContext.SaveChangesAsync();
        }
    }
}

