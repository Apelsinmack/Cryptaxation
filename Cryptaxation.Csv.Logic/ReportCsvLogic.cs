using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Cryptaxation.Csv.Contract;
using Cryptaxation.Entities;
using Cryptaxation.Entities.Types;
using Cryptaxation.Entities.Types.Enums;

namespace Cryptaxation.Csv.Logic
{
    public class ReportCsvLogic<TReportYearlySummary> : IReportCsvLogic<TReportYearlySummary> where TReportYearlySummary : ReportYearlySummary
    {
        private readonly string _path;
        private readonly string _delimiter;

        public ReportCsvLogic(string path)
        {
            _path = path;
            _delimiter = ";";
        }

        public void CreateReportCsv(List<TReportYearlySummary> reportYearlySummaries)
        {
            List<CurrencyCode> allReportCurrencies = GetAllReportCurrencies(reportYearlySummaries);
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string cellFormat = "F2";
            using (TextWriter writer = File.CreateText(_path))
            {
                CreateReportYearlySummaryHeader(writer, reportYearlySummaries);
                List<string> cells = new List<string>();
                foreach (var reportYearlySummary in reportYearlySummaries)
                {
                    cells = new List<string>
                    {
                        reportYearlySummary.Year.ToString(),
                        reportYearlySummary.AccumulatedTaxes.ToString(cellFormat, cultureInfo),
                        reportYearlySummary.CryptoAccumulatedTaxes.ToString(cellFormat, cultureInfo),
                        reportYearlySummary.CryptoAccumulatedProfit.ToString(cellFormat, cultureInfo),
                        reportYearlySummary.CryptoAccumulatedLosses.ToString(cellFormat, cultureInfo),
                        reportYearlySummary.FiatAccumulatedTaxes.ToString(cellFormat, cultureInfo),
                        reportYearlySummary.FiatAccumulatedProfit.ToString(cellFormat, cultureInfo),
                        reportYearlySummary.FiatAccumulatedLosses.ToString(cellFormat, cultureInfo)
                    };

                    foreach (var currencyCode in allReportCurrencies)
                    {
                        var reportCurrency = reportYearlySummary.ReportCurrencies.FirstOrDefault(rc => rc.CurrencyCode == currencyCode);
                        if (reportCurrency != null)
                        {
                            cells.Add(reportCurrency.OpeningTaxBaseRate.ToString(cellFormat, cultureInfo));
                            cells.Add(reportCurrency.ClosingTaxBaseRate.ToString(cellFormat, cultureInfo));
                            cells.Add(reportCurrency.AccumulatedProfit.ToString(cellFormat, cultureInfo));
                            cells.Add(reportCurrency.AccumulatedLoss.ToString(cellFormat, cultureInfo));
                        }
                        else
                        {
                            cells.Add("0");
                            cells.Add("0");
                            cells.Add("0");
                            cells.Add("0");
                        }
                    }

                    writer.WriteLine(string.Join(_delimiter, cells));
                }
            }
        }

        private void CreateReportYearlySummaryHeader(TextWriter writer, List<TReportYearlySummary> reportYearlySummaries)
        {
            List<CurrencyCode> allReportCurrencies = GetAllReportCurrencies(reportYearlySummaries);
            List<string> headers = new List<string>();
            foreach (var property in typeof(TReportYearlySummary).GetProperties())
            {
                if (property.PropertyType == typeof(List<ReportCurrency>))
                {
                    foreach (var currency in allReportCurrencies)
                    {
                        foreach (var currencyProperty in typeof(ReportCurrency).GetProperties())
                        {
                            if (currencyProperty.PropertyType != typeof(CurrencyCode) && currencyProperty.PropertyType != typeof(CurrencyType))
                            {
                                headers.Add(currency.ToString("G") + currencyProperty.Name);
                            }
                        }
                    }
                }
                else
                {
                    headers.Add(property.Name);
                }
            }
            writer.WriteLine(string.Join(_delimiter, headers));
        }

        private List<CurrencyCode> GetAllReportCurrencies(List<TReportYearlySummary> reportYearlySummaries)
        {
            List<CurrencyCode> allReportCurrencies = new List<CurrencyCode>();
            foreach (var reportYearlySummary in reportYearlySummaries)
            {
                foreach (var reportCurrency in reportYearlySummary.ReportCurrencies)
                {
                    if (!allReportCurrencies.Contains(reportCurrency.CurrencyCode))
                    {
                        allReportCurrencies.Add(reportCurrency.CurrencyCode);
                    }
                }
            }
            return allReportCurrencies;
        }
    }
}
