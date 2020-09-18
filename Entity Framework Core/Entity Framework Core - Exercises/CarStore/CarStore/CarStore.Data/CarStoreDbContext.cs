using CarStore.Common;
using CarStore.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace CarStore.Data
{
    class CarStoreDbContext : DbContext
    {
        public CarStoreDbContext()
        {
        }
        public CarStoreDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(DbConfiguration.DefConnectionStr);
            }
            base.OnConfiguring(optionsBuilder);
        }

        //TODO: DBSets
        public DbSet<Car> Cars { get; set; }

        public DbSet<CarComment> CarComments { get; set; }

        public DbSet<CarImage> CarImages { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Engine> Engines { get; set; }

        public DbSet<User> Users { get; set; }

        //TODO: Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Car>(entity =>
            {
                entity
                    .HasOne(c => c.Country)
                    .WithMany(x => x.Cars)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(c => c.Engine)
                    .WithMany(e => e.Cars)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<CarImage>(entity =>
            {
                entity
                    .HasOne(ce => ce.Car)
                    .WithMany(c => c.CarImages)
                    .OnDelete(DeleteBehavior.Restrict);

            });

            modelBuilder.Entity<CarComment>(entity =>
            {
                entity
                    .HasOne(cc => cc.Car)
                    .WithMany(c => c.CarComments)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
