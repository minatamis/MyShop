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
            builder.HasKey(p => p.OrderId);
            builder.Property(p => p.OrderAmount)
                .HasColumnType("decimal(18,2)");
            builder.Property(p => p.OrderStatus)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(p => p.CreatedAt);
            builder.HasIndex(p => p.CreatedAt)
                .IsDescending();
        }
    }
}