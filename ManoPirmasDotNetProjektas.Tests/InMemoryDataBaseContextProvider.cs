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
    }
}
