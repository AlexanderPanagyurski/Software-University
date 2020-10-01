using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PetStore.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PetStore.Data.EntityConfigurations
{
    public class ClientConfiguration : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder
                .Property(x => x.Email)
                .IsUnicode(false);

            builder
                .Property(x => x.FirstName)
                .IsUnicode(true);

            builder
                .Property(x => x.LastName)
                .IsUnicode(true);

            builder
                .Property(x => x.Password)
                .IsUnicode(false);

            builder
                .Property(x => x.Username)
                .IsUnicode(false);
        }
    }
}
