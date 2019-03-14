using System.Collections.Generic;
using Cryptaxation.Entities;

namespace Cryptaxation.Entities
{
    public class ReportYearlySummary
    {
        public int Year { get; set; }
        public decimal AccumulatedTaxes { get; set; }
        public decimal CryptoAccumulatedTaxes { get; set; }
        public decimal CryptoAccumulatedProfit { get; set; }
        public decimal CryptoAccumulatedLosses { get; set; }
        public decimal FiatAccumulatedTaxes { get; set; }
        public decimal FiatAccumulatedProfit { get; set; }
        public decimal FiatAccumulatedLosses { get; set; }
        public List<ReportCurrency> ReportCurrencies { get; set; }
    }
}
