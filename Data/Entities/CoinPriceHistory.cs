using System.ComponentModel.DataAnnotations.Schema;

namespace DCA.Data.Entities;

public class CoinPriceHistory
{
    public string Symbol { get; set; } = null!;
    public DateTime Date { get; set; }
    [Column(TypeName = "decimal(10, 2)")]
    public decimal Price { get; set; }
}