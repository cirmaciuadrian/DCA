using DCA.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace DCA.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<CoinPriceHistory> CoinPriceHistory { get; set; }
    public DbSet<Investment> Investment { get; set; }
    public DbSet<InvestmentSummary> InvestmentSummary { get; set; }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<CoinPriceHistory>()
               .HasIndex(c => new { c.Symbol, c.Date })
               .IsUnique();
    }
}

