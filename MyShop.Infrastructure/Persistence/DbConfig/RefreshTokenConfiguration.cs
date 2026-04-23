using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Infrastructure.Persistence.DbConfig
{
    internal class RefreshTokenConfiguration : IEntityTypeConfiguration<RefreshToken>
    {
        public void Configure(EntityTypeBuilder<RefreshToken> builder)
        {
            builder.ToTable("Refresh_Token");
            builder.HasKey(rt => rt.TokenId);
            builder.Property(rt => rt.Token)
                   .IsRequired()
                   .HasMaxLength(500);

            builder.Property(rt => rt.ExpiresAt)
                   .IsRequired();

            builder.Property(rt => rt.IsRevoked)
                   .IsRequired();

            builder.Property(rt => rt.UserId)
                   .IsRequired();

            builder.HasIndex(rt => rt.Token)
                   .IsUnique();
        }
    }
}
