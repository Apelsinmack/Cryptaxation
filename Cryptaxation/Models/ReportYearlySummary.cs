using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation.Models
{
    public class ReportYearlySummary
    {
        public int Year { get; set; }
        public List<ReportCurrency> ReportCurrencies { get; set; }
        public decimal AccumulatedTaxes { get; set; }
    }
}
