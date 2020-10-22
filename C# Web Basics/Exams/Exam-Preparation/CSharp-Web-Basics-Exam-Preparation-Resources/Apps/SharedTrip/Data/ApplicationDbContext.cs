namespace SharedTrip.Data
{
    using Microsoft.EntityFrameworkCore;

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions db)
            : base(db)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-D12RT2K\SQLEXPRESS;Database=SharedTrip;Integrated Security=true");
            }
        }

        public DbSet<Trip> Trips { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<UserTrip> UserTrips { get; set; }

        // TODO: Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserTrip>(x =>
            {
                x.HasKey(x => new { x.UserId, x.TripId });
            });
            base.OnModelCreating(modelBuilder);
        }
    }
}
