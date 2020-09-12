using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Exam28June2020.Models
{
    public partial class ColonialJourneyContext : DbContext
    {
        public ColonialJourneyContext()
        {
        }

        public ColonialJourneyContext(DbContextOptions<ColonialJourneyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Colonist> Colonists { get; set; }
        public virtual DbSet<Journey> Journeys { get; set; }
        public virtual DbSet<Planet> Planets { get; set; }
        public virtual DbSet<Spaceport> Spaceports { get; set; }
        public virtual DbSet<Spaceship> Spaceships { get; set; }
        public virtual DbSet<TravelCard> TravelCards { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-Q9P5HVT\\SQLEXPRESS;Database=ColonialJourney;Integrated Security=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Colonist>(entity =>
            {
                entity.HasIndex(e => e.Ucn)
                    .HasName("UQ__Colonist__C5B68A1ADB4DC55A")
                    .IsUnique();

                entity.Property(e => e.BirthDate).HasColumnType("date");

                entity.Property(e => e.FirstName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.LastName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Ucn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Journey>(entity =>
            {
                entity.Property(e => e.JourneyEnd).HasColumnType("datetime");

                entity.Property(e => e.JourneyStart).HasColumnType("datetime");

                entity.Property(e => e.Purpose)
                    .HasMaxLength(11)
                    .IsUnicode(false);

                entity.HasOne(d => d.DestinationSpaceport)
                    .WithMany(p => p.Journeys)
                    .HasForeignKey(d => d.DestinationSpaceportId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Journeys__Destin__5535A963");

                entity.HasOne(d => d.Spaceship)
                    .WithMany(p => p.Journeys)
                    .HasForeignKey(d => d.SpaceshipId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Journeys__Spaces__5629CD9C");
            });

            modelBuilder.Entity<Planet>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Spaceport>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Planet)
                    .WithMany(p => p.Spaceports)
                    .HasForeignKey(d => d.PlanetId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__Spaceport__Plane__4BAC3F29");
            });

            modelBuilder.Entity<Spaceship>(entity =>
            {
                entity.Property(e => e.LightSpeedRate).HasDefaultValueSql("((0))");

                entity.Property(e => e.Manufacturer)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<TravelCard>(entity =>
            {
                entity.HasIndex(e => e.CardNumber)
                    .HasName("UQ__TravelCa__A4E9FFE9920FED52")
                    .IsUnique();

                entity.Property(e => e.CardNumber)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.JobDuringJourney)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.HasOne(d => d.Colonist)
                    .WithMany(p => p.TravelCards)
                    .HasForeignKey(d => d.ColonistId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TravelCar__Colon__5AEE82B9");

                entity.HasOne(d => d.Journey)
                    .WithMany(p => p.TravelCards)
                    .HasForeignKey(d => d.JourneyId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__TravelCar__Journ__5BE2A6F2");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
