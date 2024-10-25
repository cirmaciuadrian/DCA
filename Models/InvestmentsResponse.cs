using System.ComponentModel.DataAnnotations.Schema;

namespace DCA.Models;

public sealed class InvestmentsResponse
{
    public int Id { get; set; }
    public string Symbol { get; set; } = null!;
    public string DaysOfInvestment { get; set; } = null!;
    public DateTime From { get; set; }
    public DateTime To { get; set; }
    public int TotalFiatInvested { get; set; }
    [Column(TypeName = "decimal(18, 5)")]
    public decimal TotalCryptoOwned { get; set; }
    [Column(TypeName = "decimal(18, 2)")]
    public decimal TotalInvestmentPrice => TotalCryptoOwned * CoinPrice;
    public decimal CoinPrice { get; set; } = 0;
    public decimal Profit => TotalInvestmentPrice - TotalFiatInvested;
    public string ROI => ((Profit / TotalFiatInvested) * 100).ToString("F2");
    //public List<InvestmentDetail> InvestmentDetails = [];
}

public sealed record InvestmentDetail
{
    public DateTime InvestmentDate { get; set; }
    public int InvestmentAmount { get; set; }
    [Column(TypeName = "decimal(18, 5)")]
    public decimal CryptoAmount { get; set; }
    [Column(TypeName = "decimal(18, 5)")]
    public decimal Price { get; set; }
}

public class LivePriceItem
{
    public string Symbol { get; set; } = null!;
    [Column(TypeName = "decimal(18, 5)")]
    public decimal Price { get; set; }
}