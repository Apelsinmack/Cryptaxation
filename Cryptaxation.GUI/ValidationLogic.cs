using System;
using System.Collections.Generic;
using System.IO;

namespace Cryptaxation.GUI
{
    public class ValidationLogic
    {
        private readonly string _fullName;
        private readonly string _personalIdentificationNumber;
        private readonly List<int> _years;
        private readonly string _transactionsPath;
        private readonly string _riksbankenRatesPath;
        private readonly string _ratesPath;
        private readonly string _outputPath;
        private readonly string _processName;

        public ValidationLogic(string fullName, string personalIdentificationNumber, List<int> years, string transactionsPath, string riksbankenRatesPath, string ratesPath, string outputPath, string processName)
        {
            _fullName = fullName;
            _personalIdentificationNumber = personalIdentificationNumber;
            _years = years;
            _transactionsPath = transactionsPath;
            _riksbankenRatesPath = riksbankenRatesPath;
            _ratesPath = ratesPath;
            _outputPath = outputPath;
            _processName = processName;
        }

        public void ValidateInput()
        {
            ValidateFullName();
            ValidatePersonalIdentificationNumber();
            ValidateYears();
            ValidateTransactionsPath();
            ValidateRiksbankenRatesPath();
            ValidateRatesPath();
            ValidateOutputPath();
            ValidateProcessName();
        }

        public void ValidateFullName()
        {
            if (string.IsNullOrWhiteSpace(_fullName))
            {
                throw new Exception("Invalid full name.");
            }
        }

        public void ValidatePersonalIdentificationNumber()
        {
            if (string.IsNullOrWhiteSpace(_personalIdentificationNumber))
            {
                throw new Exception("Invalid person number.");
            }
        }

        private void ValidateYears()
        {
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

        public void ValidateRiksbankenRatesPath()
        {
            if (string.IsNullOrWhiteSpace(_riksbankenRatesPath))
            {
                throw new Exception("Invalid riksbanken rates path.");
            }
            if (!File.Exists(_riksbankenRatesPath))
            {
                throw new Exception("Riksbanken rates file does not exist.");
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

        public void ValidateProcessName()
        {
            if (string.IsNullOrWhiteSpace(_processName))
            {
                throw new Exception("Invalid process name.");
            }
        }
    }
}
