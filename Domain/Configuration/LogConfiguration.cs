using DomainModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Configuration
{
    public class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            //Base entity configuration
            builder.Property(b => b.CreatedAt)
                .HasDefaultValueSql("GETDATE()");
            builder.Property(b => b.IsDeleted)
                .HasDefaultValueSql("0");
            //Log configuration
            builder.Property(b => b.Action)
                .IsRequired()
                .HasMaxLength(255);
            //Relations
            builder.HasOne(l => l.User)
                .WithMany(u => u.Logs)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
