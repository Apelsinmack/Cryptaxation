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

        public void Execute(bool useTestData = false)
        {
            List<Rate> rateList = _csvHelper.CreateRateList(_riksbankenRatesPath, _bitstampRatesPath);
            List<BitstampTransaction> bitstampTransactionList = _csvHelper.CreateBitstampTransactionList(_bitstampTransactionsPath, rateList);
            
            if (useTestData)
            {
                ExecuteWithTestData();
            }
            else
            {
                int year = 2018;
                _transactionHelper.UpdateK4TransactionListsFromBitstampTransactions(bitstampTransactionList, rateList, year);
                _csvHelper.CreateDetailedTransactionsCsv(_outputPath + @"\Detailed transactions.csv", _transactionHelper.DetailedTransactions);
                List<ReportYearlySummary> reportYearlySummaries = _csvHelper.CreateReportYearlySummaryList(_transactionHelper.DetailedTransactions);
                _csvHelper.CreateReportCsv(_outputPath + @"\Yearly reports.csv", reportYearlySummaries);
                K4ResourceLogic k4ResourceLogic = new K4ResourceLogic();
                PdfLogic pdfLogic = new PdfLogic(_outputPath, _processName);
                K4FormLogic k4Logic = new K4FormLogic(pdfLogic, new K4Form()
                {
                    TabIndexes = k4ResourceLogic.GetTabIndexesByYear(year),
                    Name = _fullName,
                    PersonalIdentificatonNumber = _personalIdentificationNumber,
                    CryptoTransactions = _transactionHelper.K4CryptoCurrencyTransactions,
                    FiatTransactions = _transactionHelper.K4FiatCurrencyTransactions
                });
                k4Logic.FillForms(year);
            }
        }

        private void ExecuteWithTestData()
        {
            List<K4Transaction> fiatTestList = new List<K4Transaction>();
            for (int i = 0; i < 8; i++)
            {
                fiatTestList.Add(new K4Transaction()
                {
                    Amount = i,
                    Currency = "Fiat",
                    SalesPrice = i,
                    TaxBasis = i,
                    Gain = i,
                    Loss = i
                });
            }

            List<K4Transaction> cryptoTestList = new List<K4Transaction>();
            for (int i = 0; i < 20; i++)
            {
                cryptoTestList.Add(new K4Transaction()
                {
                    Amount = i,
                    Currency = "Crypto",
                    SalesPrice = i,
                    TaxBasis = i,
                    Gain = i,
                    Loss = i
                });
            }

            int year = 2013;
            K4ResourceLogic k4ResourceLogic = new K4ResourceLogic();
            PdfLogic pdfLogic = new PdfLogic(_outputPath, _processName);
            K4FormLogic k4Logic = new K4FormLogic(pdfLogic, new K4Form()
            {
                TabIndexes = k4ResourceLogic.GetTabIndexesByYear(year),
                Name = _fullName,
                PersonalIdentificatonNumber = _personalIdentificationNumber,
                CryptoTransactions = cryptoTestList,
                FiatTransactions = fiatTestList
            });
            k4Logic.FillForms(year);
        }
    }
}
