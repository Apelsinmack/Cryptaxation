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
                                    //bitstampTransaction.Type = (BitstampTransactionFields)Enum.Parse(typeof(BitstampTransactionFields), fields[i], true);
                                    break;
                                case BitstampTransactionFields.Datetime:
                                    break;
                                case BitstampTransactionFields.Account:
                                    break;
                                case BitstampTransactionFields.Amount:
                                    break;
                                case BitstampTransactionFields.Value:
                                    break;
                                case BitstampTransactionFields.Rate:
                                    break;
                                case BitstampTransactionFields.Fee:
                                    break;
                                case BitstampTransactionFields.SubType:
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
