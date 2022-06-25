using FluentAssertions;
using ManoPirmasDotNetProjektas.Paskaitos.AdoNet;
using ManoPirmasDotNetProjektas.Paskaitos.EntityFramework;
using ManoPirmasDotNetProjektas.Paskaitos.Linq;
using ManoPirmasDotNetProjektas.Paskaitos.Logger;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Tests
{
    [TestFixture]
    public class LinqExecutorTests
    {
        private LinqExecutor _sut;

        private Mock<ILoggerServise> _loggerServiseMock;
        private BookStoreContext _BookStoreContextMock;

        [SetUp]
        public void SetUp()
        {
            _loggerServiseMock = new Mock<ILoggerServise>();
            _BookStoreContextMock = InMemoryDataBaseContextProvider.GetBookStoreContext();

            _BookStoreContextMock.Seed(() => CustomSeed(_BookStoreContextMock));

            _sut = new LinqExecutor(_loggerServiseMock.Object, _BookStoreContextMock);
        }
        
        [Test]
        public void ReadBooksLinq_ReadOneBookFromDB_IEnumerableBook()
        {          
            var resultBook = new Book
            {
                BookId = 1,
                Name = "Unit Testai C#",
                Type = "Mokymosi",
                PageCount = 66,
                OriginalLanguage = "Lietuviu",
                AuthorId = 1,
            };          

            var result =_sut.ReadBooksLinq(1);

            result.Should().BeEquivalentTo(new List<Book>(new Book[] { resultBook }));
        }

        [Test]
        public void ReadBooksLinq_ReadZeroBookFromDB_IEnumerableBook()
        {
            _loggerServiseMock.Setup(x => x.LogInfo($"bus nuskaityta {-5} knygu")).Throws(new Exception("test error"));
            var resultBook = new Book
            {
                BookId = 1,
                Name = "Unit Testai C#",
                Type = "Mokymosi",
                PageCount = 66,
                OriginalLanguage = "Lietuviu",
                AuthorId = 1,
            };

            var result = _sut.ReadBooksLinq(-5);

            result.Should().BeEquivalentTo(new List<Book>());
            _loggerServiseMock.Verify(x => x.LogInfo($"bus nuskaityta {-5} knygu"), Times.Once);
        }

        [Test]
        public void ReadBooksLinq_ReadMinusOneBookFromDB_IEnumerableBook()
        {
            var resultBook = new Book
            {
                BookId = 1,
                Name = "Unit Testai C#",
                Type = "Mokymosi",
                PageCount = 66,
                OriginalLanguage = "Lietuviu",
                AuthorId = 1,
            };

            var result = _sut.ReadBooksLinq(-1);

            result.Should().BeEquivalentTo(new List<Book>());
        }

        private void CustomSeed(BookStoreContext bookStoreContext)
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
