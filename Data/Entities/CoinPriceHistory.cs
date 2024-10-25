using System.ComponentModel.DataAnnotations.Schema;

namespace DCA.Data.Entities;

public class CoinPriceHistory
{
    public int Id { get; set; }
    public string Symbol { get; set; } = null!;
    public DateTime Date { get; set; }
    [Column(TypeName = "decimal(18, 5)")]
    public decimal Price { get; set; }
    public List<Investment> Investments { get; set; } = [];
}