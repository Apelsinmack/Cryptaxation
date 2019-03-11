using System;
using System.IO;
using System.Linq;
using Cryptaxation.Csv.Logic;
using Cryptaxation.Entities;
using Cryptaxation.Pdf.Logic;
using Cryptaxation.Pdf.Models;
using Cryptaxation.Transaction.Logic;

namespace Cryptaxation
{
    public class Logic
    {
        private readonly string _fullName;
        private readonly string _personalIdentificationNumber;
        private readonly string _transactionsPath;
        private readonly string _riksbankenRatesPath;
        private readonly string _ratesPath;
        private readonly string _k4Path;
        private readonly string _outputPath;
        private readonly string _processName;

        public Logic(string fullName, string personalIdentificationNumber, string transactionsPath, string riksbankenRatesPath, string ratesPath, string k4Path, string outputPath, string processName)
        {
            _fullName = fullName;
            _personalIdentificationNumber = personalIdentificationNumber;
            _transactionsPath = transactionsPath;
            _riksbankenRatesPath = riksbankenRatesPath;
            _ratesPath = ratesPath;
            _k4Path = k4Path;
            _outputPath = outputPath;
            _processName = processName;

            ValidateInput();
        }

        private void ValidateInput()
        {
            ValidateFullName();
            ValidatePersonalIdentificationNumber();
            ValidateTransactionsPath();
            ValidateRatesPath();
            ValidateK4Path();
            ValidateOutputPath();
        }

        private void ValidateFullName()
        {
            if (string.IsNullOrWhiteSpace(_fullName))
            {
                throw new Exception("Invalid full name.");
            }
        }

        private void ValidatePersonalIdentificationNumber()
        {
            if (string.IsNullOrWhiteSpace(_personalIdentificationNumber))
            {
                throw new Exception("Invalid person number.");
            }
        }

        private void ValidateTransactionsPath()
        {
            if (string.IsNullOrWhiteSpace(_transactionsPath))
            {
                throw new Exception("Invalid transactions path.");
            }
            if (!File.Exists(_transactionsPath))
            {
                throw new Exception("Transactions file does not exist.");
            }
        }

        private void ValidateRatesPath()
        {
            if (string.IsNullOrWhiteSpace(_riksbankenRatesPath))
            {
                throw new Exception("Invalid rates path.");
            }
            if (!File.Exists(_riksbankenRatesPath))
            {
                throw new Exception("Rates file does not exist.");
            }
        }

        private void ValidateK4Path()
        {
            if (string.IsNullOrWhiteSpace(_k4Path))
            {
                throw new Exception("Invalid K4 path.");
            }
            if (!File.Exists(_k4Path))
            {
                throw new Exception("K4 file does not exist.");
            }
        }

        private void ValidateOutputPath()
        {
            if (string.IsNullOrWhiteSpace(_outputPath))
            {
                throw new Exception("Invalid output path.");
            }
            if (!Directory.Exists(_outputPath))
            {
                Directory.CreateDirectory(_outputPath);
            }
        }

        public void Execute()
        {
            var rateLogic = new RateLogic<Rate>();
            var rateList = rateLogic.CreateRateList(new [] {
                _riksbankenRatesPath,
                _ratesPath
            }).OrderBy(r => r.DestinationCurrency).ThenBy(r => r.OriginCurrency).ThenByDescending(r => r.Date).ToList();
            
            var transactionLogic = new TransactionLogic<Entities.Transaction>(rateList);
            var transactionList = transactionLogic.CreateTransactionList(_transactionsPath);

            var parseLogic = new ParseLogic<Entities.Transaction, DetailedTransaction, K4TransactionModel>(rateList);
            parseLogic.ParseTransactions(transactionList);

            int[] years = 
            {
                2014,
                2015,
                2016,
                2017,
                2018
            };

            var detailedTransactionLogic = new DetailedTransactionLogic<DetailedTransaction>();
            detailedTransactionLogic.CreateDetailedTransactionsCsv(parseLogic.DetailedTransactions, _outputPath + @"\Detailed transactions.csv");

            var reportLogic = new ReportLogic();
            var reportYearlySummaries = reportLogic.CreateReportYearlySummaryList(parseLogic.DetailedTransactions);
            reportLogic.CreateReportCsv(_outputPath + @"\Yearly reports.csv", reportYearlySummaries);

            var k4FormModel = new K4FormModel
            {
                Years = years,
                FullName = _fullName,
                PersonalIdentificatonNumber = _personalIdentificationNumber,
                CryptoTransactions = parseLogic.K4CryptoCurrencyTransactions,
                FiatTransactions = parseLogic.K4FiatCurrencyTransactions
            };
            var k4FormLogic = new K4FormLogic<K4FillModel, K4TabIndexModel>(k4FormModel);
            var k4FillModels = k4FormLogic.GetK4FillModelList();
            var pdfLogic = new PdfLogic(_outputPath, _processName);

            k4FillModels.ForEach(k4FillModel =>
            {
                var k4FillLogic = new K4FillLogic(pdfLogic, k4FillModel);
                k4FillLogic.FillForms();
                pdfLogic.SaveAndClose();
            });
        }
    }
}
