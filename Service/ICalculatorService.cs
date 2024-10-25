using DCA.Models;

namespace DCA.Service;

public interface ICalculatorService
{
    Task<ServiceResponse<TopCryptoResponse>> GetTop100CurrenciesAsync();
    Task<ServiceResponse<bool>> AddInvestmentAsync(AddInvestmentContract contract);
    Task<List<InvestmentsResponse>> GetAllInvestmentsAsync();
    Task DeleteInvestmentAsync(int id);
}