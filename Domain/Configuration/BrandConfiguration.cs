using System;
using System.Collections.Generic;
using System.Text;
using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
    public class BrandConfiguration : IEntityTypeConfiguration<Brand>
    {
        public void Configure(EntityTypeBuilder<Brand> builder)
        {
            //Base entity configuration
            builder.Property(b => b.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            builder.Property(b => b.IsDeleted)
                .HasDefaultValueSql("0");
            //Brand configuration
            builder.Property(b => b.Name)
                .HasMaxLength(20);
            //Relations
            builder.HasMany(b => b.Vehicles)
                .WithOne(v => v.Brand)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
