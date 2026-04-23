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
            builder.HasKey(i => i.ItemId);
            builder.Property(i => i.ItemName)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(i => i.ProductId);
            builder.Property(i => i.ItemQuantity);
            builder.HasIndex(i => i.ItemName);
        }
    }
}

