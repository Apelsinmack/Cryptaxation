using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Cryptaxation.Models;
using Cryptaxation.Pdf.Models;

namespace Cryptaxation.Helpers
{
    public class TransactionHelper
    {
        public Dictionary<int, List<K4TransactionModel>> K4FiatCurrencyTransactions = new Dictionary<int, List<K4TransactionModel>>();
        public Dictionary<int, List<K4TransactionModel>> K4CryptoCurrencyTransactions = new Dictionary<int, List<K4TransactionModel>>();
        public List<DetailedTransaction> DetailedTransactions = new List<DetailedTransaction>();
        private int _lineNumber;
        private CurrencyCode _taxCurrencyCode;

        public void UpdateK4TransactionListsFromBitstampTransactions(List<BitstampTransaction> bitstampTransactions, List<Rate> rates)
        {
            /*try
            {*/
                List<Currency> taxBaseAmounts = new List<Currency>();
                List<Currency> taxBaseRates = new List<Currency>();
                _lineNumber = 0;
                _taxCurrencyCode = CurrencyCode.SEK;

                foreach (BitstampTransaction bitstampTransaction in bitstampTransactions)
                {
                    _lineNumber++;
                    if (bitstampTransaction.Type == BitstampTransactionType.Market)
                    {
                        DateTime date = bitstampTransaction.DateTime.Date;
                        if (bitstampTransaction.SubType == SubType.Buy)
                        {
                            if (bitstampTransaction.Value.CurrencyCode != _taxCurrencyCode)
                            {
                                HandleTransaction(date, bitstampTransaction.Amount, bitstampTransaction.Value, bitstampTransaction.Fee, bitstampTransaction.SubType, rates, taxBaseAmounts, taxBaseRates);
                            }
                            AddDetailedTransaction(date, bitstampTransaction.Amount, bitstampTransaction.Value, bitstampTransaction.Rate, bitstampTransaction.Fee, bitstampTransaction.SubType, ref taxBaseAmounts, ref taxBaseRates, rates);
                            UpdateTaxBases(date, bitstampTransaction.Amount, bitstampTransaction.Value, bitstampTransaction.Rate, bitstampTransaction.Fee, bitstampTransaction.SubType, ref taxBaseAmounts, ref taxBaseRates, rates);
                        }
                        else if (bitstampTransaction.SubType == SubType.Sell)
                        {
                            if (bitstampTransaction.Amount.CurrencyCode != _taxCurrencyCode)
                            {
                                HandleTransaction(date, bitstampTransaction.Value, bitstampTransaction.Amount, bitstampTransaction.Fee, bitstampTransaction.SubType, rates, taxBaseAmounts, taxBaseRates);
                            }
                            AddDetailedTransaction(date, bitstampTransaction.Value, bitstampTransaction.Amount, bitstampTransaction.Rate, bitstampTransaction.Fee, bitstampTransaction.SubType, ref taxBaseAmounts, ref taxBaseRates, rates);
                            UpdateTaxBases(date, bitstampTransaction.Value, bitstampTransaction.Amount, bitstampTransaction.Rate, bitstampTransaction.Fee, bitstampTransaction.SubType, ref taxBaseAmounts, ref taxBaseRates, rates);
                        }
                    }
                }
            /*}
            catch
            {
                ErrorMessage("UpdateK4TransactionListsFromBitstampTransactions");
            }*/
        }

        private void HandleTransaction(DateTime date, Currency bought, Currency sold, Currency fee, SubType subType, List<Rate> rates, List<Currency> taxBaseAmounts, List<Currency> taxBaseRates)
        {
            /*try
            {*/
            int totalSalesPrice = 0,
                taxBasis = 0,
                gain = 0,
                loss = 0;
            decimal rate = 0m, feeRate = 0m, totalSalesPriceDecimal = 0m;

            // Total sales price
            if (sold.CurrencyCode == CurrencyCode.Undefined || bought.CurrencyCode == CurrencyCode.Undefined)
            {
                ErrorMessage("HandleTransaction", "Sold and/or bought currency is undefined.");
            }
            if (sold.CurrencyCode < bought.CurrencyCode)
            {
                rate = GetRate(date, sold.CurrencyCode, _taxCurrencyCode, rates);
                feeRate = GetRate(date, fee.CurrencyCode, _taxCurrencyCode, rates);
                totalSalesPriceDecimal = sold.Value * rate - fee.Value * feeRate;
            }
            if (totalSalesPriceDecimal == 0m)
            {
                rate = GetRate(date, bought.CurrencyCode, _taxCurrencyCode, rates);
                feeRate = GetRate(date, fee.CurrencyCode, _taxCurrencyCode, rates);
                totalSalesPriceDecimal = bought.Value * rate - fee.Value * feeRate;
            }
            totalSalesPrice = (int)decimal.Round(totalSalesPriceDecimal);
            if (rate == 0m || feeRate == 0m)
            {
                throw new Exception("rate or fee rate should not be 0.");
            }

            // Tax basis
            taxBasis = (int)decimal.Round(sold.Value * GetTaxBaseRate(sold.CurrencyCode, taxBaseAmounts, taxBaseRates));

            // Gain or loss
            if (totalSalesPrice > taxBasis && sold.CurrencyCode != CurrencyCode.SEK) gain = totalSalesPrice - taxBasis;
            else if (totalSalesPrice < taxBasis && sold.CurrencyCode != CurrencyCode.SEK) loss = taxBasis - totalSalesPrice;

            // Add transaction
            AddK4Transaction(date.Year, sold, totalSalesPrice, taxBasis, gain, loss);
            /*}
            catch
            {
                ErrorMessage("HandleTransaction");
            }*/
        }

        private void UpdateTaxBases(DateTime date, Currency bought, Currency sold, Currency rate, Currency fee, SubType subType, ref List<Currency> taxBaseAmounts, ref List<Currency> taxBaseRates, List<Rate> rates)
        {
            /*try
            {*/
                if (!taxBaseAmounts.Exists(tba => tba.CurrencyCode == bought.CurrencyCode)) taxBaseAmounts.Add(new Currency() { CurrencyCode = bought.CurrencyCode });
                if (!taxBaseRates.Exists(tbr => tbr.CurrencyCode == bought.CurrencyCode)) taxBaseRates.Add(new Currency() { CurrencyCode = bought.CurrencyCode });
                if (!taxBaseAmounts.Exists(tba => tba.CurrencyCode == sold.CurrencyCode)) taxBaseAmounts.Add(new Currency() { CurrencyCode = sold.CurrencyCode });

                Currency taxBaseAmountBought = taxBaseAmounts.FirstOrDefault(tba => tba.CurrencyCode == bought.CurrencyCode);
                Currency taxBaseRateBought = taxBaseRates.FirstOrDefault(tbr => tbr.CurrencyCode == bought.CurrencyCode);
                Currency taxBaseAmountSold = taxBaseAmounts.FirstOrDefault(tba => tba.CurrencyCode == sold.CurrencyCode);

                // TODO! Break out to its own function: UpdateTaxBasis()
                if (bought.CurrencyCode != _taxCurrencyCode)
                {
                    decimal taxBasePriceBought = taxBaseAmountBought.Value * taxBaseRateBought.Value;
                    decimal boughtPrice = 0m;
                    decimal valueTaxationCurrencyFee = 0m;

                    if (fee.CurrencyCode != CurrencyCode.Undefined)
                    {
                        valueTaxationCurrencyFee = fee.Value * GetRate(date, fee.CurrencyCode, _taxCurrencyCode, rates);
                    }
                    if (sold.CurrencyCode < bought.CurrencyCode)
                    {
                        boughtPrice = sold.Value * GetRate(date, sold.CurrencyCode, _taxCurrencyCode, rates) + valueTaxationCurrencyFee;
                    }
                    if (boughtPrice == 0)
                    {
                        boughtPrice = bought.Value * GetRate(date, bought.CurrencyCode, _taxCurrencyCode, rates) + valueTaxationCurrencyFee;
                    }
                    if (boughtPrice == 0)
                    {
                        throw new Exception("Bought price should not be 0.");
                    }
                    
                    // (10 USD * 10 + 5 USD * 20) / (10 + 5) = 200 / 15 = 13,333...   (Old amount * Old rate + New value * Rate at that time) / Sum amount = New rate
                    taxBaseRateBought.Value = (taxBasePriceBought + boughtPrice) / (taxBaseAmountBought.Value + bought.Value);
                    taxBaseAmountBought.Value += bought.Value;
                }

                if (sold.CurrencyCode != _taxCurrencyCode) taxBaseAmountSold.Value -= sold.Value;
            /*}
            catch
            {
                ErrorMessage("UpdateTaxBases");
            }*/
        }

        private decimal GetRate(DateTime date, CurrencyCode currencyCodeFrom, CurrencyCode currencyCodeTo, List<Rate> rates, decimal parentRate = 1m)
        {
            /*try
            {*/
                if (currencyCodeFrom == currencyCodeTo) return parentRate;

                /*if (rates.Exists(r => r.OriginCurrency == currencyCodeFrom && r.DestinationCurrency == currencyCodeTo && r.Date <= date))
                {
                    return parentRate * rates.FirstOrDefault(r => r.OriginCurrency == currencyCodeFrom && r.DestinationCurrency == currencyCodeTo && r.Date <= date).Value;
                }*/
                List<Rate> originRates = rates.Where(r => r.OriginCurrency == currencyCodeFrom && r.Date <= date).ToList();
                foreach (Rate rate in originRates)
                {
                    decimal currentRate = parentRate * GetRate(date, rate.DestinationCurrency, currencyCodeTo, rates, rate.Value);
                    if (currentRate > 0)
                    {
                        return currentRate;
                    }
                }
                return 0m;
            /*}
            catch
            {
                ErrorMessage("GetRate", "Could not find converison rate.");
                return 0m;
            }*/
        }

        private decimal GetTaxBaseRate(CurrencyCode currencyCode, List<Currency> taxBaseAmounts, List<Currency> taxBaseRates)
        {
            /*try
            {*/
                // Shouldn't happen
                //if (!taxBaseRates.Exists(tbr => tbr.CurrencyCode == currencyCode)) taxBaseRates.Add(new Currency() { CurrencyCode = currencyCode });
            Currency taxBaseRate = taxBaseRates.FirstOrDefault(tbr => tbr.CurrencyCode == currencyCode);
            if (taxBaseRate != null)
            {
                return taxBaseRate.Value;
            }
            return 0;

            /*}
            catch
            {
                ErrorMessage("GetTaxBaseRate");
                return 0m;
            }*/
        }

        private void AddDetailedTransaction(DateTime date, Currency bought, Currency sold, Currency rate, Currency fee, SubType subType, ref List<Currency> taxBaseAmounts, ref List<Currency> taxBaseRates, List<Rate> rates)
        {
            DetailedTransaction detailedTransaction = new DetailedTransaction()
            {
                DateTime = date,
                CurrencyCodeTaxation = _taxCurrencyCode,
                CurrencyCodeSold = sold.CurrencyCode,
                AmountSold = sold.Value,
                CurrencyCodeBought = bought.CurrencyCode,
                AmountBought = bought.Value,
                CurrencyCodeFee = fee.CurrencyCode,
                AmountFee = fee.Value
            };

            decimal totalSalesPrice = 0m,
                    taxBasis = 0m,
                    gain = 0m,
                    loss = 0m,
                    taxBasisRateSold = 0m,
                    taxBasisAmountAfterSold = 0m,
                    taxBasisAmountBeforeSold = 0m,
                    taxBasisRateAfterBought = 0m,
                    taxBasisRateBeforeBought = 0m,
                    taxBasisAmountAfterBought = 0m,
                    taxBasisAmountBeforeBought = 0m,
                    valueTaxationCurrencyFee = 0m;

            if (fee.CurrencyCode != CurrencyCode.Undefined)
            {
                valueTaxationCurrencyFee = fee.Value * GetRate(date, fee.CurrencyCode, _taxCurrencyCode, rates);
            }

            // Total sales price
            if (sold.CurrencyCode < bought.CurrencyCode)
            {
                totalSalesPrice = sold.Value * GetRate(date, sold.CurrencyCode, _taxCurrencyCode, rates) - valueTaxationCurrencyFee;
            }
            if (totalSalesPrice == 0)
            {
                totalSalesPrice = bought.Value * GetRate(date, bought.CurrencyCode, _taxCurrencyCode, rates) - valueTaxationCurrencyFee;
            }
            if (totalSalesPrice == 0)
            {
                throw new Exception("Total sales price should not be 0.");
            }

            // Tax basis
            taxBasis = sold.Value * GetTaxBaseRate(sold.CurrencyCode, taxBaseAmounts, taxBaseRates);

            // Gain or loss
            if (totalSalesPrice > taxBasis && sold.CurrencyCode != CurrencyCode.SEK) gain = totalSalesPrice - taxBasis;
            else if (totalSalesPrice < taxBasis && sold.CurrencyCode != CurrencyCode.SEK) loss = taxBasis - totalSalesPrice;


            if (!taxBaseAmounts.Exists(tba => tba.CurrencyCode == bought.CurrencyCode)) taxBaseAmounts.Add(new Currency() { CurrencyCode = bought.CurrencyCode });
            if (!taxBaseRates.Exists(tbr => tbr.CurrencyCode == bought.CurrencyCode)) taxBaseRates.Add(new Currency() { CurrencyCode = bought.CurrencyCode });
            if (!taxBaseAmounts.Exists(tba => tba.CurrencyCode == sold.CurrencyCode)) taxBaseAmounts.Add(new Currency() { CurrencyCode = sold.CurrencyCode });
            if (!taxBaseRates.Exists(tbr => tbr.CurrencyCode == sold.CurrencyCode)) taxBaseRates.Add(new Currency() { CurrencyCode = sold.CurrencyCode });

            Currency taxBaseAmountBought = taxBaseAmounts.FirstOrDefault(tba => tba.CurrencyCode == bought.CurrencyCode);
            Currency taxBaseRateBought = taxBaseRates.FirstOrDefault(tbr => tbr.CurrencyCode == bought.CurrencyCode);
            Currency taxBaseAmountSold = taxBaseAmounts.FirstOrDefault(tba => tba.CurrencyCode == sold.CurrencyCode);

            if (sold.CurrencyCode != _taxCurrencyCode)
            {
                taxBasisAmountBeforeSold = taxBaseAmountSold.Value;
                taxBasisAmountAfterSold = taxBasisAmountBeforeSold - sold.Value;
            }

            if (bought.CurrencyCode != _taxCurrencyCode)
            {
                decimal taxBasePriceBought = taxBaseAmountBought.Value * taxBaseRateBought.Value;

                // Quick fix before rate exploration is properly implemented.
                decimal boughtPrice = 0m;
                
                if (sold.CurrencyCode < bought.CurrencyCode)
                {
                    boughtPrice = sold.Value * GetRate(date, sold.CurrencyCode, _taxCurrencyCode, rates) + valueTaxationCurrencyFee;
                }
                if (boughtPrice == 0)
                {
                    boughtPrice = bought.Value * GetRate(date, bought.CurrencyCode, _taxCurrencyCode, rates) + valueTaxationCurrencyFee;
                }
                if (boughtPrice == 0)
                {
                    throw new Exception("Bought price should not be 0.");
                }

                taxBasisRateBeforeBought = taxBaseRateBought.Value;
                // (10 USD * 10 + 5 USD * 20) / (10 + 5) = 200 / 15 = 13,333...   (Old amount * Old rate + New value * Rate at that time) / Sum amount = New rate
                taxBasisRateAfterBought = (taxBasePriceBought + boughtPrice) / (taxBaseAmountBought.Value + bought.Value);
                taxBasisAmountBeforeBought = taxBaseAmountBought.Value;
                taxBasisAmountAfterBought = taxBasisAmountBeforeBought + bought.Value;
            }

            detailedTransaction.ValueTaxationCurrencySold = totalSalesPrice;
            detailedTransaction.TaxBasisValueSold = taxBasis;
            detailedTransaction.Gain = gain;
            detailedTransaction.Loss = loss;
            detailedTransaction.TaxBasisRateSold = taxBasisRateSold;
            detailedTransaction.TaxBasisAmountAfterSold = taxBasisAmountAfterSold;
            detailedTransaction.TaxBasisAmountBeforeSold = taxBasisAmountBeforeSold;
            detailedTransaction.TaxBasisRateAfterBought = taxBasisRateAfterBought;
            detailedTransaction.TaxBasisRateBeforeBought = taxBasisRateBeforeBought;
            detailedTransaction.TaxBasisAmountAfterBought = taxBasisAmountAfterBought;
            detailedTransaction.TaxBasisAmountBeforeBought = taxBasisAmountBeforeBought;
            detailedTransaction.ValueTaxationCurrencyFee = valueTaxationCurrencyFee;

            DetailedTransactions.Add(detailedTransaction);
        }

        private void AddK4Transaction(int year, Currency currency, int totalSalesPrice, int taxBasis, int gain, int loss)
        {
            if (!K4FiatCurrencyTransactions.ContainsKey(year) || !K4CryptoCurrencyTransactions.ContainsKey(year))
            {
                K4FiatCurrencyTransactions.Add(year, new List<K4TransactionModel>());
                K4CryptoCurrencyTransactions.Add(year, new List<K4TransactionModel>());
            }
            if (currency.Type == CurrencyType.FiatCurrency)
            {
                K4FiatCurrencyTransactions[year].Add(new K4TransactionModel()
                {
                    Amount = currency.Value,
                    Currency = currency.CurrencyCode.ToString(),
                    SalesPrice = totalSalesPrice,
                    TaxBasis = taxBasis,
                    Gain = gain,
                    Loss = loss
                });
            }
            else if (currency.Type == CurrencyType.CryptoCurrency)
            {
                K4CryptoCurrencyTransactions[year].Add(new K4TransactionModel()
                {
                    Amount = currency.Value,
                    Currency = currency.CurrencyCode.ToString(),
                    SalesPrice = totalSalesPrice,
                    TaxBasis = taxBasis,
                    Gain = gain,
                    Loss = loss
                });
            }
        }

        private void ErrorMessage(string functionName, string errorMessage = "") //TODO! Refactor into application wide error handling.
        {
            Debug.Print("Line " + _lineNumber + ". " + errorMessage + " " + functionName);
        }
    }
}
