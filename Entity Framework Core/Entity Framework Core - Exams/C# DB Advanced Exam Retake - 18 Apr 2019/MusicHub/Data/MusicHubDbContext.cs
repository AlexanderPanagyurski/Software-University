namespace MusicHub.Data
{
    using Microsoft.EntityFrameworkCore;
    using MusicHub.Data.Models;

    public class MusicHubDbContext : DbContext
    {
        public MusicHubDbContext()
        {
        }

        public MusicHubDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<SongPerformer>(entity =>
            {
                entity.HasKey(sp => new { sp.SongId, sp.PerformerId });

                entity
                    .HasOne(sp => sp.Song)
                    .WithMany(s => s.SongPerformers)
                    .OnDelete(DeleteBehavior.Restrict);

                entity
                    .HasOne(sp => sp.Performer)
                    .WithMany(p => p.PerformerSongs)
                    .OnDelete(DeleteBehavior.Restrict);
            });
        }
    }
}
