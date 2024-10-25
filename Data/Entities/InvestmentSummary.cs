namespace DCA.Data.Entities
{
    public class InvestmentSummary
    {
        public int Id { get; set; }
        public string Symbol { get; set; } = null!;
        public DateTime From { get; set; }
        public DateTime To { get; set; }
        public string Days { get; set; } = null!;
        public List<Investment> Investments { get; set; } = [];
    }
}
