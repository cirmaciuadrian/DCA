namespace DCA.Service;

public interface ICalculatorService
{
    public Task<TopCryptoResponse> GetTop100Currencies();
}