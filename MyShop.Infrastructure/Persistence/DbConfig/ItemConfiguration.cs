using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Infrastructure.Persistence.DbConfig
{
    internal class ItemConfiguration : IEntityTypeConfiguration<Item>
    {
        public void Configure(EntityTypeBuilder<Item> builder)
        {
            builder.ToTable("Items");
            builder.HasKey(p => p.ItemId);
            builder.Property(p => p.ItemName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.ProductId);
            builder.Property(p => p.ItemQuantity);
            builder.HasIndex(p => p.ItemName);
        }
    }
}

