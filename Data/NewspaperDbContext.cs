using Microsoft.EntityFrameworkCore;
using Newspaper.Entities;

namespace Newspaper.Data;

public class NewspaperDbContext(DbContextOptions<NewspaperDbContext> options)
    : DbContext(options)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Server=localhost;Port=5432;Database=newspaper_db;");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Article>()
            .Property(a => a.IsPublished)
            .HasDefaultValue(false);
    }

    public DbSet<Article> Articles { get; set; }
    public DbSet<Author> Authors { get; set; }
}