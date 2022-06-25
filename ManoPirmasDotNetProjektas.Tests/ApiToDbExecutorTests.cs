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
        public async Task GetBooksFromUrl_CallsApiForManyUrl_ListOfBooks()
        {
            var urls = new string[] { "test1of4", "test2of4", "test3of4", "test4of4" };
            var book1 = new BookDto
            {
                type = null,
                title = "test Book 1",
                authors = null,
                publish_date = "2022-06-06",
                source_records = null,
                number_of_pages = 20,
                physical_format = "Physical Book",
                key = "5155",
                latest_revision = 1,
                revision = 1
            };
            var book2 = new BookDto
            {
                type = null,
                title = "test Book 2",
                authors = null,
                publish_date = "2022-06-06",
                source_records = null,
                number_of_pages = 20,
                physical_format = "Physical Book",
                key = "5155",
                latest_revision = 1,
                revision = 1
            };
            var book3 = new BookDto
            {
                type = null,
                title = "test Book 3",
                authors = null,
                publish_date = "2022-06-06",
                source_records = null,
                number_of_pages = 20,
                physical_format = "Physical Book",
                key = "5155",
                latest_revision = 1,
                revision = 1
            };
            var book4 = new BookDto
            {
                type = null,
                title = "test Book 4",
                authors = null,
                publish_date = "2022-06-06",
                source_records = null,
                number_of_pages = 20,
                physical_format = "Physical Book",
                key = "5155",
                latest_revision = 1,
                revision = 1
            };
            _openLibraryAPI.Setup(x => x.GetBookFromUrl("test1of4")).ReturnsAsync(book1);
            _openLibraryAPI.Setup(x => x.GetBookFromUrl("test2of4")).ReturnsAsync(book2);
            _openLibraryAPI.Setup(x => x.GetBookFromUrl("test3of4")).ReturnsAsync(book3);
            _openLibraryAPI.Setup(x => x.GetBookFromUrl("test4of4")).ReturnsAsync(book4);

            var result = await _sut.GetBooksFromUrl(urls);

            //ar iskviest buvo API
            _openLibraryAPI.Verify(x => x.GetBookFromUrl("test1of4"), Times.Once);
            _openLibraryAPI.Verify(x => x.GetBookFromUrl("test2of4"), Times.Once);
            _openLibraryAPI.Verify(x => x.GetBookFromUrl("test3of4"), Times.Once);
            _openLibraryAPI.Verify(x => x.GetBookFromUrl("test4of4"), Times.Once);

            //Ar resultas toks kokio tikimes
            result.Should().BeEquivalentTo(new List<BookDto>(new BookDto[] { book1, book2, book3, book4 }));
        }

        //Api ok, 0 ulr
        [Test]
        public async Task GetBooksFromUrl_CallsApiForEmptyList_ListOfBooks()
        {
            var urls = new string[] { };

            var result = await _sut.GetBooksFromUrl(urls);

            //ar iskviest buvo API
            _openLibraryAPI.Verify(x => x.GetBookFromUrl(""), Times.Never);

            //Ar resultas toks kokio tikimes
            result.Should().BeEquivalentTo(new List<BookDto>());
        }


        //Api return null for onë of many
        [Test]
        public async Task GetBooksFromUrl_CallsApiForManyUrlsOneReturnNull_ListOfBooks()
        {
            var urls = new string[] { "test1of4", "test2of4", "test3of4", "test4of4" };
            var book1 = new BookDto
            {
                type = null,
                title = "test Book 1",
                authors = null,
                publish_date = "2022-06-06",
                source_records = null,
                number_of_pages = 20,
                physical_format = "Physical Book",
                key = "5155",
                latest_revision = 1,
                revision = 1
            };
            BookDto book2 = null;
            var book3 = new BookDto
            {
                type = null,
                title = "test Book 3",
                authors = null,
                publish_date = "2022-06-06",
                source_records = null,
                number_of_pages = 20,
                physical_format = "Physical Book",
                key = "5155",
                latest_revision = 1,
                revision = 1
            };
            var book4 = new BookDto
            {
                type = null,
                title = "test Book 4",
                authors = null,
                publish_date = "2022-06-06",
                source_records = null,
                number_of_pages = 20,
                physical_format = "Physical Book",
                key = "5155",
                latest_revision = 1,
                revision = 1
            };
            _openLibraryAPI.Setup(x => x.GetBookFromUrl("test1of4")).ReturnsAsync(book1);
            _openLibraryAPI.Setup(x => x.GetBookFromUrl("test2of4")).ReturnsAsync(book2);
            _openLibraryAPI.Setup(x => x.GetBookFromUrl("test3of4")).ReturnsAsync(book3);
            _openLibraryAPI.Setup(x => x.GetBookFromUrl("test4of4")).ReturnsAsync(book4);

            var result = await _sut.GetBooksFromUrl(urls);

            //ar iskviest buvo API
            _openLibraryAPI.Verify(x => x.GetBookFromUrl("test1of4"), Times.Once);
            _openLibraryAPI.Verify(x => x.GetBookFromUrl("test2of4"), Times.Once);
            _openLibraryAPI.Verify(x => x.GetBookFromUrl("test3of4"), Times.Once);
            _openLibraryAPI.Verify(x => x.GetBookFromUrl("test4of4"), Times.Once);

            //Ar resultas toks kokio tikimes
            result.Should().BeEquivalentTo(new List<BookDto>(new BookDto[] { book1, book2, book3, book4 }));
        }

        //Api return null for one of one
        [Test]
        public async Task GetBooksFromUrl_CallsApiForOneUrlAndApiReturnsNull_ListOfBooks()
        {
            var urls = new string[] { "test1of1" };
            BookDto book = null;
            _openLibraryAPI.Setup(x => x.GetBookFromUrl("test1of1")).ReturnsAsync(book);

            var result = await _sut.GetBooksFromUrl(urls);

            //ar iskviest buvo API
            _openLibraryAPI.Verify(x => x.GetBookFromUrl("test1of1"), Times.Once);

            //Ar resultas toks kokio tikimes
            result.Should().BeEquivalentTo(new List<BookDto>(new BookDto[] { book }));
        }

        //Api return null for many of many
        [Test]
        public async Task GetBooksFromUrl_CallsApiForManyUrlAndAllReturnNulls_ListOfBooks()
        {
            var urls = new string[] { "test1of4", "test2of4", "test3of4", "test4of4" };
            BookDto book = null;
            _openLibraryAPI.Setup(x => x.GetBookFromUrl("test1of4")).ReturnsAsync(book);
            _openLibraryAPI.Setup(x => x.GetBookFromUrl("test2of4")).ReturnsAsync(book);
            _openLibraryAPI.Setup(x => x.GetBookFromUrl("test3of4")).ReturnsAsync(book);
            _openLibraryAPI.Setup(x => x.GetBookFromUrl("test4of4")).ReturnsAsync(book);

            var result = await _sut.GetBooksFromUrl(urls);

            //ar iskviest buvo API
            _openLibraryAPI.Verify(x => x.GetBookFromUrl("test1of4"), Times.Once);
            _openLibraryAPI.Verify(x => x.GetBookFromUrl("test2of4"), Times.Once);
            _openLibraryAPI.Verify(x => x.GetBookFromUrl("test3of4"), Times.Once);
            _openLibraryAPI.Verify(x => x.GetBookFromUrl("test4of4"), Times.Once);

            //Ar resultas toks kokio tikimes
            result.Should().BeEquivalentTo(new List<BookDto>(new BookDto[] { book, book, book, book }));
        }

        #endregion

        #region AddAuthorsToBooks

        //1 book one author
        [Test]
        public async Task AddAuthorsToBooks_AddsOneAuthorToBook_Task()
        {
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
            var booksAuthor = new AuthorDto
            {
                name = "testuotojas",
                personal_name = "testeris",
                last_modified = null,
                key = "author id 1",
                date = "1999-09-06",
                type = null,
                id = 1,
                revision = 16,
                DatabaseID = 541
            };
            var resultBook = new BookDto
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
                revision = 1,
                AuthorDto = new List<AuthorDto>(new AuthorDto[1] { booksAuthor })
            };
            var listBooks = new List<BookDto>(new BookDto[] { book });
            _openLibraryAPI.Setup(x => x.AddAuthorToBook(book)).Callback(() =>
            {
                book.AuthorDto = new List<AuthorDto>(new AuthorDto[1] { booksAuthor });
            });

            await _sut.AddAuthorsToBooks(listBooks);

            _openLibraryAPI.Verify(x => x.AddAuthorToBook(book), Times.Once);
            listBooks.FirstOrDefault().Should().BeEquivalentTo(resultBook);
        }

        //1 book zero authors
        [Test]
        public async Task AddAuthorsToBooks_AddsZeroAuthorsToOneBook_Task()
        {
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
            AuthorDto booksAuthor = null;
            var resultBook = new BookDto
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
                revision = 1,
                AuthorDto = new List<AuthorDto>(new AuthorDto[1] { booksAuthor })
            };
            var listBooks = new List<BookDto>(new BookDto[] { book });
            _openLibraryAPI.Setup(x => x.AddAuthorToBook(book)).Callback(() =>
            {
                book.AuthorDto = new List<AuthorDto>(new AuthorDto[1] { booksAuthor });
            });

            await _sut.AddAuthorsToBooks(listBooks);

            _openLibraryAPI.Verify(x => x.AddAuthorToBook(book), Times.Once);
            listBooks.FirstOrDefault().Should().BeEquivalentTo(resultBook);
        }

        //1 book many authors
        [Test]
        public async Task AddAuthorsToBooks_AddsManyAuthorsToOneBook_Task()
        {
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
            var booksAuthor1 = new AuthorDto
            {
                name = "testuotojas 1",
                personal_name = "testeris",
                last_modified = null,
                key = "author id 1",
                date = "1999-09-06",
                type = null,
                id = 1,
                revision = 16,
                DatabaseID = 541
            };
            var booksAuthor2 = new AuthorDto
            {
                name = "testuotojas 2",
                personal_name = "testeris",
                last_modified = null,
                key = "author id 1",
                date = "1999-09-06",
                type = null,
                id = 2,
                revision = 16,
                DatabaseID = 541
            };
            var booksAuthor3 = new AuthorDto
            {
                name = "testuotojas 3",
                personal_name = "testeris",
                last_modified = null,
                key = "author id 1",
                date = "1999-09-06",
                type = null,
                id = 3,
                revision = 16,
                DatabaseID = 541
            };
            var resultBook = new BookDto
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
                revision = 1,
                AuthorDto = new List<AuthorDto>(new AuthorDto[] { booksAuthor1, booksAuthor2, booksAuthor3 })
            };
            var listBooks = new List<BookDto>(new BookDto[] { book });
            _openLibraryAPI.Setup(x => x.AddAuthorToBook(book)).Callback(() =>
            {
                book.AuthorDto = new List<AuthorDto>(new AuthorDto[] { booksAuthor1, booksAuthor2, booksAuthor3 });
            });

            await _sut.AddAuthorsToBooks(listBooks);

            _openLibraryAPI.Verify(x => x.AddAuthorToBook(book), Times.Once);
            listBooks.FirstOrDefault().Should().BeEquivalentTo(resultBook);
        }

        //many books diferent authors 0,1,many
        [Test]
        public async Task AddAuthorsToBooks_AddsManyOneZeroAuthorsToManyBook_Task()
        {
            var book1 = new BookDto
            {
                type = null,
                title = "test Book 1",
                authors = null,
                publish_date = "2022-06-06",
                source_records = null,
                number_of_pages = 20,
                physical_format = "Physical Book",
                key = "5155",
                latest_revision = 1,
                revision = 1
            };
            var book2 = new BookDto
            {
                type = null,
                title = "test Book 2",
                authors = null,
                publish_date = "2022-06-06",
                source_records = null,
                number_of_pages = 20,
                physical_format = "Physical Book",
                key = "5155",
                latest_revision = 1,
                revision = 1
            };
            var book3 = new BookDto
            {
                type = null,
                title = "test Book 3",
                authors = null,
                publish_date = "2022-06-06",
                source_records = null,
                number_of_pages = 20,
                physical_format = "Physical Book",
                key = "5155",
                latest_revision = 1,
                revision = 1
            };
            var booksAuthor11 = new AuthorDto
            {
                name = "testuotojas 11",
                personal_name = "testeris",
                last_modified = null,
                key = "author id 1",
                date = "1999-09-06",
                type = null,
                id = 1,
                revision = 16,
                DatabaseID = 541
            };
            var booksAuthor12 = new AuthorDto
            {
                name = "testuotojas 12",
                personal_name = "testeris",
                last_modified = null,
                key = "author id 1",
                date = "1999-09-06",
                type = null,
                id = 2,
                revision = 16,
                DatabaseID = 541
            };
            var booksAuthor13 = new AuthorDto
            {
                name = "testuotojas 13",
                personal_name = "testeris",
                last_modified = null,
                key = "author id 1",
                date = "1999-09-06",
                type = null,
                id = 3,
                revision = 16,
                DatabaseID = 541
            };
            var booksAuthor2 = new AuthorDto
            {
                name = "testuotojas 2",
                personal_name = "testeris",
                last_modified = null,
                key = "author id 1",
                date = "1999-09-06",
                type = null,
                id = 4,
                revision = 16,
                DatabaseID = 541
            };
            AuthorDto booksAuthor3 = null;
            var resultBook1 = new BookDto
            {
                type = null,
                title = "test Book 1",
                authors = null,
                publish_date = "2022-06-06",
                source_records = null,
                number_of_pages = 20,
                physical_format = "Physical Book",
                key = "5155",
                latest_revision = 1,
                revision = 1,
                AuthorDto = new List<AuthorDto>(new AuthorDto[] { booksAuthor11, booksAuthor12, booksAuthor13 })
            };
            var resultBook2 = new BookDto
            {
                type = null,
                title = "test Book 2",
                authors = null,
                publish_date = "2022-06-06",
                source_records = null,
                number_of_pages = 20,
                physical_format = "Physical Book",
                key = "5155",
                latest_revision = 1,
                revision = 1,
                AuthorDto = new List<AuthorDto>(new AuthorDto[] { booksAuthor2 })
            };
            var resultBook3 = new BookDto
            {
                type = null,
                title = "test Book 3",
                authors = null,
                publish_date = "2022-06-06",
                source_records = null,
                number_of_pages = 20,
                physical_format = "Physical Book",
                key = "5155",
                latest_revision = 1,
                revision = 1,
                AuthorDto = new List<AuthorDto>(new AuthorDto[] { booksAuthor3 })
            };
            var listBooks = new List<BookDto>(new BookDto[] { book1, book2, book3 });
            _openLibraryAPI.Setup(x => x.AddAuthorToBook(book1)).Callback(() =>
            {
                book1.AuthorDto = new List<AuthorDto>(new AuthorDto[] { booksAuthor11, booksAuthor12, booksAuthor13 });
            });
            _openLibraryAPI.Setup(x => x.AddAuthorToBook(book2)).Callback(() =>
            {
                book2.AuthorDto = new List<AuthorDto>(new AuthorDto[] { booksAuthor2 });
            });
            _openLibraryAPI.Setup(x => x.AddAuthorToBook(book3)).Callback(() =>
            {
                book3.AuthorDto = new List<AuthorDto>(new AuthorDto[] { booksAuthor3 });
            });

            await _sut.AddAuthorsToBooks(listBooks);

            _openLibraryAPI.Verify(x => x.AddAuthorToBook(book1), Times.Once);
            _openLibraryAPI.Verify(x => x.AddAuthorToBook(book2), Times.Once);
            _openLibraryAPI.Verify(x => x.AddAuthorToBook(book3), Times.Once);
            listBooks.Should().BeEquivalentTo(new List<BookDto>(new BookDto[] { resultBook1, resultBook2, resultBook3 }));
        }

        //zero books
        [Test]
        public async Task AddAuthorsToBooks_DoesNothingWhenZeroBook_Task()
        {
            var listBooks = new List<BookDto>();
            var resultlist = new List<BookDto>();

            await _sut.AddAuthorsToBooks(listBooks);

            listBooks.Should().BeEquivalentTo(resultlist);
        }
        #endregion
    }
}
