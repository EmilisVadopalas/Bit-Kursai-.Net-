using ManoPirmasDotNetProjektas.Paskaitos.EntityFramework;
using ManoPirmasDotNetProjektas.Paskaitos.Logger;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ManoPirmasDotNetProjektas.Paskaitos.Extensions;
using Newtonsoft.Json;
using ManoPirmasDotNetProjektas.Paskaitos.AdoNet;

namespace ManoPirmasDotNetProjektas.Paskaitos.Linq
{
    public class LinqExecutor : ITema
    {
        private readonly string _baseDirectory = @"C:\Users\Emeil\source\repos\ManoPirmasDotNetProjektas\ManoPirmasDotNetProjektas\bin\Debug\net6.0";

        private readonly ILoggerServise _logger;
        private readonly BookStoreContext _dbContext;

        public LinqExecutor(ILoggerServise logger, BookStoreContext dbContext)
        {
            _logger = logger;
            _dbContext = dbContext;
        }

        public Task Run()
        {
            //ReadLargeFilesNoLinq();
            //Console.WriteLine();
            //ReadLargeFilesWithLinqQuerySyntax();
            //Console.WriteLine();
            //ReadLargeFilesWithLinqMethodSyntax();
            ReadBooksLinq(20);
            ReadBooksLinqMini(20);
            ReadBooksLinqQuery(20);
            ExtensionTesting();

            BookMiniTasksWithLinq();

            return Task.CompletedTask;
        }

        private void ReadLargeFilesNoLinq()
        {
            var dirInfo = new DirectoryInfo(_baseDirectory);
            var files = dirInfo.GetFiles();
            Array.Sort(files, (x, y) => y.Length.CompareTo(x.Length));

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"{files[i].Name,-55} : {files[i].Length}");
            }
        }

        private void ReadLargeFilesWithLinqQuerySyntax()
        {
            var filesQ = from file in new DirectoryInfo(_baseDirectory).GetFiles()
                         orderby file.Length descending
                         select file;

            foreach (var file in filesQ.Take(10))
            {
                Console.WriteLine($"{file.Name,-55} : {file.Length}");
            }
        }

        private void ReadLargeFilesWithLinqMethodSyntax()
        {
            var filesQ = new DirectoryInfo(_baseDirectory).GetFiles().OrderByDescending(f => f.Length).Take(3);
           
            foreach (var file in filesQ)
            {
                Console.WriteLine($"{file.Name,-55} : {file.Length}");
            }
        }

        private void ReadBooksLinq(int quantity)
        {                       
            var books = _dbContext.Books.OrderByDescending(x => x.PageCount).Take(quantity);

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Name,-80} psl: {book.PageCount}");
            }

            Console.WriteLine();
        }

        private void ReadBooksLinqMini(int quantity)
        {
            _dbContext.Books.OrderByDescending(x => x.PageCount).Take(quantity)
                .AsParallel().ForAll(book => 
                { 
                    Console.WriteLine($"{book.Name,-80} psl: {book.PageCount}"); 
                });

            Console.WriteLine();
        }

        private void ReadBooksLinqQuery(int quantity)
        {
            var books = (from book in _dbContext.Books
                        orderby book.PageCount descending
                        select book).Take(quantity);

            foreach (var book in books)
            {
                Console.WriteLine($"{book.Name,-80} psl: {book.PageCount}");
            }

            Console.WriteLine();
        }

        private void ExtensionTesting()
        {
            var booksfddasdasrs = _dbContext.Books;
            var booksfdrs = _dbContext.Books.TopLongestBooks(20);
            var books = _dbContext.Books.SelectTopBy(x => x.PageCount, 20);
        }

        private void BookMiniTasksWithLinq()
        {
            var lib = _dbContext.Books;
            //rasti knygas kurios kurios turi daugiau negu X puslapiu
            var books = lib.Where(x => x.PageCount > 2000);

            //isrykioti knygas pagal puslapiu kieki
            books = lib.OrderBy(x => x.PageCount);

            //isrykioti knygas pagal puslapiu kieki ir pagal pavadinima
            books = lib.OrderBy(x => x.PageCount).ThenBy(x => x.Name);

            //pasirinkiti i masyva knygu tik knygu pavadinimus
            var bookNames = lib.Select(x => x.Name);

            //is knygos sugeneruoti annonymous objekta
            var namePage = lib.Select(x => new { x.Name, x.PageCount });

            //is knygos sugeneruoti jos json reprensentacija
            var jsonBooks = lib.Select(x => JsonConvert.SerializeObject(x));

            // rasti knyga trumpiausiu pavadinimu
            var shortestNameBook = lib.OrderBy(x => x.Name.Length).FirstOrDefault();

            //rasti knyga ilgiausiu pavadinimu
            var LongestNameBook = lib.OrderByDescending(x => x.Name.Length).FirstOrDefault();

            //rasti knygu puslapiu vidurki
            var AvrgPageCount = lib.Average(x => x.PageCount);

            //rasti knygu kieki
            var booksCount = lib.Count();

            //rasti ar bent viena knyga knyga yra 155 puslapiu
            var doesAny = lib.Any(x => x.PageCount == 155);

            //rasti ar visos knygos yra > 0 puslapiu
            var doesAll = lib.All(x => x.PageCount > 0);

            //rasti ar bent vienos knygos pavadinime yra tekstas 'pro'
            var containsPro = lib.Any(x => x.Name.Contains("pro"));

            //rasti knygas kuriu tekstuose yra 'pro'
            books = lib.Where(x => x.Name.Contains("pro")); 

            //joininti concatinti keliu knygu pavadinimus
            var nameCon = string.Concat("|||||", lib.Select(x => x.Name));

            //rasti knygu kieki ir irasyti i kintamaji
            var count = lib.Count();

            //paimti visas knygas minus (count - 2) (skip() - metodas) kaip ir Take() tik atvirksciai 
            books = lib.Skip(count - 2);

            //sudeti 10knygu i array 
            Book[] knygos = lib.ToArray();

            //is array konvertuoti i List<Books>
            List<Book> knyhos = knygos.ToList();

            //is  list konvertuoti atgal i array
            knygos = knyhos.ToArray();

            //iskviesti metododa ToList().ForEach({expression})
            lib.Where(x => x.PageCount > 100).ToList().ForEach(x =>
            {
                Console.WriteLine($"{x.Name,-75} si knyga ilgesne nei 100 psl ({x.PageCount})");
            });
        }

    }
}




