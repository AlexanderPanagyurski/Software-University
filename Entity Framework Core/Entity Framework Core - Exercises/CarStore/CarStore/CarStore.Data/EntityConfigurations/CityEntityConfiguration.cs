using CarStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Data.EntityConfigurations
{
    public class CityEntityConfiguration : IEntityTypeConfiguration<City>
    {
        public void Configure(EntityTypeBuilder<City> builder)
        {
            builder
                .Property(c => c.Name)
                .IsUnicode(true);

            builder
                .HasOne(c => c.State)
                .WithMany(s => s.Cities)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
