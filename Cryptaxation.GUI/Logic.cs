using System.Collections.Generic;
using System.Linq;
using Cryptaxation.Csv.Logic;
using Cryptaxation.Entities;
using Cryptaxation.Entities.Types.Enums;
using Cryptaxation.Parse.Logic;

namespace Cryptaxation.GUI
{
    public class Logic
    {
        private readonly ValidationLogic _validationLogic;
        private readonly string _transactionsPath;
        private readonly string _fiatRatesPath;
        private readonly string _ratesPath;
        private readonly string _outputPath;

        public Logic(string transactionsPath, string fiatRatesPath, string ratesPath, string outputPath)
        {
            _transactionsPath = transactionsPath;
            _fiatRatesPath = fiatRatesPath;
            _ratesPath = ratesPath;
            _outputPath = outputPath;
            _validationLogic = new ValidationLogic(transactionsPath, fiatRatesPath, ratesPath, outputPath);
        }

        public void Execute()
        {
            _validationLogic.ValidateInput();
            var rateCsvLogic = new RateCsvLogic<Rate>();
            var rateList = rateCsvLogic.CreateRateList(new [] {
                _fiatRatesPath,
                _ratesPath
            }).OrderBy(r => r.DestinationCurrency).ThenBy(r => r.OriginCurrency).ThenByDescending(r => r.Date).ToList();
            var transactionCsvLogic = new TransactionCsvLogic<Transaction>(_transactionsPath, rateList);
            var transactionList = transactionCsvLogic.CreateTransactionList();
            var transactionLogic = new TransactionLogic<Transaction, DetailedTransaction>(CurrencyCode.SEK, rateList);
            transactionLogic.ParseTransactions(transactionList);

            var detailedTransactionCsvLogic = new DetailedTransactionCsvLogic<DetailedTransaction>(_outputPath + @"\Detailed transactions.csv");
            detailedTransactionCsvLogic.CreateDetailedTransactionsCsv(transactionLogic.DetailedTransactions);

            var reportLogic = new ReportLogic<ReportYearlySummary>(transactionLogic.DetailedTransactions);
            var reportYearlySummaries = reportLogic.CreateReportYearlySummaryList();
            var reportCsvLogic = new ReportCsvLogic<ReportYearlySummary>(_outputPath + @"\Yearly reports.csv");
            reportCsvLogic.CreateReportCsv(reportYearlySummaries);

            var k4ReportLogic = new K4ReportLogic<K4ReportCurrencySummary>(CurrencyCode.SEK, transactionLogic.DetailedTransactions);
            var kReportYearlySummaryList = k4ReportLogic.CreateK4ReportYearlySummaryList();
            var k4ReportCsvLogic = new K4ReportCsvLogic<K4ReportCurrencySummary>(_outputPath + @"\K4 {{year}}.csv");
            k4ReportCsvLogic.CreateK4ReportCsv(kReportYearlySummaryList);

        }
    }
}
