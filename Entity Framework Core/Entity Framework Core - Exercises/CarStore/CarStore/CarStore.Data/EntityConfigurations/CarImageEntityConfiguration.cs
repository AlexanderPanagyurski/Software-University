using CarStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Data.EntityConfigurations
{
    public class CarImageEntityConfiguration : IEntityTypeConfiguration<CarImage>
    {
        public void Configure(EntityTypeBuilder<CarImage> builder)
        {
            builder
                .HasOne(ce => ce.Car)
                .WithMany(c => c.CarImages)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
