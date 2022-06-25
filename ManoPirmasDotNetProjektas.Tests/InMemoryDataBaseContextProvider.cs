using ManoPirmasDotNetProjektas.Paskaitos.AdoNet;
using ManoPirmasDotNetProjektas.Paskaitos.EntityFramework;
using Microsoft.EntityFrameworkCore;

namespace ManoPirmasDotNetProjektas.Tests
{
    public static class InMemoryDataBaseContextProvider
    {
        public static BookStoreContext GetBookStoreContext()
        {
            var dbContextOptions = new DbContextOptionsBuilder<BookStoreContext>()
                .UseInMemoryDatabase("Knygos").Options;

            return new BookStoreContext(dbContextOptions);
        }

        public static void Seed(this BookStoreContext dbContext, Action customSeed)
        {
            dbContext.Database.EnsureDeleted();
            dbContext.Database.EnsureCreated();

            customSeed?.Invoke();

            dbContext.SaveChanges();
        }

        public static void CustomSeed(BookStoreContext bookStoreContext)
        {
            var pirmasAuth = new Author
            {
                Name = "nezinomas",
                Surname = "autorius",
                BirthDate = new DateTime(1771, 01, 01),
                Sex = Lytis.Vyras,
                NativeLanguage = "Lietuviu"
            };

            bookStoreContext.Authors.Add(pirmasAuth);

            bookStoreContext.Books.Add(new Book
            {
                Name = "Unit Testai C#",
                Type = "Mokymosi",
                PageCount = 66,
                OriginalLanguage = "Lietuviu",
                AuthorId = pirmasAuth.Id
            });
        }
    }
}
