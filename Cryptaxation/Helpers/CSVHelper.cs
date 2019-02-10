using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptaxation.Models;
using Microsoft.VisualBasic.FileIO;

namespace Cryptaxation
{
    public class CsvHelper
    {
        public List<BitstampTransaction> CreateBitstampTransactionList(string path, List<Rate> rates)
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
                        if (bitstampTransaction.Type == BitstampTransactionType.Deposit && bitstampTransaction.Amount.Type == CurrencyType.FiatCurrency)
                        {
                            bitstampTransaction.SubType = SubType.Buy;
                        }
                        if (bitstampTransaction.Type == BitstampTransactionType.Withdrawal && bitstampTransaction.Amount.Type == CurrencyType.FiatCurrency)
                        {
                            bitstampTransaction.SubType = SubType.Sell;
                        }
                        if ((bitstampTransaction.Type == BitstampTransactionType.Deposit || bitstampTransaction.Type == BitstampTransactionType.Withdrawal) && bitstampTransaction.Amount.Type == CurrencyType.FiatCurrency)
                        {
                            List<Rate> originRates = rates.Where(r => r.OriginCurrency == CurrencyCode.SEK && r.DestinationCurrency == bitstampTransaction.Amount.CurrencyCode && r.Date <= bitstampTransaction.DateTime).ToList();

                            decimal rate = originRates.FirstOrDefault().Value;
                            bitstampTransaction.Type = BitstampTransactionType.Market;
                            bitstampTransaction.Value = new Currency()
                            {
                                Value = bitstampTransaction.Amount.Value / rate,
                                CurrencyCode = CurrencyCode.SEK
                            };
                            bitstampTransaction.Rate = new Currency()
                            {
                                Value = rate,
                                CurrencyCode = CurrencyCode.SEK
                            };
                            bitstampTransaction.Fee = new Currency()
                            {
                                Value = 0m,
                                CurrencyCode = CurrencyCode.SEK
                            };
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

        private BitstampTransaction CreateBitstampTransaction(string[] row)
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

        public void CreateDetailedTransactionsCsv(string path, List<DetailedTransaction> detailedTransactions)
        {
            string delimter = ";";
            using (TextWriter writer = File.CreateText(path))
            {
                List<string> headers = new List<string>();
                foreach (var property in typeof(DetailedTransaction).GetProperties())
                {
                    headers.Add(property.Name);
                }
                writer.WriteLine(string.Join(delimter, headers));
                foreach (var detailedTransaction in detailedTransactions) {
                    List<string> columns = new List<string>();
                    foreach (var property in typeof(DetailedTransaction).GetProperties())
                    {
                        object csvProperty = detailedTransaction.GetType().GetProperty(property.Name).GetValue(detailedTransaction, null);
                        if (csvProperty != null)
                        {
                            columns.Add((csvProperty.ToString().Equals("Undefined") ? string.Empty : csvProperty.ToString()));
                        }
                    }
                    writer.WriteLine(string.Join(delimter, columns));
                }
            }
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
                    CurrencyCode = (CurrencyCode)Enum.Parse(typeof(CurrencyCode), valueCurrency[1], true)
                };
            }
            return new Currency();
        }

        public List<Rate> CreateRateList(string riksbankenPath, string bitstampPath)
        {
            List<Rate> rateList = CreateRateList(riksbankenPath);
            rateList.AddRange(CreateRateList(bitstampPath));

            return rateList.OrderBy(r => r.DestinationCurrency).ThenBy(r => r.OriginCurrency).ThenByDescending(r => r.Date).ToList();
        }
        
        private List<Rate> CreateRateList(string path)
        {
            List<Rate> rates = new List<Rate>();
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
                        rates.AddRange(CreateRates(row));
                    }
                    else
                    {
                        throw new Exception("No rows found.");
                    }
                }
            }
            return rates;
        }
        
        private List<Rate> CreateRates(string[] row)
        {
            List<Rate> rates = new List<Rate>();
            DateTime? date = null;
            for (int i = 0; i < row.Length; i++)
            {
                RateFields rateFields = (RateFields)i;
                if (row.Length == 2 && i == 1)
                {
                    rateFields = RateFields.BTCUSD;
                }
                switch (rateFields)
                {
                    case RateFields.Datum:
                        string tmp = row[i].Substring(0, 10);
                        date = DateTime.ParseExact(tmp, "yyyy-MM-dd", CultureInfo.InvariantCulture);
                        break;
                    case RateFields.SEKUSD:
                        rates.Add(new Rate()
                        {
                            Date = date.GetValueOrDefault(),
                            OriginCurrency = CurrencyCode.SEK,
                            DestinationCurrency = CurrencyCode.USD,
                            Value = decimal.Parse(row[i], NumberStyles.Any, CultureInfo.InvariantCulture)
                        });
                        break;
                    case RateFields.USDSEK:
                        rates.Add(new Rate()
                        {
                            Date = date.GetValueOrDefault(),
                            OriginCurrency = CurrencyCode.USD,
                            DestinationCurrency = CurrencyCode.SEK,
                            Value = decimal.Parse(row[i], NumberStyles.Any, CultureInfo.InvariantCulture)
                        });
                        break;
                    case RateFields.SEKEUR:
                        rates.Add(new Rate()
                        {
                            Date = date.GetValueOrDefault(),
                            OriginCurrency = CurrencyCode.SEK,
                            DestinationCurrency = CurrencyCode.EUR,
                            Value = decimal.Parse(row[i], NumberStyles.Any, CultureInfo.InvariantCulture)
                        });
                        break;
                    case RateFields.EURSEK:
                        rates.Add(new Rate()
                        {
                            Date = date.GetValueOrDefault(),
                            OriginCurrency = CurrencyCode.EUR,
                            DestinationCurrency = CurrencyCode.SEK,
                            Value = decimal.Parse(row[i], NumberStyles.Any, CultureInfo.InvariantCulture)
                        });
                        break;
                    case RateFields.EURUSD:
                        rates.Add(new Rate()
                        {
                            Date = date.GetValueOrDefault(),
                            OriginCurrency = CurrencyCode.EUR,
                            DestinationCurrency = CurrencyCode.USD,
                            Value = decimal.Parse(row[i], NumberStyles.Any, CultureInfo.InvariantCulture)
                        });
                        break;
                    case RateFields.USDEUR:
                        rates.Add(new Rate()
                        {
                            Date = date.GetValueOrDefault(),
                            OriginCurrency = CurrencyCode.USD,
                            DestinationCurrency = CurrencyCode.EUR,
                            Value = decimal.Parse(row[i], NumberStyles.Any, CultureInfo.InvariantCulture)
                        });
                        break;
                    case RateFields.BTCUSD:
                        rates.Add(new Rate()
                        {
                            Date = date.GetValueOrDefault(),
                            OriginCurrency = CurrencyCode.BTC,
                            DestinationCurrency = CurrencyCode.USD,
                            Value = decimal.Parse(row[i], NumberStyles.Any, CultureInfo.InvariantCulture)
                        });
                        break;
                    default:
                        throw new Exception("Invalid field");
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
        }

        private enum RateFields
        {
            Datum = 0,
            SEKUSD = 1,
            USDSEK = 2,
            SEKEUR = 3,
            EURSEK = 4,
            EURUSD = 5,
            USDEUR = 6,
            BTCUSD = 7
        }
    }
}
