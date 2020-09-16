namespace BookShop.Data
{
    using BookShop.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class BookShopContext : DbContext
    {
        public BookShopContext() { }

        public BookShopContext(DbContextOptions options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder
                    .UseSqlServer(Configuration.ConnectionString);
            }
        }

        public DbSet<Author> Authors { get; set; }

        public DbSet<Book> Books { get; set; }

        public DbSet<AuthorBook> AuthorsBooks { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                    .Entity<AuthorBook>(entity =>
                    {
                        entity.HasKey(e => new { e.AuthorId, e.BookId });

                        entity
                            .HasOne(e => e.Author)
                            .WithMany(a => a.AuthorsBooks)
                            .OnDelete(DeleteBehavior.Restrict);

                        entity
                            .HasOne(e => e.Book)
                            .WithMany(b => b.AuthorsBooks)
                            .OnDelete(DeleteBehavior.Restrict);
                    });
        }
    }
}