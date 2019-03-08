using System.Collections.Generic;
using Cryptaxation.Entities;

namespace Cryptaxation.Entities
{
    public class ReportYearlySummary
    {
        public int Year { get; set; }
        public List<ReportCurrency> ReportCurrencies { get; set; }
        public decimal AccumulatedTaxes { get; set; }
    }
}
