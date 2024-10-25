using DCA.Data;
using DCA.Models;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Contracts;

namespace DCA.Service;

public class CalculatorService(CoinMarketCapClient coinMarketCapClient, AppDbContext dbContext) : ICalculatorService
{
    public async Task<ServiceResponse<TopCryptoResponse>> GetTop100CurrenciesAsync()
    {
        try
        {
            return new ServiceResponse<TopCryptoResponse>()
            {
                Response = await coinMarketCapClient.GetTop100CryptoCurrencies()
            };
        }
        catch (Exception e)
        {
            return new ServiceResponse<TopCryptoResponse>
            {
                IsSuccess = false,
                ErrorMessage = e.Message
            };
        }
    }
    public async Task<ServiceResponse<string>> AddInvestmentAsync(AddInvestmentContract contract)
    {
        //todo: validate contract - out of scope for this exercise
        var investmentDays = GetInvestmentDays(contract);
        if (investmentDays.Count == 0)
            return new ServiceResponse<string>
            {
                IsSuccess = false,
                ErrorMessage = "Selected days are not between the selected range"
            };

        //if(!await dbContext.CoinPriceHistories.AnyAsync(c => c.Symbol == contract.selectedCoin.Symbol))


        //var investmentValue = 0m;

        
        return new ServiceResponse<string>();
    }

    private static List<DateTime> GetInvestmentDays(AddInvestmentContract contract)
    {
        List<DateTime> investmentDays = [];
        for (var month = contract.dateFrom; month.Month <= contract.dateUntil.Month; month = month.AddMonths(1))
        {
            foreach (var day in contract.selectedInvestmentDays)
            {
                var investmentDay = DateTime.Parse($"{day}.{month.Month}.{month.Year}");
                if (investmentDay >= contract.dateFrom && investmentDay <= contract.dateUntil)
                {
                    investmentDays.Add(investmentDay);
                }
            }
        }
        return investmentDays;
    }

    //private async Task
}