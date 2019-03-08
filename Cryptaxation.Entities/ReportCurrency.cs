using Cryptaxation.Entities.Types.Enums;

namespace Cryptaxation.Entities
{
    public class ReportCurrency
    {
        public CurrencyCode CurrencyCode { get; set; }
        public decimal OpeningTaxbaseRate { get; set; }
        public decimal ClosingTaxbaseRate { get; set; }
        public decimal AccumulatedProfit { get; set; }
        public decimal AccumulatedLoss { get; set; }
    }
}
