using ManoPirmasDotNetProjektas.Paskaitos.AdoNet;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManoPirmasDotNetProjektas.Paskaitos.EntityFramework
{
    public class BookStoreContext : DbContext
    {
        private IConfiguration _configuration;

        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }        

        public BookStoreContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public BookStoreContext(DbContextOptions<BookStoreContext> cOptions)
            :base(cOptions)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (_configuration is not null)
            {
                optionsBuilder.UseSqlServer(_configuration.GetConnectionString("BookStoreConnection"));
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>().Property(e => e.Sex)
                .HasConversion(
                    s => s.ToString(), // is klases i Duombaze
                    s => s.ToLower() == "vyras" // is db i klase
                        ? Lytis.Vyras 
                        : Lytis.Moteris);

            modelBuilder.Entity<Book>(b => b.HasKey(k => k.BookId));
        }
    }
}
