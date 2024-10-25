using DCA.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DCA.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<CoinPriceHistory> CoinPriceHistories { get; set; }
    public DbSet<Investment> Investments { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CoinPriceHistory>()
            .HasKey(c => new { c.Symbol, c.Date });

        modelBuilder.Entity<Investment>()
         .HasOne(i => i.CoinPriceHistory)
         .WithMany()
         .HasForeignKey(i => new { i.Symbol, i.Date })  
         .HasPrincipalKey(c => new { c.Symbol, c.Date });
    }
}

