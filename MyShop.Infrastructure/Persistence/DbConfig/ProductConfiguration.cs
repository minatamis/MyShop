using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Infrastructure.Persistence.DbConfig
{
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Products");
            builder.HasKey(p => p.ProductId);
            builder.Property(p => p.ProductName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.ProductPrice)
                .HasColumnType("decimal(18,2)");
            builder.HasIndex(p => p.ProductName);
        }
    }
}
