using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptaxation.Helpers;
using Cryptaxation.Models;
using Cryptaxation.Pdf.Logic;
using Cryptaxation.Pdf.Models;

namespace Cryptaxation
{
    public class Logic
    {
        private string _fullName;
        private string _personalIdentificationNumber;
        private string _bitstampTransactionsPath;
        private string _riksbankenRatesPath;
        private string _bitstampRatesPath;
        private string _k4Path;
        private string _outputPath;
        private string _processName;
        private CsvHelper _csvHelper;
        private TransactionHelper _transactionHelper;

        public Logic(string fullName, string personalIdentificationNumber, string bitstampTransactionsPath, string riksbankenRatesPath, string bitstampRatesPath, string k4Path, string outputPath, string processName)
        {
            _fullName = fullName;
            _personalIdentificationNumber = personalIdentificationNumber;
            _bitstampTransactionsPath = bitstampTransactionsPath;
            _riksbankenRatesPath = riksbankenRatesPath;
            _bitstampRatesPath = bitstampRatesPath;
            _k4Path = k4Path;
            _outputPath = outputPath;
            _processName = processName;

            ValidateInput();

            _csvHelper = new CsvHelper();
            _transactionHelper = new TransactionHelper();
        }

        private void ValidateInput()
        {
            ValidateFullName();
            ValidatePersonalIdentificationNumber();
            ValidateBitstampTransactionsPath();
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

        private void ValidateBitstampTransactionsPath()
        {
            if (string.IsNullOrWhiteSpace(_bitstampTransactionsPath))
            {
                throw new Exception("Invalid bitstamp transactions path.");
            }
            if (!File.Exists(_bitstampTransactionsPath))
            {
                throw new Exception("Bitstamp transactions file does not exist.");
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
            List<Rate> rateList = _csvHelper.CreateRateList(_riksbankenRatesPath, _bitstampRatesPath);
            List<BitstampTransaction> bitstampTransactionList = _csvHelper.CreateBitstampTransactionList(_bitstampTransactionsPath, rateList);

            int[] years = 
            {
                2014,
                2015,
                2016,
                2017,
                2018
            };
            _transactionHelper.UpdateK4TransactionListsFromBitstampTransactions(bitstampTransactionList, rateList);
            _csvHelper.CreateDetailedTransactionsCsv(_outputPath + @"\Detailed transactions.csv", _transactionHelper.DetailedTransactions);
            List<ReportYearlySummary> reportYearlySummaries = _csvHelper.CreateReportYearlySummaryList(_transactionHelper.DetailedTransactions);
            _csvHelper.CreateReportCsv(_outputPath + @"\Yearly reports.csv", reportYearlySummaries);

            K4FormModel k4FormModel = new K4FormModel
            {
                Years = years,
                FullName = _fullName,
                PersonalIdentificatonNumber = _personalIdentificationNumber,
                CryptoTransactions = _transactionHelper.K4CryptoCurrencyTransactions,
                FiatTransactions = _transactionHelper.K4FiatCurrencyTransactions
            };
            K4FormLogic k4FormLogic = new K4FormLogic(k4FormModel);
            List<K4FillModel> k4FillModels = k4FormLogic.GetK4FillModels();
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
