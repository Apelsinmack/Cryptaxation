﻿using System;
using System.Collections.Generic;
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
        private string _personNumber;
        private string _path;
        private string _processName;
        private CsvHelper _csvHelper;
        private PdfHelper _pdfHelper;
        private TransactionHelper _transactionHelper;

        public Logic(string fullName, string personNumber, string path, string processName)
        {
            _fullName = fullName;
            _personNumber = personNumber;
            _path = path;
            _processName = processName;

            ValidateInput();

            _csvHelper = new CsvHelper(_path);
            _pdfHelper = new PdfHelper(_processName);

            
        }

        public void ValidateInput()
        {
            ValidateFullName();
            ValidatePersonNumber();
        }

        public void ValidateFullName()
        {
            if (string.IsNullOrWhiteSpace(_fullName))
            {
                throw new Exception("Invalid full name.");
            }
        }

        public void ValidatePersonNumber()
        {
            // TODO
            if (string.IsNullOrWhiteSpace(_personNumber))
            {
                throw new Exception("Invalid person number.");
            }
        }

        public void Execute()
        {
            DateTime myDate = DateTime.ParseExact("2009-05-08 14:40:52,531", "yyyy-MM-dd HH:mm:ss,fff",
                                       System.Globalization.CultureInfo.InvariantCulture);

            DateTime myDate2 = DateTime.ParseExact("Aug. 21, 2014, 08:02 AM", "MMM. dd, yyyy, hh:mm tt",
                System.Globalization.CultureInfo.InvariantCulture);

            List<BitstampTransaction> bitstampTransactionList = _csvHelper.CreateBitstampTransactionList();
        }
    }
}
