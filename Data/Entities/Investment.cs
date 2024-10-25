using System.ComponentModel.DataAnnotations.Schema;

namespace DCA.Data.Entities;

public class Investment
{
    public int Id { get; set; }
    public DateTime Date { get; set; }
    public int FiatAmount { get; set; }
    [Column(TypeName = "decimal(18, 5)")]
    public decimal CryptoAmount { get; set; }
    public int CoinPriceHistoryId { get; set; }
    public CoinPriceHistory CoinPriceHistory { get; set; } = new();
}   