using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using SneakerApi.core.Models;

namespace SneakerApi.core.Data
{
    public class SneakerDbContext : DbContext
    {
        public DbSet<Sneaker> Sneakers => Set<Sneaker>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=Sneaker.db");

            optionsBuilder.LogTo(System.Console.WriteLine, Microsoft.Extensions.Logging.LogLevel.Information);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Sneaker>(entity =>
            {
                entity.HasKey(s => s.ID);

                entity.Property(s => s.Brand)
                .IsRequired()
                .HasMaxLength(50);

                entity.Property(s => s.Model)
                .IsRequired()
                .HasMaxLength(100); 

                entity.Property(s => s.Color)
                .HasMaxLength(30);

                entity.Property(s => s.Price)
                .HasPrecision(18, 2);
            });
        }
    }
}