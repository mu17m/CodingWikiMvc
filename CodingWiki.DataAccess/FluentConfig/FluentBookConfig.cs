using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.DataAccess.FluentConfig
{
    public class FluentBookConfig : IEntityTypeConfiguration<Fluent_Book>
    {
        public void Configure(EntityTypeBuilder<Fluent_Book> modelBuilder)
        {
            // Table Name

            // Column Name

            // Constraints
            modelBuilder.HasKey(b => b.Book_Id);
            modelBuilder.Property(b => b.Title).IsRequired().HasMaxLength(100);
            modelBuilder.Property(b => b.ISBN).IsRequired().HasMaxLength(20);
            modelBuilder.Property(b => b.Price).HasPrecision(10, 5);
            modelBuilder.Ignore(b => b.PriceRange);

            // Relationships
            modelBuilder.HasOne(b => b.Publisher).WithMany(p => p.Books)
                .HasForeignKey(b => b.Publisher_Id);
        }
    }
}
