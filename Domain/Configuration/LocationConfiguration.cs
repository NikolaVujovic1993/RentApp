using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using DomainModels;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Configuration
{
	public class LocationConfiguration : IEntityTypeConfiguration<Location>
	{
		public void Configure(EntityTypeBuilder<Location> builder)
		{
			//Base entity configuration
			builder.Property(b => b.CreatedAt)
				.HasDefaultValueSql("GETDATE()");
			builder.Property(b => b.IsDeleted)
				.HasDefaultValueSql("0");
			//Transmission configuration
			builder.Property(l => l.Adress)
				.IsRequired()
				.HasMaxLength(30);
			builder.Property(l => l.Price)
				.IsRequired()
				.HasMaxLength(10);
			//Relations
			
		}
	}
}
