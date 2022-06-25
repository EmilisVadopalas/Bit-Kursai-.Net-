using FluentAssertions;
using ManoPirmasDotNetProjektas.Paskaitos.ApiToDB;
using ManoPirmasDotNetProjektas.Paskaitos.EntityFramework;
using ManoPirmasDotNetProjektas.Paskaitos.Logger;
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
    public class ApiToDbExecutorTests
    {
        private BookStoreContext _inMemorybookStoreContext;
        private Mock<ILoggerServise> _loggerMock;
        private Mock<IOpenLibraryAPI> _openLibraryAPI;

        private ApiToDbExecutor _sut;

        [SetUp]
        public void SetUp()
        {
            _loggerMock = new Mock<ILoggerServise>();
            _openLibraryAPI = new Mock<IOpenLibraryAPI>();

            _inMemorybookStoreContext = InMemoryDataBaseContextProvider.GetBookStoreContext();
            _inMemorybookStoreContext.Seed(() => InMemoryDataBaseContextProvider.CustomSeed(_inMemorybookStoreContext));

            _sut = new ApiToDbExecutor(_loggerMock.Object, _inMemorybookStoreContext, _openLibraryAPI.Object);
        }

        #region GetBooksFromUrl

        //Api ok, 1 url
        [Test]
        public async Task GetBooksFromUrl_CallsApiForOneUrl_ListOfBooks()
        {
            var urls = new string[] { "test1of1" };
            var book = new BookDto
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
            _openLibraryAPI.Setup(x => x.GetBookFromUrl("test1of1")).ReturnsAsync(book);

            var result = await _sut.GetBooksFromUrl(urls);

            //ar iskviest buvo API
            _openLibraryAPI.Verify(x => x.GetBookFromUrl("test1of1"), Times.Once);

            //Ar resultas toks kokio tikimes
            result.Should().BeEquivalentTo(new List<BookDto>(new BookDto[] { book }));
        }

        //Api Ok,  > 1 url
        [Test]
        public void GetBooksFromUrl_CallsApiForManyUrl_ListOfBooks()
        {

        }

        //Api ok, 0 ulr
        [Test]
        public void GetBooksFromUrl_CallsApiForEmptyList_ListOfBooks()
        {

        }

        //Api return null for on of many
        public void GetBooksFromUrl_CallsApiForManyUrlsOneReturnNull_ListOfBooks()
        {

        }

        //Api return null for one of one
        public void GetBooksFromUrl_CallsApiForOneUrlAndApiReturnsNull_ListOfBooks()
        {

        }

        //Api return null for many of many
        public void GetBooksFromUrl_CallsApiForManyUrlAndAllReturnNulls_ListOfBooks()
        {

        }

        #endregion
    }
}
