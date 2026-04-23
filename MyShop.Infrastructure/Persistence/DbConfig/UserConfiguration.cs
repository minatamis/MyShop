using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyShop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyShop.Infrastructure.Persistence.DbConfig
{
    internal class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            builder.HasKey(u => u.UserId);
            builder.Property(u =>  u.Username)
                .IsRequired()
                .HasMaxLength(100);
            builder.Property(u => u.PasswordHash)
                .IsRequired();
            builder.HasIndex(u => u.Username)
                .IsUnique();
        }
    }
}
