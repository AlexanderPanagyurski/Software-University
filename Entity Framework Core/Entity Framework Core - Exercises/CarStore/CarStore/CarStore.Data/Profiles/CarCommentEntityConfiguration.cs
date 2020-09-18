using CarStore.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Data.Profiles
{
    public class CarCommentEntityConfiguration : IEntityTypeConfiguration<CarComment>
    {
        public void Configure(EntityTypeBuilder<CarComment> builder)
        {
            builder
                .Property(cc => cc.Content)
                .IsUnicode(true);

            builder
                .HasOne(cc => cc.Car)
                .WithMany(c => c.CarComments)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
