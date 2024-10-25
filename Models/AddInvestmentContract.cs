using DCA.Service;

namespace DCA.Models;

public sealed record AddInvestmentContract(TopCryptoItem selectedCoin, List<string> selectedInvestmentDays, int investmentAmount, DateTime dateFrom, DateTime dateUntil);

