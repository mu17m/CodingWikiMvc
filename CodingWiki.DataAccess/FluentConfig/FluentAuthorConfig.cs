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
    public class FluentAuthorConfig : IEntityTypeConfiguration<Fluent_Author>
    {
        public void Configure(EntityTypeBuilder<Fluent_Author> builder)
        {
            builder.HasKey(a => a.Author_Id);
            builder.Property(a => a.FirstName).IsRequired().HasMaxLength(50);
            builder.Property(a => a.LastName).IsRequired().HasMaxLength(50);
            builder.Property(a => a.Location).HasMaxLength(100);
            builder.Ignore(a => a.FullName);
        }
    }
}
