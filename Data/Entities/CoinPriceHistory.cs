using System.ComponentModel.DataAnnotations.Schema;

namespace DCA.Data.Entities;

public class CoinPriceHistory
{
    public string Name { get; set; } = null!;
    [Column(TypeName = "decimal(18, 10)")]
    public decimal Price { get; set; }
    public DateTime Date { get; set; }
}