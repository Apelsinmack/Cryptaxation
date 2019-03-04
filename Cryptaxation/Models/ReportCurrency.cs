using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation.Models
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
