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
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CarStoreDbContext).Assembly);
        }
    }
}
