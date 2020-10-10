namespace SULS.Data
{
    using Microsoft.EntityFrameworkCore;
    using SULS.Models;

    public class SULSContext : DbContext
    {
        // TODO
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-Q9P5HVT\SQLEXPRESS;Database=SULS;Integrated Security=True");
            }
        }

        public DbSet<Problem> Problems { get; set; }

        public DbSet<Submission> Submissions { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<Submission>(entity =>
                {
                    entity
                        .HasOne(x => x.User)
                        .WithMany(y => y.Submissions)
                        .HasForeignKey(x => x.UserId)
                        .OnDelete(DeleteBehavior.Restrict);

                    entity
                        .HasOne(x => x.Problem)
                        .WithMany(y => y.Submissions)
                        .HasForeignKey(x => x.ProblemId)
                        .OnDelete(DeleteBehavior.Restrict);
                });

            base.OnModelCreating(modelBuilder);
        }
    }
}