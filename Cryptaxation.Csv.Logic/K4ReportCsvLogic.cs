using Cryptaxation.Csv.Contract;
using Cryptaxation.Entities;
using Cryptaxation.Entities.Types.Enums;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation.Csv.Logic
{
    public class K4ReportCsvLogic<TK4ReportCurrencySummary> : IK4ReportCsvLogic<List<TK4ReportCurrencySummary>> where TK4ReportCurrencySummary : K4ReportCurrencySummary, new()
    {
        private readonly string _path;
        private readonly string _delimiter;

        public K4ReportCsvLogic(string path)
        {
            _path = path;
            _delimiter = ";";
        }

        public void CreateK4ReportCsv(Dictionary<int, List<TK4ReportCurrencySummary>> k4ReportYearlySummaries)
        {
            foreach (var k4ReportYearlySummary in k4ReportYearlySummaries)
            {
                using (TextWriter writer = File.CreateText(_path.Replace("{{year}}", k4ReportYearlySummary.Key.ToString())))
                {
                    CreateK4ReportHeader(writer);
                    foreach (var k4ReportCurrencySummary in k4ReportYearlySummary.Value.OrderBy(summary => summary.Currency.CurrencyType == CurrencyType.FiatCurrency))
                    {
                        CreateK4ReportRow(writer, k4ReportCurrencySummary);
                    }
                }
            }
        }

        private void CreateK4ReportHeader(TextWriter writer)
        {
            List<string> headers = new List<string>();
            List<string> ignoreColumns = new List<string>
            {
                nameof(K4ReportCurrencySummary.AverageSellingPriceSEK)
            };

            foreach (var property in typeof(TK4ReportCurrencySummary).GetProperties())
            {
                if (!ignoreColumns.Contains(property.Name))
                {
                    headers.Add(property.Name);
                }
            }

            writer.WriteLine(string.Join(_delimiter, headers));
        }

        private void CreateK4ReportRow(TextWriter writer, TK4ReportCurrencySummary k4ReportCurrencySummary)
        {
            List<string> cells = new List<string>();
            CultureInfo cultureInfo = CultureInfo.InvariantCulture;
            string cellFormat = "F0";

            cells.Add(k4ReportCurrencySummary.Currency.CurrencyCode.ToString());
            cells.Add(k4ReportCurrencySummary.Amount.ToString(cellFormat, cultureInfo));
            cells.Add(k4ReportCurrencySummary.TotalSellingPriceSEK.ToString(cellFormat, cultureInfo));
            cells.Add(k4ReportCurrencySummary.TotalTaxBasisSEK.ToString(cellFormat, cultureInfo));
            cells.Add(k4ReportCurrencySummary.ProfitSEK.ToString(cellFormat, cultureInfo));
            cells.Add(k4ReportCurrencySummary.LossesSEK.ToString(cellFormat, cultureInfo));

            writer.WriteLine(string.Join(_delimiter, cells));
        }
    }
}
