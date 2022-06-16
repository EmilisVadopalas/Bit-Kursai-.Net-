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

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_configuration.GetConnectionString("BookStoreConnection"));
        }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Author>(a => a.HasNoKey());
        }
    }
}
