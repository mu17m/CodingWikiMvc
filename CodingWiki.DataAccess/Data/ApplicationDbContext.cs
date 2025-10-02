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
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publisher> Publishers { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<BookDetail> BookDetails { get; set; }
        public DbSet<AuthorBookCustomize> AuthorBooks { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=CodingWikiDB; Trusted_Connection=True; TrustServerCertificate=True;");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().Property(book => book.Price).HasPrecision(10, 5);
            modelBuilder.Entity<AuthorBookCustomize>().HasKey(ab => new { ab.Author_Id, ab.Book_Id});
            //modelBuilder.Entity<BookDetail>().HasOne(bd => bd.Book)
            //    .WithOne(b => b.BookDetail)
            //    .HasForeignKey<BookDetail>(bd => bd.Book_Id);
            //modelBuilder.Entity<Book>().OwnsOne(c => c.Authors);
            //modelBuilder.Owned<Book>();
            modelBuilder.Entity<Book>().HasData(
                new Book { Id = 1, Title = "C# Programming", ISBN = "1234567890", Price = 29.99M, Publisher_Id = 1 },
                new Book { Id = 2, Title = "ASP.NET Core Guide", ISBN = "0987654321", Price = 39.99M , Publisher_Id = 2},
                new Book { Id = 3, Title = "Entity Framework Core", ISBN = "1122334455", Price = 34.99M , Publisher_Id = 3}
                );
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Programming", DisplayOrder = 1},
                new Category { CategoryId = 2, Name = "Database", DisplayOrder = 2 },
                new Category {CategoryId = 3, Name = "Web Development", DisplayOrder = 3}
                );
            modelBuilder.Entity<Publisher>().HasData(
                new Publisher { Publisher_Id = 1, Name = "Maui", Location = "USA" },
                new Publisher { Publisher_Id = 2, Name = "TechBooks", Location = "UK" },
                new Publisher { Publisher_Id = 3, Name = "CodePress", Location = "Canada" }
                );
        }
    }
}
