using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptaxation.Models;
using Microsoft.VisualBasic.FileIO;

namespace Cryptaxation
{
    public class CsvHelper
    {
        public CsvHelper()
        {
        }

        public List<BitstampTransaction> CreateBitstampTransactionList(string path)
        {
            List<BitstampTransaction> bitstampTransactions = new List<BitstampTransaction>();
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                for (int rowIndex = 0; !parser.EndOfData; rowIndex++)
                {
                    string[] row = parser.ReadFields();
                    if (rowIndex == 0)
                    {
                        continue;
                    }
                    if (row != null)
                    {
                        BitstampTransaction bitstampTransaction  = CreateBitstampTransaction(row);
                        bitstampTransactions.Add(bitstampTransaction);
                    }
                    else
                    {
                        throw new Exception("No rows found.");
                    }
                }
            }
            return bitstampTransactions;
        }

        public BitstampTransaction CreateBitstampTransaction(string[] row)
        {
            BitstampTransaction bitstampTransaction = new BitstampTransaction();
            for (int i = 0; i < row.Length; i++)
            {
                switch ((BitstampTransactionFields)i)
                {
                    case BitstampTransactionFields.Type:
                        if (!string.IsNullOrWhiteSpace(row[i]))
                        {
                            bitstampTransaction.Type = (BitstampTransactionType) Enum.Parse(typeof(BitstampTransactionType), row[i], true);
                        }
                        break;
                    case BitstampTransactionFields.Datetime:
                        bitstampTransaction.DateTime = DateTime.ParseExact(row[i], "MMM. dd, yyyy, hh:mm tt", CultureInfo.InvariantCulture);
                        break;
                    case BitstampTransactionFields.Account:
                        bitstampTransaction.Account = row[i];
                        break;
                    case BitstampTransactionFields.Amount:
                        bitstampTransaction.Amount = ConvertFieldToCurrency(row[i]);
                        break;
                    case BitstampTransactionFields.Value:
                        bitstampTransaction.Value = ConvertFieldToCurrency(row[i]);
                        break;
                    case BitstampTransactionFields.Rate:
                        bitstampTransaction.Rate = ConvertFieldToCurrency(row[i]);
                        break;
                    case BitstampTransactionFields.Fee:
                        bitstampTransaction.Fee = ConvertFieldToCurrency(row[i]);
                        break;
                    case BitstampTransactionFields.SubType:
                        if (!string.IsNullOrWhiteSpace(row[i]))
                        {
                            bitstampTransaction.SubType = (SubType)Enum.Parse(typeof(SubType), row[i], true);
                        }
                        break;
                    default:
                        throw new Exception("Invalid field");
                }
            }
            return bitstampTransaction;
        }

        public List<Rate> CreateRateList(string path)
        {
            List<Rate> rates = new List<Rate>();
            using (TextFieldParser parser = new TextFieldParser(path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (fields != null)
                    {
                        Rate rate = new Rate();
                        for (int i = 0; i < fields.Length; i++)
                        {
                            switch (i)
                            {
                                default:
                                    throw new Exception("Invalid field");
                            }
                        }
                        rates.Add(rate);
                    }
                    else
                    {
                        throw new Exception("No rows found.");
                    }
                }
            }
            return rates;
        }
        
        private Currency ConvertFieldToCurrency(string field, CultureInfo cultureInfo = null, NumberStyles numberStyle = NumberStyles.Any)
        {
            if (!string.IsNullOrWhiteSpace(field))
            {
                if (cultureInfo == null)
                {
                    cultureInfo = CultureInfo.InvariantCulture;
                }
                string[] valueCurrency = field.Split(' ');
                return new Currency()
                {
                    Value = decimal.Parse(valueCurrency[0], numberStyle, cultureInfo),
                    CurrencyCode = (CurrencyCode) Enum.Parse(typeof(CurrencyCode), valueCurrency[1], true)
                };
            }
            return new Currency();
        }

        private enum BitstampTransactionFields
        {
            Type = 0,
            Datetime = 1,
            Account = 2,
            Amount = 3,
            Value = 4,
            Rate = 5,
            Fee = 6,
            SubType = 7
        };

        private enum RateFields
        {
        };
    }
}
