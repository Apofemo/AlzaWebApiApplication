using AlzaApp.Persistence.DatabaseObjects;
using Microsoft.EntityFrameworkCore;

namespace AlzaApp.Persistence;

public sealed class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<ProductDo> Products { get; private set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ProductDo>()
                    .Property(p => p.Price)
                    .HasColumnType("decimal(18,2)");
    }
}