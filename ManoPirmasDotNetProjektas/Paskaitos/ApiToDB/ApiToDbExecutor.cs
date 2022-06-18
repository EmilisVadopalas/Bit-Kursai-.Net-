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
        private readonly string _booksEndpoint = "https://openlibrary.org/books/";
        private readonly string _baseEndpoint = "https://openlibrary.org";

        private readonly int _bookLimit = 38247449;


        private readonly BookStoreContext _bookStoreContext;
        private readonly ILoggerServise _logger;

        public ApiToDbExecutor(ILoggerServise logger, BookStoreContext bookStoreContext)
        {
            _logger = logger;
            _bookStoreContext = bookStoreContext;
        }

        public async Task Run()
        {
            var books = await GetBooksFromUrl(GenerateRandomBookUrl(10)); //sugeneruojam URL, padarom http GET Json parsinam i klase
            await AddAuthorsToBooks(books); // Knygoms atsisiunciam ju autorius is API, sugeneruojam isparsina i autoriaus klase
            await AddAuthorToDatabase(books); // Pridedam autorius i DB
            await AddBooksToDataBase(books); // Pridedam knygas i DB
        }

        private string[] GenerateRandomBookUrl(int quantity)
        {
            var random = new Random();

            var bookIds = new List<int>();

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

        private async Task<BookDto> GetBookFromUrl(string url)
        {
            try
            {
                using var client = new HttpClient();
                var result = await client.GetAsync(url);
                var body = await result.Content.ReadAsStringAsync();

                try
                {
                    return JsonConvert.DeserializeObject<BookDto>(body);
                }
                catch (Exception ex)
                {
                    await _logger.LogError("cannot deserialize responce to BookDto");
                    await _logger.LogError($"Body of response: {body}");
                    await _logger.LogError(ex.Message);
                    await _logger.LogError(ex.StackTrace);
                }
            }
            catch (WebException ex)
            {
                await _logger.LogError($"Failed to reach {url}, status: ({ex.Status})");
                await _logger.LogError(ex.Message);
                await _logger.LogError(ex.StackTrace);
            }
            catch (Exception ex)
            {
                await _logger.LogError($"Failed to reach {url}");
                await _logger.LogError(ex.Message);
                await _logger.LogError(ex.StackTrace);
            }

            return null;
        }

        private async Task<List<BookDto>> GetBooksFromUrl(string[] urls)
        {
            var books = new List<BookDto>();

            foreach (string url in urls)
            {
                books.Add(await GetBookFromUrl(url));
            }

            return books;
        }

        private async Task AddAuthorToBook(BookDto book)
        {
            book.AuthorDto = new List<AuthorDto>();

            if (book?.authors is not null)
            {
                foreach (var author in book.authors)
                {
                    var url = $"{_baseEndpoint}{author.key}.json";

                    try
                    {
                        using var client = new HttpClient();
                        var result = await client.GetAsync(url);
                        var body = await result.Content.ReadAsStringAsync();

                        try
                        {
                            book.AuthorDto.Add(JsonConvert.DeserializeObject<AuthorDto>(body));
                        }
                        catch (Exception ex)
                        {
                            await _logger.LogError("cannot deserialize responce to AuthorDto class");
                            await _logger.LogError($"Body of response: {body}");
                            await _logger.LogError(ex.Message);
                            await _logger.LogError(ex.StackTrace);
                        }
                    }
                    catch (WebException ex)
                    {
                        await _logger.LogError($"Failed to reach {url}, status: ({ex.Status})");
                        await _logger.LogError(ex.Message);
                        await _logger.LogError(ex.StackTrace);
                    }
                    catch (Exception ex)
                    {
                        await _logger.LogError($"Failed to reach {url}");
                        await _logger.LogError(ex.Message);
                        await _logger.LogError(ex.StackTrace);
                    }
                }
            }
        }

        private async Task AddAuthorsToBooks(List<BookDto> books)
        {
            foreach (var book in books)
            {
                await AddAuthorToBook(book);
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

