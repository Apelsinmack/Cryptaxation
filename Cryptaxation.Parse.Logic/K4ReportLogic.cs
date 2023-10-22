using Cryptaxation.Entities;
using Cryptaxation.Entities.Types.Enums;
using Cryptaxation.Entities.Types;
using Cryptaxation.Parse.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Cryptaxation.Parse.Logic
{
    public class K4ReportLogic<TK4ReportCurrencySummary> : IK4ReportLogic<List<TK4ReportCurrencySummary>> where TK4ReportCurrencySummary : K4ReportCurrencySummary, new()
    {
        private readonly CurrencyCode _taxCurrencyCode;
        private readonly List<DetailedTransaction> _detailedTransactions;

        public K4ReportLogic(CurrencyCode taxCurrencyCode, List<DetailedTransaction> detailedTransactions)
        {
            _taxCurrencyCode = taxCurrencyCode;
            _detailedTransactions = detailedTransactions;
        }

        public Dictionary<int, List<TK4ReportCurrencySummary>> CreateK4ReportYearlySummaryList()
        {
            List<DetailedTransaction> filteredDetailedTransactions = _detailedTransactions.Where(dt => dt.Gain > 0 || dt.Loss > 0).ToList();
            Dictionary<int, List<TK4ReportCurrencySummary>> k4reportYearlySummaries = new Dictionary<int, List<TK4ReportCurrencySummary>>();
            List<TK4ReportCurrencySummary> k4ReportCurrencySummaries = new List<TK4ReportCurrencySummary>();
            
            foreach (var transaction in filteredDetailedTransactions)
            {
                if (k4reportYearlySummaries.Count == 0 || k4reportYearlySummaries.Keys.Last() < transaction.DateTime.Year)
                {
                    k4ReportCurrencySummaries = new List<TK4ReportCurrencySummary>();
                    k4reportYearlySummaries.Add(transaction.DateTime.Year, k4ReportCurrencySummaries);
                }

                if (!k4ReportCurrencySummaries.Exists(summary => summary.Currency.CurrencyCode == transaction.CurrencyCodeSold))
                {
                    k4ReportCurrencySummaries.Add(new TK4ReportCurrencySummary()
                    {
                        Currency = new ReportCurrency(transaction.CurrencyCodeSold)
                    });
                }

                var currencySummary = k4ReportCurrencySummaries.Find(summary => summary.Currency.CurrencyCode == transaction.CurrencyCodeSold);
                currencySummary.Amount += transaction.AmountSold;
                currencySummary.TotalSellingPriceSEK += transaction.ValueTaxationCurrencySold;
                currencySummary.TotalTaxBasisSEK += transaction.TaxBasisValueSold;
                currencySummary.ProfitSEK += transaction.Gain - transaction.Loss;
            }

            foreach (List<TK4ReportCurrencySummary> yearlySummary in k4reportYearlySummaries.Values)
            {
                foreach(TK4ReportCurrencySummary currencySummary in yearlySummary)
                {
                    currencySummary.AverageSellingPriceSEK = currencySummary.TotalSellingPriceSEK / currencySummary.Amount;
                    if (currencySummary.ProfitSEK < 0)
                    {
                        currencySummary.LossesSEK = currencySummary.ProfitSEK;
                        currencySummary.ProfitSEK = 0;
                    }
                }
            }

            return k4reportYearlySummaries;
        }
    }
}
