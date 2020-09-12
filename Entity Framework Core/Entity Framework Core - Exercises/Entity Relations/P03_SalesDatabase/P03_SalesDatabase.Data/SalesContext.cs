using Microsoft.EntityFrameworkCore;
using P03_SalesDatabase.Data.Config;
using P03_SalesDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P03_SalesDatabase.Data
{
    public class SalesContext : DbContext
    {
        public SalesContext()
        {

        }
        public SalesContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Connection.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Customer> Customers { get; set; }

        public DbSet<Product> Products { get; set; }

        public DbSet<Sale> Sales { get; set; }

        public DbSet<Store> Stores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                    .Entity<Product>(entity =>
                    {
                        entity
                            .Property(p => p.Name)
                            .IsUnicode(true);

                        entity
                            .Property(p => p.Description)
                            .IsUnicode(true)
                            .HasDefaultValue("No description");
                    });

            modelBuilder
                    .Entity<Customer>(entity =>
                    {
                        entity
                            .Property(c => c.Name)
                            .IsUnicode(true);

                        entity
                            .Property(c => c.Email)
                            .IsUnicode(false);

                        entity
                            .Property(c => c.CreditCardNumber)
                            .IsUnicode(false);
                    });

            modelBuilder
                    .Entity<Store>(entity =>
                    {
                        entity
                            .Property(s => s.Name)
                            .IsUnicode(true);
                    });

            modelBuilder
                    .Entity<Sale>(entity =>
                    {
                        entity
                            .HasOne(s => s.Customer)
                            .WithMany(c => c.Sales)
                            .HasForeignKey(s => s.CustomerId)
                            .OnDelete(DeleteBehavior.Restrict);

                        entity
                            .HasOne(s => s.Product)
                            .WithMany(p => p.Sales)
                            .HasForeignKey(s => s.ProductId)
                            .OnDelete(DeleteBehavior.Restrict);

                        entity
                            .HasOne(s => s.Store)
                            .WithMany(s => s.Sales)
                            .HasForeignKey(s => s.StoreId)
                            .OnDelete(DeleteBehavior.Restrict);
                    });
        }
    }
}
