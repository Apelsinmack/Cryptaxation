using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptaxation.Models;
using Microsoft.VisualBasic.FileIO;

namespace Cryptaxation
{
    public class CsvHelper
    {
        private string _path;
        public CsvHelper(string path)
        {
            _path = path;
        }

        public List<BitstampTransaction> CreateBitstampTransactionList()
        {
            List<BitstampTransaction> bitstampTransactions = new List<BitstampTransaction>();
            using (TextFieldParser parser = new TextFieldParser(_path))
            {
                parser.TextFieldType = FieldType.Delimited;
                parser.SetDelimiters(",");
                while (!parser.EndOfData)
                {
                    string[] fields = parser.ReadFields();
                    if (fields != null)
                    {
                        BitstampTransaction bitstampTransaction = new BitstampTransaction();
                        for (int i = 0; i < fields.Length; i++)
                        {
                            switch ((BitstampTransactionFields)i)
                            {
                                case BitstampTransactionFields.Type:
                                    bitstampTransaction.Type = (BitstampTransactionType)Enum.Parse(typeof(BitstampTransactionType), fields[i], true);
                                    break;
                                case BitstampTransactionFields.Datetime:
                                    bitstampTransaction.DateTime = DateTime.ParseExact(fields[i], "MMM. dd, yyyy, hh:mm tt", System.Globalization.CultureInfo.InvariantCulture);
                                    break;
                                case BitstampTransactionFields.Account:
                                    bitstampTransaction.Account = fields[i];
                                    break;
                                case BitstampTransactionFields.Amount:
                                    string[] amount = fields[i].Split(' ');
                                    bitstampTransaction.Amount = new Currency()
                                    {
                                        Value = decimal.Parse(amount[0]),
                                        CurrencyCode = (CurrencyCode)Enum.Parse(typeof(CurrencyCode), amount[1], true)
                                    };
                                    break;
                                case BitstampTransactionFields.Value:
                                    string[] value = fields[i].Split(' ');
                                    bitstampTransaction.Value = new Currency()
                                    {
                                        Value = decimal.Parse(value[0]),
                                        CurrencyCode = (CurrencyCode)Enum.Parse(typeof(CurrencyCode), value[1], true)
                                    };
                                    break;
                                case BitstampTransactionFields.Rate:
                                    string[] rate = fields[i].Split(' ');
                                    bitstampTransaction.Value = new Currency()
                                    {
                                        Value = decimal.Parse(rate[0]),
                                        CurrencyCode = (CurrencyCode)Enum.Parse(typeof(CurrencyCode), rate[1], true)
                                    };
                                    break;
                                case BitstampTransactionFields.Fee:
                                    string[] fee = fields[i].Split(' ');
                                    bitstampTransaction.Value = new Currency()
                                    {
                                        Value = decimal.Parse(fee[0]),
                                        CurrencyCode = (CurrencyCode)Enum.Parse(typeof(CurrencyCode), fee[1], true)
                                    };
                                    break;
                                case BitstampTransactionFields.SubType:
                                    bitstampTransaction.SubType = (SubType)Enum.Parse(typeof(SubType), fields[i], true);
                                    break;
                                default:
                                    throw new Exception("Invalid field");
                            }
                        }
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
