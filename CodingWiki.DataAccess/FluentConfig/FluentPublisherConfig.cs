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
    public class FluentPublisherConfig : IEntityTypeConfiguration<Fluent_Publisher>
    {
        public void Configure(EntityTypeBuilder<Fluent_Publisher> modelBuilder)
        {
            // Table Name

            // Columns Names

            // Constraints
            modelBuilder.HasKey(p => p.Publisher_Id);
            modelBuilder.Property(p => p.Name).IsRequired().HasMaxLength(100);

            // Relationships

        }
    }
}
