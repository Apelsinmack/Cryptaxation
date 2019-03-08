using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptaxation.Csv.Contract;
using Cryptaxation.Entities;
using Cryptaxation.Entities.Types.Enums;

namespace Cryptaxation.Csv.Logic
{
    public class ReportLogic : IReportLogic
    {
        public List<ReportYearlySummary> CreateReportYearlySummaryList(List<DetailedTransaction> detailedTransactions)
        {
            List<ReportYearlySummary> reportYearlySummaries = new List<ReportYearlySummary>();
            ReportYearlySummary reportYearlySummary = new ReportYearlySummary
            {
                Year = 0
            };

            for (int i = 0; i < detailedTransactions.Count; i++)
            {
                if (reportYearlySummary.Year < detailedTransactions[i].DateTime.Year)
                {
                    reportYearlySummary = new ReportYearlySummary
                    {
                        Year = detailedTransactions[i].DateTime.Year,
                        ReportCurrencies = new List<ReportCurrency>(),
                        AccumulatedTaxes = 0m
                    };


                }



                /*
                 * 
                 * För varje transaktion, ska reportYearlySummary uppdateras för både sålda och köpa valutor.
                 * För den köpta valutan uppdateras, åtminstone, ClosingTaxbaseRate och för den sålda valutan uppdateras antingen accumulated losses eller profit.
                 * 
                 * Nästa steg är att uppdatera de 7 krypto/fiat-kolumnerna (som inte finns i modellen än). Se ReportExperiment.ods
                 * 
                 */





                if (i == detailedTransactions.Count - 1 || reportYearlySummary.Year < detailedTransactions[i + 1].DateTime.Year)
                {
                    reportYearlySummaries.Add(reportYearlySummary);
                }
            }

            return reportYearlySummaries;
        }

        private List<CurrencyCode> GetAllReportCurrencies(List<ReportYearlySummary> reportYearlySummaries)
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

        public void CreateReportCsv(string path, List<ReportYearlySummary> reportYearlySummaries)
        {
            List<CurrencyCode> allReportCurrencies = GetAllReportCurrencies(reportYearlySummaries);
            string delimter = ";";
            using (TextWriter writer = File.CreateText(path))
            {
                List<string> headers = new List<string>();
                foreach (var property in typeof(ReportYearlySummary).GetProperties())
                {
                    if (property.PropertyType == typeof(List<ReportCurrency>))
                    {
                        foreach (var currency in allReportCurrencies)
                        {
                            foreach (var currencyProperty in typeof(ReportCurrency).GetProperties())
                            {
                                if (currencyProperty != typeof(CurrencyCode))
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
                writer.WriteLine(string.Join(delimter, headers));
            }
        }
    }
}
