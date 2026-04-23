using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Infrastructure.Persistence.DbConfig
{
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.ToTable("Orders");
            builder.HasKey(o => o.OrderId);
            builder.Property(o => o.OrderAmount)
                .HasColumnType("decimal(18,2)");
            builder.Property(o => o.OrderStatus)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(o => o.CreatedAt);
            builder.HasIndex(o => o.CreatedAt)
                .IsDescending();
        }
    }
}