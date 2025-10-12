using CodingWiki.Model.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace CodingWiki.DataAccess.FluentConfig
{
    public class FluentBookDetailConfig : IEntityTypeConfiguration<Fluent_BookDetail>
    {
        public void Configure(EntityTypeBuilder<Fluent_BookDetail> modelBuilder)
        {
            // Table Name
            modelBuilder.ToTable("Fluent_BookDetails");

            // Columns Names
            modelBuilder.Property(bd => bd.NumberOfChapters).HasColumnName("NoOfChapters");

            // Constraints
            modelBuilder.HasKey(bd => bd.BookdDetail_Id);
            modelBuilder.Property(bd => bd.NumberOfChapters).IsRequired();
            modelBuilder.Property(bd => bd.Weight).HasMaxLength(50);

            // Relationships
            modelBuilder.HasOne(bd => bd.Book).WithOne(b => b.BookDetail)
                .HasForeignKey<Fluent_BookDetail>(bd => bd.Book_Id);

        }
    }
}
