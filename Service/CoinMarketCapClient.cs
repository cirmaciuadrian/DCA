using Microsoft.Extensions.Caching.Memory;

namespace DCA.Service;

public class CoinMarketCapClient(HttpClient httpClient, IMemoryCache memoryCache)
{
    private readonly string cacheKey = "Top100Cryptos";
    private readonly TimeSpan cacheDuration = TimeSpan.FromMinutes(1);

    public async Task<TopCryptoResponse> GetTop100CryptoCurrencies()
    {
        if (memoryCache.TryGetValue(cacheKey, out TopCryptoResponse? cachedResponse))
        {
            return cachedResponse!;
        }

        var response = await httpClient.GetFromJsonAsync<TopCryptoResponse>(
            "v1/cryptocurrency/listings/latest?limit=100&convert=eur");
        if (response != null)
        {
            memoryCache.Set(cacheKey, response, cacheDuration);
        }

        return response!;
    }
}

public record TopCryptoResponse(List<TopCryptoItem> Data);

public record TopCryptoItem(string Name, string Symbol, TopCryptoQuote Quote);

public record TopCryptoQuote(TopCryptoQuoteEUR EUR);

public record TopCryptoQuoteEUR(decimal Price);
