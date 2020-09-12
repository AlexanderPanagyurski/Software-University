﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using P03_FootballBetting.Data.Models;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace P03_FootballBetting.Data
{
    public class FootballBettingContext : DbContext
    {
        public FootballBettingContext()
        {
        }
        public FootballBettingContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Configuration.ConectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Bet> Bets { get; set; }

        public DbSet<Color> Colors { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Game> Games { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<PlayerStatistic> PlayerStatistics { get; set; }

        public DbSet<Position> Positions { get; set; }

        public DbSet<Team> Teams { get; set; }

        public DbSet<Town> Towns { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // TODO: Fluent API

            modelBuilder
                    .Entity<Team>(entity =>
                    {
                        entity.HasKey(t => t.TeamId);

                        entity
                            .Property(e => e.Name)
                            .IsRequired(true)
                            .IsUnicode(true)
                            .HasMaxLength(50);

                        entity
                            .Property(t => t.LogoUrl)
                            .IsRequired(true)
                            .IsUnicode(false);

                        entity
                            .Property(t => t.Initials)
                            .IsRequired(true)
                            .IsUnicode(true)
                            .HasMaxLength(3);


                        entity
                            .HasOne(t => t.PrimaryKitColor)
                            .WithMany(c => c.PrimaryKitTeams)
                            .HasForeignKey(t => t.PrimaryKitColorId)
                            .OnDelete(DeleteBehavior.Restrict);

                        entity
                            .HasOne(t => t.SecondaryKitColor)
                            .WithMany(c => c.SecondaryKitTeams)
                            .HasForeignKey(t => t.SecondaryKitColorId);

                        entity
                            .HasOne(t => t.Town)
                            .WithMany(t => t.Teams)
                            .HasForeignKey(t => t.TownId)
                            .OnDelete(DeleteBehavior.Restrict);
                    });

            modelBuilder
                    .Entity<Color>(entity =>
                    {
                        entity.HasKey(c => c.ColorId);

                        entity
                            .Property(c => c.Name)
                            .IsRequired(true)
                            .IsUnicode(true)
                            .HasMaxLength(50);
                    });

            modelBuilder
                    .Entity<Town>(entity =>
                    {
                        entity.HasKey(t => t.TownId);

                        entity
                            .Property(t => t.Name)
                            .IsRequired(true)
                            .IsUnicode(true)
                            .HasMaxLength(50);

                        entity
                            .HasOne(t => t.Country)
                            .WithMany(c => c.Towns)
                            .HasForeignKey(t => t.CountryId)
                            .OnDelete(DeleteBehavior.Restrict);
                    });

            modelBuilder
                    .Entity<Country>(entity =>
                    {
                        entity.HasKey(c => c.CountryId);

                        entity
                            .Property(c => c.Name)
                            .IsRequired(true)
                            .IsUnicode(true)
                            .HasMaxLength(50);
                    });

            modelBuilder
                    .Entity<Player>(entity =>
                    {
                        entity.HasKey(p => p.PlayerId);

                        entity
                            .Property(p => p.Name)
                            .IsRequired(true)
                            .IsUnicode(true)
                            .HasMaxLength(50);

                        entity
                            .HasOne(p => p.Team)
                            .WithMany(t => t.Players)
                            .HasForeignKey(p => p.TeamId)
                            .OnDelete(DeleteBehavior.Restrict);

                        entity
                            .HasOne(p => p.Position)
                            .WithMany(x => x.Players)
                            .HasForeignKey(p => p.PositionId)
                            .OnDelete(DeleteBehavior.Restrict);
                    });

            modelBuilder
                    .Entity<Position>(entity =>
                    {
                        entity.HasKey(p => p.PositionId);

                        entity
                            .Property(p => p.Name)
                            .IsRequired(true)
                            .IsUnicode(true)
                            .HasMaxLength(50);
                    });

            modelBuilder
                    .Entity<PlayerStatistic>(entity =>
                    {
                        entity.HasKey(p => new { p.PlayerId, p.GameId });

                        entity
                            .HasOne(ps => ps.Player)
                            .WithMany(p => p.PlayerStatistics)
                            .HasForeignKey(ps => ps.PlayerId)
                            .OnDelete(DeleteBehavior.Restrict);

                        entity
                            .HasOne(ps => ps.Game)
                            .WithMany(g => g.PlayerStatistics)
                            .HasForeignKey(ps => ps.GameId)
                            .OnDelete(DeleteBehavior.Restrict);
                    });

            modelBuilder
                    .Entity<Game>(entity =>
                    {
                        entity.HasKey(g => g.GameId);

                        entity
                            .HasOne(g => g.HomeTeam)
                            .WithMany(t => t.HomeGames)
                            .HasForeignKey(g => g.HomeTeamId)
                            .OnDelete(DeleteBehavior.Restrict);

                        entity
                            .HasOne(g => g.AwayTeam)
                            .WithMany(t => t.AwayGames)
                            .HasForeignKey(g => g.AwayTeamId)
                            .OnDelete(DeleteBehavior.Restrict);

                        entity
                            .Property(g => g.Result)
                            .IsRequired(true)
                            .IsUnicode(true)
                            .HasMaxLength(50);
                    });

            modelBuilder
                    .Entity<Bet>(entity =>
                    {
                        entity.HasKey(b => b.BetId);

                        entity
                            .HasOne(b => b.User)
                            .WithMany(u => u.Bets)
                            .HasForeignKey(b => b.UserId)
                            .OnDelete(DeleteBehavior.Restrict);

                        entity
                            .HasOne(b => b.Game)
                            .WithMany(g => g.Bets)
                            .HasForeignKey(b => b.GameId)
                            .OnDelete(DeleteBehavior.Restrict);
                    });

            modelBuilder
                    .Entity<User>(entity =>
                    {
                        entity.HasKey(u => u.UserId);

                        entity
                            .Property(u => u.Username)
                            .IsRequired(true)
                            .IsUnicode(true)
                            .HasMaxLength(50);

                        entity
                            .Property(u => u.Password)
                            .IsRequired(true)
                            .IsUnicode(false)
                            .HasMaxLength(100);

                        entity
                            .Property(u => u.Email)
                            .IsRequired(true)
                            .IsUnicode(false)
                            .HasMaxLength(50);

                        entity
                            .Property(u => u.Name)
                            .IsRequired(true)
                            .IsUnicode(true)
                            .HasMaxLength(50);
                    });
        }
    }
}
