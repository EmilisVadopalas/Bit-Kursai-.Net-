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
            //ReadBooksLinq(20);
            //ReadBooksLinqMini(20);
            //ReadBooksLinqQuery(20);
            //ExtensionTesting();
            //BookMiniTasksWithLinq();


            //foreach (var skaicius in ReturnAllNumbersWithYield())
            //{
            //    Console.WriteLine(skaicius);
            //}

            //JoinsReducersAndGroups();

            //FirstTask();
            SecondTask();

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
            var lib = _dbContext.Books.Where(x => x.Name.Length > 1);
            
            //rasti knygas kurios kurios turi daugiau negu n puslapiu
            var books = lib.Where(x => x.PageCount > 2000).Take(8);

            var bookslist = books.ToList();

            //isrykioti knygas pagal puslapiu kieki
            books = lib.OrderBy(x => x.PageCount);

            //isrykioti knygas pagal puslapiu kieki ir pagal pavadinima
            books = lib.OrderBy(x => x.PageCount).ThenBy(x => x.Name);

            books = lib.Where(x => x.Name[0] == 'L' && x.Name.Length > 5);

            var numberss = new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };

            //pasirinkiti i masyva knygu tik knygu pavadinimus
            string[] bookNames = lib.Select(x => x.Name).ToArray();

            //is knygos sugeneruoti annonymous objekta
            var namePage = lib.Select(x => new { name = x.Name, page = x.PageCount });

            //is knygos sugeneruoti jos json reprensentacija
            string[] jsonBooks = lib.Select(x => JsonConvert.SerializeObject(x)).ToArray();

            // rasti knyga trumpiausiu pavadinimu
            var shortestNameBook = lib.OrderBy(x => x.Name.Length).FirstOrDefault();            

            //rasti knyga ilgiausiu pavadinimu
            string LongestNameBook = lib.Select(x => x.Name).OrderByDescending(x => x.Length).FirstOrDefault();

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
            //string nameCon = lib.Select(x => x.Name).Where(x =>
            //    x.Contains("pro")).Aggregate("start: ", (current, next) => current + " | " + next, x => x.ToString());

            //Console.WriteLine(nameCon);

            //rasti knygu kieki ir irasyti i kintamaji
            var count = lib.Count();

            //paimti visas knygas minus (count - 2) (skip() - metodas) kaip ir Take() tik atvirksciai 
            books = lib.Skip(count - 2);

            foreach (var book in books)
            {
                Console.WriteLine(book);
            }

            //sudeti 10knygu i array 
            Book[] knygos = lib.Take(10).ToArray();

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

        private IEnumerable<int> ReturnsAllNumbers()
        {
            var count = 100000000;
            var numbers = new int[count];

            for(int i = 0; i < count; i++)
            {
                numbers[i] = i + 1;
            }

            return numbers;
        }       

        private IEnumerable<int> ReturnAllNumbersWithYield()
        {
            var count = 100000000;
            var current = 1;

            while(current < count)
            {
                yield return current;

                current++;
            }           
        }

        private void JoinsReducersAndGroups()
        {
            // ... group
            List<Employee> employeeList = new()
            {
                new Employee() { Id = 1, Name = "John", Salary = 130, Role = "Programmer", DepId = 1 },
                new Employee() { Id = 2, Name = "Moin", Salary = 210, Role = "PPC Manager", DepId = 2 },
                new Employee() { Id = 3, Name = "Bill", Salary = 180, Role = "QA Engineer", DepId = 1 },
                new Employee() { Id = 4, Name = "Ram", Salary = 200, Role = "PPC Manager", DepId = 2 },
                new Employee() { Id = 5, Name = "Ron", Salary = 150, Role = "Programmer", DepId = 1 },
                new Employee() { Id = 6, Name = "Bron", Salary = 150, Role = "Programmer", DepId = 1 }
            };

            Console.WriteLine($"Avarage salary: {employeeList.Average(x => x.Salary):c}");

            //... Question: what is the average salary for each role

            var groupedQ = employeeList.GroupBy(e => e.Role);

            foreach (var group in groupedQ)
            {
                Console.WriteLine("Group: {0}, employees: {1}, average salary: {2}",
                    group.Key, string.Join(", ", group.Select(e => e.Name).ToList()), group.Select(e => e.Salary).Average().ToString("c"));
            }

            // ... Question: what is the average number of employees getting the same salary in each role
            var nestedGroupingQ = employeeList.GroupBy(e => (e.Role, e.Salary));
            foreach (var group in nestedGroupingQ)
            {
                //Console.WriteLine("Group key: {0}, group value: {1}", group.Key, string.Join(", ", group));
                Console.WriteLine("Role name: {0}, salary: {1}, # people w/ same salary: {2}",
                    group.Key.Role, group.Key.Salary, group.Count());
            }

            // ... join
            List<Department> departmentList = new()
            {
                new Department() { Id = 1, Name = "IT" },
                new Department() { Id = 2, Name = "Marketing" },
            };

            var q = employeeList.Join(departmentList, e => e.DepId, d => d.Id, (e, d) => new { e.Id, e.Name, e.Role, DepName = d.Name });
            Console.WriteLine(string.Join("\n", q.ToList()));


            // ... SelectMany
            var students = new List<Student>()
            {
                new Student() { ID = 1, Name = "James", Email = "James@j.com", Programming = new List<string>() { "C#", "Jave", "C++" } },
                new Student() { ID = 2, Name = "Sam", Email = "Sara@j.com", Programming = new List<string>() { "WCF", "SQL Server", "C#" } },
                new Student() { ID = 3, Name = "Patrik", Email = "Patrik@j.com", Programming = new List<string>() { "MVC", "Jave", "LINQ" } },
                new Student() { ID = 4, Name = "Sara", Email = "Sara@j.com", Programming = new List<string>() { "ADO.NET", "C#", "LINQ" } }
            };

            Console.WriteLine("\nselect many\n");

            //List<string> l = students.Select(s => s.Programming).ToList(); 
            var l = students.SelectMany(s => s.Programming).ToList();
            Console.WriteLine(string.Join("\n", l));

            Console.WriteLine("\n\n\n....");
            // ... SelectMany is commonly used with distinct
            var lDistinct = students.SelectMany(s => s.Programming).Distinct().ToList();
            Console.WriteLine(string.Join("\n", lDistinct));
        }

        private void FirstTask()
        {
            var books = _dbContext.Books.Join(_dbContext.Authors, // ka su kuo joininam
                book => book.AuthorId, // pradzio pasirenkam prie ko joininsim
                author => author.Id, // tada pasirenkam ka joininsim
                (book, author) => new // tada is abieju obectu sukuriam nauja, arba esama klase, arba anonimini obj
                {
                    AuthorsName = author.Name,
                    AuthorsSurname =author.Surname,
                    BookName = book.Name,
                    NumberOfPages = book.PageCount
                })
                .Where(x => x.BookName != "nezinomas" && x.NumberOfPages != 0 && x.AuthorsName != "Nezinomas").Take(100)
                .ToList(); //pridejau filtra kad butu tik gerai is API nuskaitytos knygos, be nezinomu pavadinimu

            foreach(var book in books)
            {
                Console.WriteLine($"\n{book.AuthorsName} {book.AuthorsSurname}");
                Console.WriteLine($"{book.BookName} ({book.NumberOfPages})\n");
            }                       
        }

        private void SecondTask()
        {
            var querrybooks = from b in _dbContext.Books
                              join a in _dbContext.Authors
                                  on b.AuthorId equals a.Id
                              where b.Name != "nezinomas"
                                && b.PageCount > 0
                                && a.Name != "nezinomas"
                              select new
                              {
                                  AuthorsName = a.Name,
                                  AuthorsSurname = a.Surname,
                                  BookName = b.Name,
                                  NumberOfPages = b.PageCount
                              };

            foreach (var book in querrybooks.Take(100).ToList())
            {
                Console.WriteLine($"\n{book.AuthorsName} {book.AuthorsSurname}");
                Console.WriteLine($"{book.BookName} ({book.NumberOfPages})\n");
            }
        }
    }

    public class Student
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<string> Programming { get; set; }
    }

    public class Department
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override string ToString()
        {
            return $"{{ {Id} : {Name} }}";
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public string Role { get; set; }
        public int DepId { get; set; }

        public override string ToString()
        {
            return $"{{ {Id} : {Name} }}";
        }
    }
}




