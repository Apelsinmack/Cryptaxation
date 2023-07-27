using System.Collections.Generic;
using System.Linq;
using Cryptaxation.Entities;
using Cryptaxation.Entities.Types;
using Cryptaxation.Entities.Types.Enums;
using Cryptaxation.Parse.Contract;

namespace Cryptaxation.Parse.Logic
{
    public class ReportLogic<TReportYearlySummary> : IReportLogic<TReportYearlySummary> where TReportYearlySummary : ReportYearlySummary, new()
    {
        private readonly decimal _taxRate;
        private readonly decimal _resourceDeductionRate;
        private readonly CurrencyCode _taxCurrencyCode;
        private readonly List<Currency> _taxBaseRates;
        private readonly List<DetailedTransaction> _detailedTransactions;

        public ReportLogic(List<DetailedTransaction> detailedTransactions)
        {
            _taxBaseRates = new List<Currency>();
            _taxRate = 0.3m;
            _resourceDeductionRate = 0.7m;
            _taxCurrencyCode = CurrencyCode.SEK;
            _detailedTransactions = detailedTransactions;
        }

        public List<TReportYearlySummary> CreateReportYearlySummaryList()
        {
            List<DetailedTransaction> filteredDetailedTransactions = _detailedTransactions.Where(dt => dt.Gain > 0 || dt.Loss > 0).ToList();
            List<TReportYearlySummary> reportYearlySummaries = new List<TReportYearlySummary>();
            List<ReportCurrency> openingReportCurrencies = new List<ReportCurrency>();
            TReportYearlySummary reportYearlySummary = new TReportYearlySummary
            {
                Year = 0
            };

            for (int i = 0; i < filteredDetailedTransactions.Count; i++)
            {
                if (reportYearlySummary.Year < filteredDetailedTransactions[i].DateTime.Year)
                {
                    reportYearlySummary = new TReportYearlySummary
                    {
                        Year = filteredDetailedTransactions[i].DateTime.Year,
                        ReportCurrencies = openingReportCurrencies,
                        AccumulatedTaxes = 0m
                    };
                }

                UpdateTaxBaseRate(filteredDetailedTransactions[i]);
                UpdateReportCurrencies(reportYearlySummary, filteredDetailedTransactions[i]);

                if (i == filteredDetailedTransactions.Count - 1 || reportYearlySummary.Year < filteredDetailedTransactions[i + 1].DateTime.Year)
                {
                    reportYearlySummary.ReportCurrencies.Where(rc => rc.CurrencyType == CurrencyType.FiatCurrency).ToList().ForEach(rc => reportYearlySummary.FiatAccumulatedProfit += rc.AccumulatedProfit);
                    reportYearlySummary.ReportCurrencies.Where(rc => rc.CurrencyType == CurrencyType.FiatCurrency).ToList().ForEach(rc => reportYearlySummary.FiatAccumulatedLosses += rc.AccumulatedLoss);
                    decimal fiatNetProfit = reportYearlySummary.FiatAccumulatedProfit - reportYearlySummary.FiatAccumulatedLosses;
                    if (fiatNetProfit > 0) reportYearlySummary.FiatAccumulatedTaxes = fiatNetProfit * _taxRate;

                    reportYearlySummary.ReportCurrencies.Where(rc => rc.CurrencyType == CurrencyType.CryptoCurrency).ToList().ForEach(rc => reportYearlySummary.CryptoAccumulatedProfit += rc.AccumulatedProfit);
                    reportYearlySummary.ReportCurrencies.Where(rc => rc.CurrencyType == CurrencyType.CryptoCurrency).ToList().ForEach(rc => reportYearlySummary.CryptoAccumulatedLosses += rc.AccumulatedLoss);
                    decimal cryptoNetProfit = reportYearlySummary.CryptoAccumulatedProfit - reportYearlySummary.CryptoAccumulatedLosses * _resourceDeductionRate;
                    if (cryptoNetProfit > 0) reportYearlySummary.CryptoAccumulatedTaxes = cryptoNetProfit * _taxRate;

                    reportYearlySummary.AccumulatedTaxes = reportYearlySummary.FiatAccumulatedTaxes + reportYearlySummary.CryptoAccumulatedTaxes;
                    openingReportCurrencies = reportYearlySummary.ReportCurrencies.Select(rc => new ReportCurrency(rc.CurrencyCode) { OpeningTaxBaseRate = rc.ClosingTaxBaseRate }).ToList();
                    reportYearlySummary.ReportCurrencies = reportYearlySummary.ReportCurrencies.Where(rc => rc.CurrencyCode != _taxCurrencyCode).ToList();
                    reportYearlySummaries.Add(reportYearlySummary);
                }
            }

            return reportYearlySummaries;
        }

        private void UpdateReportCurrencies(ReportYearlySummary reportYearlySummary, DetailedTransaction detailedTransaction)
        {
            AddReportCurrencyIfNotExist(reportYearlySummary.ReportCurrencies, detailedTransaction.CurrencyCodeBought);
            var reportCurrencyBought = reportYearlySummary.ReportCurrencies.FirstOrDefault(c => c.CurrencyCode == detailedTransaction.CurrencyCodeBought);
            reportCurrencyBought.ClosingTaxBaseRate = _taxBaseRates.FirstOrDefault(c => c.CurrencyCode == detailedTransaction.CurrencyCodeBought).Value;
            AddReportCurrencyIfNotExist(reportYearlySummary.ReportCurrencies, detailedTransaction.CurrencyCodeSold);
            var reportCurrencySold = reportYearlySummary.ReportCurrencies.FirstOrDefault(c => c.CurrencyCode == detailedTransaction.CurrencyCodeSold);
            reportCurrencySold.AccumulatedProfit += detailedTransaction.Gain;
            reportCurrencySold.AccumulatedLoss += detailedTransaction.Loss;
        }

        private void AddTaxBaseRateIfNotExist(CurrencyCode currencyCode)
        {
            if (!_taxBaseRates.Exists(tbr => tbr.CurrencyCode == currencyCode))
            {
                _taxBaseRates.Add(new Currency { CurrencyCode = currencyCode });
            }
        }

        private void UpdateTaxBaseRate(DetailedTransaction detailedTransaction)
        {
            AddTaxBaseRateIfNotExist(detailedTransaction.CurrencyCodeBought);
            _taxBaseRates.FirstOrDefault(tbr => tbr.CurrencyCode == detailedTransaction.CurrencyCodeBought).Value = detailedTransaction.TaxBasisRateAfterBought;
        }

        private void AddReportCurrencyIfNotExist(List<ReportCurrency> reportCurrencies, CurrencyCode currencyCode)
        {
            if (!reportCurrencies.Exists(rc => rc.CurrencyCode == currencyCode))
            {
                reportCurrencies.Add(new ReportCurrency(currencyCode));
            }
        }
    }
}
