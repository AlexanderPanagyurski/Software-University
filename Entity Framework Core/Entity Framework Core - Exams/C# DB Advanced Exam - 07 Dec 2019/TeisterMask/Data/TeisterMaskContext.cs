﻿namespace TeisterMask.Data
{
    using Microsoft.EntityFrameworkCore;
    using TeisterMask.Data.Models;

    public class TeisterMaskContext : DbContext
    {
        public TeisterMaskContext() { }

        public TeisterMaskContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<EmployeeTask> EmployeesTasks { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<Task> Tasks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeTask>(entity =>
            {
                entity.HasKey(et => new { et.EmployeeId, et.TaskId });

                entity
                    .HasOne(et => et.Employee)
                    .WithMany(e => e.EmployeesTasks)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(et => et.Task)
                    .WithMany(t => t.EmployeesTasks)
                    .OnDelete(DeleteBehavior.Restrict);
            });

            modelBuilder.Entity<Task>(entity =>
            {
                entity
                    .HasOne(t => t.Project)
                    .WithMany(p => p.Tasks)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}