namespace DCA.Service;

public class CoinMarketCapClient(HttpClient httpClient)
{
    public async Task<TopCryptoResponse> GetTop100Cryptocurrencies()
        => (await httpClient.GetFromJsonAsync<TopCryptoResponse>(
        "cryptocurrency/listings/latest?limit=100&convert=eur"))!;
}

public record TopCryptoResponse(List<TopCryptoItem> Data);

public record TopCryptoItem(string Name, string Symbol, TopCryptoQuote Quote);

public record TopCryptoQuote(TopCruptoQuoteEUR EUR);

public record TopCruptoQuoteEUR(decimal Price);