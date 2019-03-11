using System.Collections.Generic;
using System.Linq;
using Cryptaxation.Csv.Logic;
using Cryptaxation.Entities;
using Cryptaxation.Pdf.Logic;
using Cryptaxation.Pdf.Models;
using Cryptaxation.Transaction.Logic;

namespace Cryptaxation.GUI
{
    public class Logic
    {
        private readonly ValidationLogic _validationLogic;
        private readonly string _fullName;
        private readonly string _personalIdentificationNumber;
        private readonly List<int> _years;
        private readonly string _transactionsPath;
        private readonly string _riksbankenRatesPath;
        private readonly string _ratesPath;
        private readonly string _outputPath;
        private readonly string _processName;

        public Logic(string fullName, string personalIdentificationNumber, List<int> years, string transactionsPath, string riksbankenRatesPath, string ratesPath, string outputPath, string processName)
        {
            _fullName = fullName;
            _personalIdentificationNumber = personalIdentificationNumber;
            _years = years;
            _transactionsPath = transactionsPath;
            _riksbankenRatesPath = riksbankenRatesPath;
            _ratesPath = ratesPath;
            _outputPath = outputPath;
            _processName = processName;
            _validationLogic = new ValidationLogic(fullName, personalIdentificationNumber, years, transactionsPath, riksbankenRatesPath, ratesPath, outputPath, processName);
        }

        public void Execute()
        {
            _validationLogic.ValidateInput();
            var rateLogic = new RateLogic<Rate>();
            var rateList = rateLogic.CreateRateList(new [] {
                _riksbankenRatesPath,
                _ratesPath
            }).OrderBy(r => r.DestinationCurrency).ThenBy(r => r.OriginCurrency).ThenByDescending(r => r.Date).ToList();           
            var transactionLogic = new TransactionLogic<Entities.Transaction>(rateList);
            var transactionList = transactionLogic.CreateTransactionList(_transactionsPath);
            var parseLogic = new ParseLogic<Entities.Transaction, DetailedTransaction, K4TransactionModel>(rateList);
            parseLogic.ParseTransactions(transactionList);
            var detailedTransactionLogic = new DetailedTransactionLogic<DetailedTransaction>();
            detailedTransactionLogic.CreateDetailedTransactionsCsv(parseLogic.DetailedTransactions, _outputPath + @"\Detailed transactions.csv");
            var reportLogic = new ReportLogic();
            var reportYearlySummaries = reportLogic.CreateReportYearlySummaryList(parseLogic.DetailedTransactions);
            reportLogic.CreateReportCsv(_outputPath + @"\Yearly reports.csv", reportYearlySummaries);
            var k4FormModel = new K4FormModel
            {
                FullName = _fullName,
                PersonalIdentificatonNumber = _personalIdentificationNumber,
                Years = _years,
                CryptoTransactions = parseLogic.K4CryptoCurrencyTransactions,
                FiatTransactions = parseLogic.K4FiatCurrencyTransactions
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
