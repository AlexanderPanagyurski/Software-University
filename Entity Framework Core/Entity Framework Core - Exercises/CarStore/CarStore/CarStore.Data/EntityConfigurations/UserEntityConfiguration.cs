using CarStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Data.EntityConfigurations
{
    public class UserEntityConfiguration : IEntityTypeConfiguration<User>
    {
        public UserEntityConfiguration()
        {
        }

        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder
                .Property(u => u.FirstName)
                .IsUnicode(true);

            builder
                .Property(u => u.LastName)
                .IsUnicode(true);

            builder
                .Property(u => u.Username)
                .IsUnicode(false);

            builder
                .HasOne(u => u.City)
                .WithMany(c => c.Users)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
