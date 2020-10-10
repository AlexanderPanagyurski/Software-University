namespace Andreys.Data
{
    using Andreys.Models;
    using Andreys.Models.Enums;
    using Microsoft.EntityFrameworkCore;

    public class AndreysDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=DESKTOP-Q9P5HVT\SQLEXPRESS;Database=Andreys;Integrated Security=True");
            }
        }

        public DbSet<Product> Products { get; set; }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
