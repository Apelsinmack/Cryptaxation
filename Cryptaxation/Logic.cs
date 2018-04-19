using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptaxation.Helpers;
using Cryptaxation.Models;

namespace Cryptaxation
{
    public class Logic
    {
        private string _fullName;
        private string _personalIdentificationNumber;
        private string _bitstampTransactionsPath;
        private string _ratesPath;
        private string _k4Path;
        private string _outputPath;
        private string _processName;
        private CsvHelper _csvHelper;
        private TransactionHelper _transactionHelper;

        public Logic(string fullName, string personalIdentificationNumber, string bitstampTransactionsPath, string ratesPath, string k4Path, string outputPath, string processName)
        {
            _fullName = fullName;
            _personalIdentificationNumber = personalIdentificationNumber;
            _bitstampTransactionsPath = bitstampTransactionsPath;
            _ratesPath = ratesPath;
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
            // TODO
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
            if (string.IsNullOrWhiteSpace(_ratesPath))
            {
                throw new Exception("Invalid rates path.");
            }
            if (!File.Exists(_ratesPath))
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
            List<BitstampTransaction> bitstampTransactionList = _csvHelper.CreateBitstampTransactionList(_bitstampTransactionsPath);
            List<Rate> rateList = _csvHelper.CreateRateList(_ratesPath);
            
            if (useTestData)
            {
                ExecuteWithTestData();
            }
            else
            {
                _transactionHelper.UpdateK4TransactionListsFromBitstampTransactions(bitstampTransactionList, rateList, 2014);
                _csvHelper.CreateDetailedTransactionsCsv(_outputPath + @"\Detailed transactions.csv", _transactionHelper.DetailedTransactions);
                //K4Helper k4Helper = new K4Helper(_fullName, _personalIdentificationNumber, _k4Path, _outputPath, _processName, _transactionHelper.K4FiatCurrencyTransactions, _transactionHelper.K4CryptoCurrencyTransactions);
                //k4Helper.FillForms();
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

            K4Helper k4Helper = new K4Helper(_fullName, _personalIdentificationNumber, _k4Path, _outputPath, _processName, fiatTestList, cryptoTestList);
            k4Helper.FillForms();
        }
    }
}
