using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.DataAccess.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Genre> Genres { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=CodingWikiDB; Trusted_Connection=True; TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(book => book.Price).HasPrecision(10, 5);
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "C# Programming", ISBN = "1234567890", Price = 29.99M },
                new Book { Id = 2, Title = "ASP.NET Core Guide", ISBN = "0987654321", Price = 39.99M },
                new Book { Id = 3, Title = "Entity Framework Core", ISBN = "1122334455", Price = 34.99M }
                );
            modelBuilder.Entity<Genre>().HasData(
                new Genre { GenreId = 1, GenreName = "Programming", DisplayOrder = 1},
                new Genre {GenreId = 2, GenreName = "Database", DisplayOrder = 2 },
                new Genre {GenreId = 3, GenreName = "Web Development", DisplayOrder = 3}
                );
        }
    }
}
