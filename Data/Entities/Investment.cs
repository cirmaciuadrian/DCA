using System.ComponentModel.DataAnnotations.Schema;

namespace DCA.Data.Entities;

public class Investment
{
    public int Id { get; set; }
    public string Symbol { get; set; } = null!;
    public DateTime Date { get; set; }
    public int Value { get; set; }

    public CoinPriceHistory? CoinPriceHistory { get; set; }
}