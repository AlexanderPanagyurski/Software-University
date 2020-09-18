using CarStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Data.EntityConfigurations
{
    public class CarEntityConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder
                   .Property(c => c.Description)
                   .IsUnicode(true);

            builder
                .HasOne(c => c.Country)
                .WithMany(x => x.Cars)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.Engine)
                .WithMany(e => e.Cars)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.State)
                .WithMany(s => s.Cars)
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(c => c.City)
                .WithMany(x => x.Cars)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
