using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Cryptaxation.Csv.Logic;
using Cryptaxation.Entities;
using Cryptaxation.Helpers;
using Cryptaxation.Pdf.Logic;
using Cryptaxation.Pdf.Models;

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
        private readonly TransactionHelper _transactionHelper;

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
            
            _transactionHelper = new TransactionHelper();
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
            RateLogic<Rate> rateLogic = new RateLogic<Rate>();
            List<Rate> rateList = rateLogic.CreateRateList(new [] {
                _riksbankenRatesPath,
                _ratesPath
            }).OrderBy(r => r.DestinationCurrency).ThenBy(r => r.OriginCurrency).ThenByDescending(r => r.Date).ToList();
            
            TransactionLogic<Transaction> transactionLogic = new TransactionLogic<Transaction>(rateList);
            List<Transaction> transactionList = transactionLogic.CreateTransactionList(_transactionsPath);

            int[] years = 
            {
                2014,
                2015,
                2016,
                2017,
                2018
            };
            _transactionHelper.UpdateK4TransactionListsFromTransactions(transactionList, rateList);

            DetailedTransactionLogic<DetailedTransaction> detailedTransactionLogic = new DetailedTransactionLogic<DetailedTransaction>();
            detailedTransactionLogic.CreateDetailedTransactionsCsv(_transactionHelper.DetailedTransactions, _outputPath + @"\Detailed transactions.csv");

            ReportLogic reportLogic = new ReportLogic();
            List<ReportYearlySummary> reportYearlySummaries = reportLogic.CreateReportYearlySummaryList(_transactionHelper.DetailedTransactions);
            reportLogic.CreateReportCsv(_outputPath + @"\Yearly reports.csv", reportYearlySummaries);

            K4FormModel k4FormModel = new K4FormModel
            {
                Years = years,
                FullName = _fullName,
                PersonalIdentificatonNumber = _personalIdentificationNumber,
                CryptoTransactions = _transactionHelper.K4CryptoCurrencyTransactions,
                FiatTransactions = _transactionHelper.K4FiatCurrencyTransactions
            };
            K4FormLogic k4FormLogic = new K4FormLogic(k4FormModel);
            List<K4FillModel> k4FillModels = k4FormLogic.GetK4FillModelList();
            PdfLogic pdfLogic = new PdfLogic(_outputPath, _processName);

            k4FillModels.ForEach(k4FillModel =>
            {
                K4FillLogic k4FillLogic = new K4FillLogic(pdfLogic, k4FillModel);
                k4FillLogic.FillForms();
            });
            
            if (k4FillModels.Count > 0)
            {
                pdfLogic.SaveAndClose();
            }
        }
    }
}
