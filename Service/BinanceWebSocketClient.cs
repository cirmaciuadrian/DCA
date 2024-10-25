using Binance.Net.Clients;
using DCA.Models;

namespace DCA.Service;

public class BinanceWebSocketClient
{
    private readonly BinanceSocketClient _socketClient;
    private Action<LivePriceItem>? _onPriceUpdate;
    public BinanceWebSocketClient()
    {
        _socketClient = new BinanceSocketClient();
    }

    public async Task SubscribeToPriceUpdate(Action<LivePriceItem> onPriceUpdate, string symbol)
    {
        _onPriceUpdate = onPriceUpdate;

        var subscriptionResult = await _socketClient.SpotApi.ExchangeData.SubscribeToBookTickerUpdatesAsync($"{symbol}EUR", data =>
        {
            var price = new LivePriceItem()
            {
                Symbol = symbol,
                Price = data.Data.BestBidPrice
            };
            _onPriceUpdate?.Invoke(price);
        });
        if (!subscriptionResult.Success)
        {
            throw new Exception("Failed to subscribe to WebSocket stream: " + subscriptionResult.Error);
        }

    }

    public async Task UnsubscribeAllAsync()
    {
        await _socketClient.UnsubscribeAllAsync();
    }
}
