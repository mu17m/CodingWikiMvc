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
    public class FluentAuthorBookConfig : IEntityTypeConfiguration<Fluent_AuthorBookCustomize>
    {
        public void Configure(EntityTypeBuilder<Fluent_AuthorBookCustomize> modelBuilder)
        {
            // Table Name

            // Columns Names

            // Constraints
            modelBuilder.HasKey(ab => new { ab.Author_Id, ab.Book_Id });

            // Relationships
            modelBuilder.HasOne(ab => ab.Book).WithMany(a => a.AuthorBooks)
             .HasForeignKey(a => a.Book_Id);
            modelBuilder.HasOne(c => c.Author).WithMany(a => a.AuthorBooks)
                .HasForeignKey(c => c.Author_Id);
        }
    }
}
