using ManoPirmasDotNetProjektas.Paskaitos.Logger;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.ApiToDB
{
    public class OpenLibraryAPI_Test : IOpenLibraryAPI
    {
        private readonly ILoggerServise _logger;

        public OpenLibraryAPI_Test(ILoggerServise logger)
        {
            _logger = logger;
        }

        public async Task<BookDto> GetBookFromUrl(string url) => new BookDto
        {
            type = null,
            title = "test Book",
            authors = null,
            publish_date = "2022-06-06",
            source_records = null,
            number_of_pages = 20,
            physical_format = "Physical Book",
            key = "5155",
            latest_revision = 1,
            revision = 1
        };

        public string[] GenerateRandomBookUrl(int quantity)
        {
            var result = new string[quantity];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = "test Url";
            }

            return result;
        }

        public Task AddAuthorToBook(BookDto book)
        {
            book.AuthorDto = new List<AuthorDto>();

            return Task.CompletedTask;
        }
    }
}
