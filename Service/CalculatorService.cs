using DCA.Data;

namespace DCA.Service;

public class CalculatorService(CoinMarketCapClient coinMarketCapClient, AppDbContext dbContext) : ICalculatorService
{
    public async Task<TopCryptoResponse> GetTop100Currencies() 
        => await coinMarketCapClient.GetTop100Cryptocurrencies();
}