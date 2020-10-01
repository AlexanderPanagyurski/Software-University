using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Data.EntityConfigurations
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder
                .Property(x => x.Town)
                .IsUnicode(true);

            builder
                .Property(x => x.Address)
                .IsUnicode(true);

            builder
                .Property(x => x.Notes)
                .IsUnicode(true);
        }
    }
}
