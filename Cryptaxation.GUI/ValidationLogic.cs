using System;
using System.Collections.Generic;
using System.IO;

namespace Cryptaxation.GUI
{
    public class ValidationLogic
    {
        private readonly string _transactionsPath;
        private readonly string _fiatRatesPath;
        private readonly string _ratesPath;
        private readonly string _outputPath;

        public ValidationLogic(string transactionsPath, string fiatRatesPath, string ratesPath, string outputPath)
        {
            _transactionsPath = transactionsPath;
            _fiatRatesPath = fiatRatesPath;
            _ratesPath = ratesPath;
            _outputPath = outputPath;
        }

        public void ValidateInput()
        {
            ValidateTransactionsPath();
            ValidateFiatRatesPath();
            ValidateRatesPath();
            ValidateOutputPath();
        }
        public void ValidateTransactionsPath()
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

        public void ValidateFiatRatesPath()
        {
            if (string.IsNullOrWhiteSpace(_fiatRatesPath))
            {
                throw new Exception("Invalid fiat rates path.");
            }
            if (!File.Exists(_fiatRatesPath))
            {
                throw new Exception("Fiat rates file does not exist.");
            }
        }

        public void ValidateRatesPath()
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

        public void ValidateOutputPath()
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
    }
}
