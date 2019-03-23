using System.Collections.Generic;
using System.Linq;
using Cryptaxation.Csv.Logic;
using Cryptaxation.Entities;
using Cryptaxation.Parse.Logic;
using Cryptaxation.Pdf.Logic;
using Cryptaxation.Pdf.Models;

namespace Cryptaxation.GUI
{
    public class Logic
    {
        private readonly ValidationLogic _validationLogic;
        private readonly string _fullName;
        private readonly string _personalIdentificationNumber;
        private readonly List<int> _years;
        private readonly string _transactionsPath;
        private readonly string _fiatRatesPath;
        private readonly string _ratesPath;
        private readonly string _outputPath;
        private readonly string _processName;

        public Logic(string fullName, string personalIdentificationNumber, List<int> years, string transactionsPath, string fiatRatesPath, string ratesPath, string outputPath, string processName)
        {
            _fullName = fullName;
            _personalIdentificationNumber = personalIdentificationNumber;
            _years = years;
            _transactionsPath = transactionsPath;
            _fiatRatesPath = fiatRatesPath;
            _ratesPath = ratesPath;
            _outputPath = outputPath;
            _processName = processName;
            _validationLogic = new ValidationLogic(fullName, personalIdentificationNumber, years, transactionsPath, fiatRatesPath, ratesPath, outputPath, processName);
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
            var transactionLogic = new TransactionLogic<Transaction, DetailedTransaction, K4TransactionModel>(rateList);
            transactionLogic.ParseTransactions(transactionList);
            var detailedTransactionCsvLogic = new DetailedTransactionCsvLogic<DetailedTransaction>(_outputPath + @"\Detailed transactions.csv");
            detailedTransactionCsvLogic.CreateDetailedTransactionsCsv(transactionLogic.DetailedTransactions);

            var reportLogic = new ReportLogic<ReportYearlySummary>(transactionLogic.DetailedTransactions);
            var reportYearlySummaries = reportLogic.CreateReportYearlySummaryList();
            var reportCsvLogic = new ReportCsvLogic<ReportYearlySummary>(_outputPath + @"\Yearly reports.csv");
            reportCsvLogic.CreateReportCsv(reportYearlySummaries);

            var k4FormModel = new K4FormModel
            {
                FullName = _fullName,
                PersonalIdentificatonNumber = _personalIdentificationNumber,
                Years = _years,
                CryptoTransactions = transactionLogic.K4CryptoCurrencyTransactions,
                FiatTransactions = transactionLogic.K4FiatCurrencyTransactions
            };
            var k4FormLogic = new K4FormLogic<K4FillModel, K4TabIndexModel>(k4FormModel);
            var k4FillModels = k4FormLogic.GetK4FillModelList();
            var pdfLogic = new PdfLogic(_outputPath, _processName);
            k4FillModels.ForEach(k4FillModel =>
            {
                var k4FillLogic = new K4FillLogic(pdfLogic, k4FillModel);
                k4FillLogic.FillAndSaveForms();
            });
        }
    }
}
