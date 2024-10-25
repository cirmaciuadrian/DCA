using DCA.Models;

namespace DCA.Service;

public interface ICalculatorService
{
    Task<ServiceResponse<TopCryptoResponse>> GetTop100CurrenciesAsync();
    Task<ServiceResponse<string>> AddInvestmentAsync(AddInvestmentContract contract);
}