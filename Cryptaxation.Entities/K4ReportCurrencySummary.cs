using Cryptaxation.Entities.Types.Enums;
using System.Collections.Generic;

namespace Cryptaxation.Entities
{
    public class K4ReportCurrencySummary
    {
        public ReportCurrency Currency { get; set; }
        public decimal Amount { get; set; }
        public decimal TotalSellingPriceSEK { get; set; }
        public decimal AverageSellingPriceSEK { get; set; }
        public decimal TotalTaxBasisSEK { get; set; }
        public decimal AverageTaxBasisSEK { get; set; }
        public decimal ProfitSEK { get; set; }
        public decimal LossesSEK { get; set; }
    }
}
