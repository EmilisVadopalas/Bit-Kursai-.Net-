using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.ApiToDB
{
    public interface IOpenLibraryAPI
    {
        public Task<BookDto> GetBookFromUrl(string url);

        public string[] GenerateRandomBookUrl(int quantity);

        public Task AddAuthorToBook(BookDto book);
    }
}
