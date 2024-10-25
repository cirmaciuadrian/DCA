using Binance.Net.Clients;
using Binance.Net.Enums;
using DCA.Data;
using DCA.Data.Entities;
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

    public async Task<ServiceResponse<bool>> AddInvestmentAsync(AddInvestmentContract contract)
    {
        //todo: validate contract - out of scope for this exercise

        try
        {
            var investmentDays = GetInvestmentDays(contract);
            if (investmentDays.Count == 0)
                return new ServiceResponse<bool>
                {
                    IsSuccess = false,
                    ErrorMessage = "Selected days are not between the selected range"
                };

            if (!await dbContext.CoinPriceHistory.AnyAsync(c => c.Symbol == contract.selectedCoin.Symbol))
                await FetchCoinPriceHistoryAsync(contract.selectedCoin.Symbol);

            await AddInvestmentAsync(contract, investmentDays);

            return new ServiceResponse<bool> { Response = true };
        }
        catch (Exception e)
        {
            return new ServiceResponse<bool>
            {
                IsSuccess = false,
                ErrorMessage = e.Message
            };
        }
    }

    public async Task<List<InvestmentsResponse>> GetAllInvestmentsAsync()
    {
        var dbInvestments = await dbContext.InvestmentSummary
            .Include(x => x.Investments)
                .ThenInclude(x => x.CoinPriceHistory)
            .AsNoTracking()
            .ToListAsync();

        return dbInvestments.Select(x => new InvestmentsResponse
        {
            Id = x.Id,
            DaysOfInvestment = x.Days,
            From = x.From,
            To = x.To,
            Symbol = x.Symbol,
            //InvestmentDetails = x.Investments.Select(y => new InvestmentDetail
            //{
            //    CryptoAmount = y.CryptoAmount,
            //    InvestmentAmount = y.FiatAmount,
            //    InvestmentDate = y.Date,
            //    Price = y.CoinPriceHistory.Price
            //}).ToList(),
            TotalCryptoOwned = x.Investments.Sum(y => y.CryptoAmount),
            TotalFiatInvested = x.Investments.Sum(y => y.FiatAmount)
        }).ToList();
    }

    public async Task DeleteInvestmentAsync(int id)
    {
        var dbInvestment = await dbContext.InvestmentSummary
             .Include(x => x.Investments)
             .FirstAsync(x => x.Id == id);
        dbContext.InvestmentSummary.Remove(dbInvestment);
        dbContext.Investment.RemoveRange(dbInvestment.Investments);
        await dbContext.SaveChangesAsync();
    }

    private static List<DateTime> GetInvestmentDays(AddInvestmentContract contract)
    {
        List<DateTime> investmentDays = [];
        for (var dateItem = contract.dateFrom; dateItem <= contract.dateUntil; dateItem = dateItem.AddMonths(1))
        {
            foreach (var day in contract.selectedInvestmentDays)
            {
                var investmentDay = new DateTime(dateItem.Year, dateItem.Month, int.Parse(day));
                if (investmentDay >= contract.dateFrom && investmentDay <= contract.dateUntil)
                {
                    investmentDays.Add(investmentDay);
                }
            }
        }
        return investmentDays.OrderBy(x => x).ToList();
    }

    private async Task FetchCoinPriceHistoryAsync(string symbol)
    {
        var bineanceClient = new BinanceRestClient();
        for (int year = 2022; year <= DateTime.Now.Year; year++) // binanceClient is limited to 500 record per response
        {
            var coinPrices = await bineanceClient.SpotApi.ExchangeData.GetKlinesAsync($"{symbol}EUR", KlineInterval.OneDay, new DateTime(year, 01, 01), new DateTime(year, 12, 31));
            var historicalPrices = coinPrices.Data.Select(x => new CoinPriceHistory
            {
                Symbol = symbol,
                Price = x.OpenPrice,
                Date = x.OpenTime.Date
            }).ToList();
            await dbContext.CoinPriceHistory.AddRangeAsync(historicalPrices);
        }
        await dbContext.SaveChangesAsync();
    }

    private async Task AddInvestmentAsync(AddInvestmentContract contract, List<DateTime> investmentDates)
    {
        var historicalPrices = await dbContext.CoinPriceHistory
            .Where(x => x.Symbol == contract.selectedCoin.Symbol && investmentDates.Contains(x.Date))
            .ToListAsync();

        List<Investment> investments = [];

        foreach (var date in investmentDates)
        {
            var historicalData = historicalPrices.FirstOrDefault(x => x.Date == date.Date);
            if (historicalData == null)
                throw new Exception($"Price for {contract.selectedCoin.Symbol} is missing for date {date}");

            var investment = new Investment
            {
                Date = date.Date,
                FiatAmount = contract.investmentAmount,
                CryptoAmount = contract.investmentAmount / historicalData.Price,
                CoinPriceHistory = historicalData,
                CoinPriceHistoryId = historicalData.Id
            };
            investments.Add(investment);
        }

        await dbContext.InvestmentSummary.AddAsync(new InvestmentSummary
        {
            Days = string.Join(", ", contract.selectedInvestmentDays),
            From = contract.dateFrom.Date,
            To = contract.dateUntil.Date,
            Investments = investments,
            Symbol = contract.selectedCoin.Symbol
        });

        await dbContext.SaveChangesAsync();
    }
}