using Microsoft.EntityFrameworkCore;
using P01_HospitalDatabase.Data.Configurations;
using P01_HospitalDatabase.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace P01_HospitalDatabase.Data
{
    public class HospitalContext : DbContext
    {
        public HospitalContext()
        {
        }
        public HospitalContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConnectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Diagnose> Diagnoses { get; set; }

        public DbSet<Medicament> Medicaments { get; set; }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<PatientMedicament> PatientMedicaments { get; set; }

        public DbSet<Visitation> Visitations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                    .Entity<Patient>(entity =>
                    {
                        entity
                            .Property(p => p.FirstName)
                            .IsRequired(true)
                            .IsUnicode(true)
                            .HasMaxLength(50);

                        entity
                            .Property(p => p.LastName)
                            .IsRequired(true)
                            .IsUnicode(true)
                            .HasMaxLength(50);

                        entity
                            .Property(p => p.Address)
                            .IsRequired(true)
                            .IsUnicode(true)
                            .HasMaxLength(250);

                        entity
                            .Property(p => p.Email)
                            .IsRequired(true)
                            .IsUnicode(false)
                            .HasMaxLength(80);
                    });

            modelBuilder
                    .Entity<Visitation>(entity =>
                    {
                        entity
                            .Property(v => v.Comments)
                            .IsRequired(true)
                            .IsUnicode(true)
                            .HasMaxLength(250);

                        entity
                            .HasOne(v => v.Doctor)
                            .WithMany(d => d.Visitations)
                            .OnDelete(DeleteBehavior.Restrict);

                        entity
                            .HasOne(v => v.Patient)
                            .WithMany(p => p.Visitations)
                            .OnDelete(DeleteBehavior.Restrict);
                    });

            modelBuilder
                    .Entity<Diagnose>(entity =>
                    {
                        entity
                            .Property(d => d.Name)
                            .IsRequired(true)
                            .IsUnicode(true)
                            .HasMaxLength(50);
                    });

            modelBuilder
                    .Entity<Medicament>(entity =>
                    {
                        entity
                            .Property(m => m.Name)
                            .IsRequired(true)
                            .IsUnicode(true)
                            .HasMaxLength(50);
                    });

            modelBuilder
                    .Entity<PatientMedicament>(entity =>
                    {
                        entity.HasKey(pm => new { pm.PatientId, pm.MedicamentId });

                        entity
                            .HasOne(pm => pm.Patient)
                            .WithMany(p => p.Prescriptions)
                            .OnDelete(DeleteBehavior.Restrict);

                        entity
                            .HasOne(pm => pm.Medicament)
                            .WithMany(m => m.Prescriptions)
                            .OnDelete(DeleteBehavior.Restrict);
                    });

            modelBuilder
                    .Entity<Doctor>(entity =>
                    {
                        entity
                            .Property(d => d.Name)
                            .IsRequired(true)
                            .IsUnicode(true)
                            .HasMaxLength(100);

                        entity
                            .Property(d => d.Specialty)
                            .IsRequired(true)
                            .IsUnicode(true)
                            .HasMaxLength(100);
                    });
        }
    }
}
