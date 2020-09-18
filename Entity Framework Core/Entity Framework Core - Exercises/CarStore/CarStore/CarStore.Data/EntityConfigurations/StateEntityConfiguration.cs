using CarStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Data.EntityConfigurations
{
    public class StateEntityConfiguration : IEntityTypeConfiguration<State>
    {
        public void Configure(EntityTypeBuilder<State> builder)
        {
            builder
                .Property(s => s.Name)
                .IsUnicode(true);

            builder
                .HasOne(s => s.Country)
                .WithMany(c => c.States)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
