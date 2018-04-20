using Cryptaxation.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation.Helpers
{
    public class TransactionHelper
    {
		public List<K4Transaction> K4FiatCurrencyTransactions = new List<K4Transaction>();
		public List<K4Transaction> K4CryptoCurrencyTransactions = new List<K4Transaction>();
        public List<DetailedTransaction> DetailedTransactions = new List<DetailedTransaction>();
        private int _lineNumber;
        private CurrencyCode _taxCurrencyCode;

        public void UpdateK4TransactionListsFromBitstampTransactions(List<BitstampTransaction> bitstampTransactions, List<Rate> rates, int year)
		{
            try
            {
                List<Currency> taxBaseAmounts = new List<Currency>();
                List<Currency> taxBaseRates = new List<Currency>();
                _lineNumber = 0;
                _taxCurrencyCode = CurrencyCode.SEK;

                rates = rates.OrderBy(r => r.DestinationCurrency).ThenBy(r => r.OriginCurrency).ThenByDescending(r => r.Date).ToList();

                foreach (BitstampTransaction bitstampTransaction in bitstampTransactions)
                {
                    _lineNumber++;
                    if (bitstampTransaction.Type == BitstampTransactionType.Market)
                    {
                        DateTime date = bitstampTransaction.DateTime.Date;
                        if (bitstampTransaction.SubType == SubType.Buy)
                        {
                            if (bitstampTransaction.DateTime.Year == year && bitstampTransaction.Value.CurrencyCode != _taxCurrencyCode) HandleTransaction(date, bitstampTransaction.Amount, bitstampTransaction.Value, bitstampTransaction.Fee, bitstampTransaction.SubType, rates, taxBaseAmounts, taxBaseRates);
                            AddDetailedTransaction(date, bitstampTransaction.Amount, bitstampTransaction.Value, bitstampTransaction.Rate, bitstampTransaction.Fee, bitstampTransaction.SubType, ref taxBaseAmounts, ref taxBaseRates, rates);
                            UpdateTaxBases(date, bitstampTransaction.Amount, bitstampTransaction.Value, bitstampTransaction.Rate, bitstampTransaction.Fee, bitstampTransaction.SubType, ref taxBaseAmounts, ref taxBaseRates, rates);
                        }
                        else if (bitstampTransaction.SubType == SubType.Sell)
                        {
                            if (bitstampTransaction.DateTime.Year == year && bitstampTransaction.Amount.CurrencyCode != _taxCurrencyCode) HandleTransaction(date, bitstampTransaction.Value, bitstampTransaction.Amount, bitstampTransaction.Fee, bitstampTransaction.SubType, rates, taxBaseAmounts, taxBaseRates);
                            AddDetailedTransaction(date, bitstampTransaction.Value, bitstampTransaction.Amount, bitstampTransaction.Rate, bitstampTransaction.Fee, bitstampTransaction.SubType, ref taxBaseAmounts, ref taxBaseRates, rates);
                            UpdateTaxBases(date, bitstampTransaction.Value, bitstampTransaction.Amount, bitstampTransaction.Rate, bitstampTransaction.Fee, bitstampTransaction.SubType, ref taxBaseAmounts, ref taxBaseRates, rates);
                        }
                    }
                }
            }
            catch
            {
                ErrorMessage("UpdateK4TransactionListsFromBitstampTransactions");
            }
        }

        private void HandleTransaction(DateTime date, Currency bought, Currency sold, Currency fee, SubType subType, List<Rate> rates, List<Currency> taxBaseAmounts, List<Currency> taxBaseRates)
        {
            try
            {
                decimal totalSalesPrice = 0, taxBasis = 0, gain = 0, loss = 0;

                // Total sales price
                if (sold.Type == CurrencyType.FiatCurrency) totalSalesPrice = sold.Value * GetRate(date, sold.CurrencyCode, _taxCurrencyCode, rates);
                else if (sold.Type == CurrencyType.CryptoCurrency) totalSalesPrice = bought.Value * GetRate(date, bought.CurrencyCode, _taxCurrencyCode, rates);
                else ErrorMessage("HandleTransaction", "Sold currency is neither fiat nor crypto.");

                // Tax basis
                taxBasis = sold.Value * GetTaxBaseRate(sold.CurrencyCode, taxBaseAmounts, taxBaseRates);

                // Gain or loss
                if (totalSalesPrice > taxBasis) gain = totalSalesPrice - taxBasis;
                else if (totalSalesPrice < taxBasis) loss = taxBasis - totalSalesPrice;

                // Add transaction
                AddK4Transaction(sold, totalSalesPrice, taxBasis, gain, loss);
            }
            catch
            {
                ErrorMessage("HandleTransaction");
            }
        }

        private void UpdateTaxBases(DateTime date, Currency bought, Currency sold, Currency rate, Currency fee, SubType subType, ref List<Currency> taxBaseAmounts, ref List<Currency> taxBaseRates, List<Rate> rates)
        {
            try
            {
                if (!taxBaseAmounts.Exists(tba => tba.CurrencyCode == bought.CurrencyCode)) taxBaseAmounts.Add(new Currency() { CurrencyCode = bought.CurrencyCode });
                if (!taxBaseRates.Exists(tbr => tbr.CurrencyCode == bought.CurrencyCode)) taxBaseRates.Add(new Currency() { CurrencyCode = bought.CurrencyCode });
                if (!taxBaseAmounts.Exists(tba => tba.CurrencyCode == sold.CurrencyCode)) taxBaseAmounts.Add(new Currency() { CurrencyCode = sold.CurrencyCode });
                if (!taxBaseRates.Exists(tbr => tbr.CurrencyCode == sold.CurrencyCode)) taxBaseRates.Add(new Currency() { CurrencyCode = sold.CurrencyCode });

                Currency taxBaseAmountBought = taxBaseAmounts.FirstOrDefault(tba => tba.CurrencyCode == bought.CurrencyCode);
                Currency taxBaseRateBought = taxBaseRates.FirstOrDefault(tbr => tbr.CurrencyCode == bought.CurrencyCode);
                Currency taxBaseAmountSold = taxBaseAmounts.FirstOrDefault(tba => tba.CurrencyCode == sold.CurrencyCode);
                Currency taxBaseRateSold = taxBaseRates.FirstOrDefault(tbr => tbr.CurrencyCode == sold.CurrencyCode);

                // TODO! Break out to its own function: UpdateTaxBasis()
                if (bought.CurrencyCode != _taxCurrencyCode)
                {
                    decimal taxBasePriceBought = taxBaseAmountBought.Value * taxBaseRateBought.Value;

                    // Quick fix before rate exploration is properly implemented.
                    decimal boughtPrice = 0;
                    if (bought.Type == CurrencyType.FiatCurrency) boughtPrice = bought.Value * GetRate(date, bought.CurrencyCode, _taxCurrencyCode, rates) + fee.Value * GetRate(date, fee.CurrencyCode, _taxCurrencyCode, rates);
                    else if (bought.Type == CurrencyType.CryptoCurrency) boughtPrice = bought.Value * GetRate(date, sold.CurrencyCode, _taxCurrencyCode, rates, rate.Value) + fee.Value * GetRate(date, fee.CurrencyCode, _taxCurrencyCode, rates);
                    else ErrorMessage("UpdateTaxBases", "CurrencyType for bought undefined.");

                    decimal boughtAmount;
                    if (bought.CurrencyCode == fee.CurrencyCode) boughtAmount = bought.Value + fee.Value;
                    else boughtAmount = bought.Value + fee.Value / rate.Value;
                    // (10 USD * 10 + 5 USD * 20) / (10 + 5) = 200 / 15 = 13,333...   (Old amount * Old rate + New value * Rate at that time) / Sum amount = New rate
                    taxBaseRateBought.Value = (taxBasePriceBought + boughtPrice) / (taxBaseAmountBought.Value + boughtAmount);
                    taxBaseAmountBought.Value += bought.Value;
                }

                if (sold.CurrencyCode != _taxCurrencyCode) taxBaseAmountSold.Value -= sold.Value;
            }
            catch
            {
                ErrorMessage("UpdateTaxBases");
            }
        }

        private decimal GetRate(DateTime date, CurrencyCode currencyCodeFrom, CurrencyCode currencyCodeTo, List<Rate> rates, decimal parentRate = 1)
        {
            try
            {
                if (currencyCodeFrom == currencyCodeTo) return 1;

                // TODO! SEK can be set to tax currency, as per settings.
                if (rates.Exists(r => r.OriginCurrency == currencyCodeFrom && r.DestinationCurrency == currencyCodeTo && r.Date <= date))
                {
                    return parentRate * rates.FirstOrDefault(r => r.OriginCurrency == currencyCodeFrom && r.DestinationCurrency == currencyCodeTo && r.Date <= date).Value;
                }
                foreach (Rate rate in rates.Where(r => r.OriginCurrency == currencyCodeFrom && r.Date <= date).ToList().OrderBy(r => r.DestinationCurrency).ThenBy(r => r.OriginCurrency).ThenByDescending(r => r.Date))
                {
                    return parentRate * GetRate(date, rate.DestinationCurrency, currencyCodeTo, rates, rate.Value);
                }
                ErrorMessage("GetRate", "Could not find converison rate.");
                return 0;
            }
            catch
            {
                ErrorMessage("GetRate");
                return 0;
            }
        }

        private decimal GetTaxBasis(CurrencyCode currencyCode, List<Currency> taxBaseAmounts, List<Currency> taxBaseRates)
        {
            try
            {
                return GetTaxBaseAmount(currencyCode, taxBaseAmounts, taxBaseRates) * GetTaxBaseRate(currencyCode, taxBaseAmounts, taxBaseRates);
            }
            catch
            {
                ErrorMessage("GetTaxBasis");
                return 0;
            }
        }

        private decimal GetTaxBaseAmount(CurrencyCode currencyCode, List<Currency> taxBaseAmounts, List<Currency> taxBaseRates)
        {
            try
            {
                if (!taxBaseAmounts.Exists(tba => tba.CurrencyCode == currencyCode)) taxBaseAmounts.Add(new Currency() { CurrencyCode = currencyCode });
                return taxBaseAmounts.FirstOrDefault(tba => tba.CurrencyCode == currencyCode).Value;
            }
            catch
            {
                ErrorMessage("GetTaxBaseAmount");
                return 0;
            }
        }

        private decimal GetTaxBaseRate(CurrencyCode currencyCode, List<Currency> taxBaseAmounts, List<Currency> taxBaseRates)
        {
            try
            {
                if (!taxBaseRates.Exists(tbr => tbr.CurrencyCode == currencyCode)) taxBaseRates.Add(new Currency() { CurrencyCode = currencyCode });
                return taxBaseRates.FirstOrDefault(tbr => tbr.CurrencyCode == currencyCode).Value;
            }
            catch
            {
                ErrorMessage("GetTaxBaseRate");
                return 0;
            }
        }

        private void AddDetailedTransaction(DateTime date, Currency bought, Currency sold, Currency rate, Currency fee, SubType subType, ref List<Currency> taxBaseAmounts, ref List<Currency> taxBaseRates, List<Rate> rates)
        {
            DetailedTransaction detailedTransaction = new DetailedTransaction() {
                DateTime = date,
                CurrencyCodeTaxation = _taxCurrencyCode,
                CurrencyCodeSold = sold.CurrencyCode,
                AmountSold = sold.Value,
                CurrencyCodeBought = bought.CurrencyCode,
                AmountBought = bought.Value,
                CurrencyCodeFee = fee.CurrencyCode,
                AmountFee = fee.Value
            };

            decimal totalSalesPrice = 0,
                    taxBasis = 0,
                    gain = 0,
                    loss = 0,
                    taxBasisRateSold = 0,
                    taxBasisAmountAfterSold = 0,
                    taxBasisAmountBeforeSold = 0,
                    taxBasisRateAfterBought = 0,
                    taxBasisRateBeforeBought = 0,
                    taxBasisAmountAfterBought = 0,
                    taxBasisAmountBeforeBought = 0,
                    valueTaxationCurrencyFee = 0;

            // Total sales price
            if (sold.Type == CurrencyType.FiatCurrency) totalSalesPrice = sold.Value * GetRate(date, sold.CurrencyCode, _taxCurrencyCode, rates);
            else if (sold.Type == CurrencyType.CryptoCurrency) totalSalesPrice = bought.Value * GetRate(date, bought.CurrencyCode, _taxCurrencyCode, rates);
            else ErrorMessage("AddDetailedTransaction", "Sold currency is neither fiat nor crypto.");

            // Tax basis
            taxBasis = sold.Value * GetTaxBaseRate(sold.CurrencyCode, taxBaseAmounts, taxBaseRates);

            // Gain or loss
            if (totalSalesPrice > taxBasis) gain = totalSalesPrice - taxBasis;
            else if (totalSalesPrice < taxBasis) loss = taxBasis - totalSalesPrice;


            if (!taxBaseAmounts.Exists(tba => tba.CurrencyCode == bought.CurrencyCode)) taxBaseAmounts.Add(new Currency() { CurrencyCode = bought.CurrencyCode });
            if (!taxBaseRates.Exists(tbr => tbr.CurrencyCode == bought.CurrencyCode)) taxBaseRates.Add(new Currency() { CurrencyCode = bought.CurrencyCode });
            if (!taxBaseAmounts.Exists(tba => tba.CurrencyCode == sold.CurrencyCode)) taxBaseAmounts.Add(new Currency() { CurrencyCode = sold.CurrencyCode });
            if (!taxBaseRates.Exists(tbr => tbr.CurrencyCode == sold.CurrencyCode)) taxBaseRates.Add(new Currency() { CurrencyCode = sold.CurrencyCode });

            Currency taxBaseAmountBought = taxBaseAmounts.FirstOrDefault(tba => tba.CurrencyCode == bought.CurrencyCode);
            Currency taxBaseRateBought = taxBaseRates.FirstOrDefault(tbr => tbr.CurrencyCode == bought.CurrencyCode);
            Currency taxBaseAmountSold = taxBaseAmounts.FirstOrDefault(tba => tba.CurrencyCode == sold.CurrencyCode);
            Currency taxBaseRateSold = taxBaseRates.FirstOrDefault(tbr => tbr.CurrencyCode == sold.CurrencyCode);

            if (sold.CurrencyCode != _taxCurrencyCode)
            {
                taxBasisAmountBeforeSold = taxBaseAmountSold.Value;
                taxBasisAmountAfterSold = taxBasisAmountBeforeSold - sold.Value;
            }

            if (bought.CurrencyCode != _taxCurrencyCode)
            {
                decimal taxBasePriceBought = taxBaseAmountBought.Value * taxBaseRateBought.Value;

                // Quick fix before rate exploration is properly implemented.
                decimal boughtPrice = 0;
                valueTaxationCurrencyFee = fee.Value * GetRate(date, fee.CurrencyCode, _taxCurrencyCode, rates);
                if (bought.Type == CurrencyType.FiatCurrency)           boughtPrice = bought.Value * GetRate(date, bought.CurrencyCode, _taxCurrencyCode, rates) + valueTaxationCurrencyFee;
                else if (bought.Type == CurrencyType.CryptoCurrency)    boughtPrice = bought.Value * GetRate(date, sold.CurrencyCode, _taxCurrencyCode, rates, rate.Value) + valueTaxationCurrencyFee;
                else ErrorMessage("AddDetailedTransaction", "CurrencyType for bought undefined.");

                decimal boughtAmount;
                if (bought.CurrencyCode == fee.CurrencyCode) boughtAmount = bought.Value + fee.Value;
                else boughtAmount = bought.Value + fee.Value / rate.Value;
                taxBasisRateBeforeBought = taxBaseRateBought.Value;
                // (10 USD * 10 + 5 USD * 20) / (10 + 5) = 200 / 15 = 13,333...   (Old amount * Old rate + New value * Rate at that time) / Sum amount = New rate
                taxBasisRateAfterBought = (taxBasePriceBought + boughtPrice) / (taxBaseAmountBought.Value + boughtAmount);
                taxBasisAmountBeforeBought = taxBaseAmountBought.Value;
                taxBasisAmountAfterBought = taxBasisAmountBeforeBought + bought.Value;
            }

            detailedTransaction.ValueTaxationCurrencySold = totalSalesPrice;
            detailedTransaction.TaxBasisValueSold = taxBasis;
            detailedTransaction.Gain = gain;
            detailedTransaction.Loss = loss;
            detailedTransaction.TaxBasisRateSold = taxBasisRateSold;
            detailedTransaction.TaxBasisAmountAfterSold =  taxBasisAmountAfterSold;
            detailedTransaction.TaxBasisAmountBeforeSold = taxBasisAmountBeforeSold;
            detailedTransaction.TaxBasisRateAfterBought = taxBasisRateAfterBought;
            detailedTransaction.TaxBasisRateBeforeBought = taxBasisRateBeforeBought;
            detailedTransaction.TaxBasisAmountAfterBought = taxBasisAmountAfterBought;
            detailedTransaction.TaxBasisAmountBeforeBought = taxBasisAmountBeforeBought;
            detailedTransaction.ValueTaxationCurrencyFee = valueTaxationCurrencyFee;

            DetailedTransactions.Add(detailedTransaction);
        }

        private void AddK4Transaction(Currency currency, decimal totalSalesPrice, decimal taxBasis, decimal gain, decimal loss)
        {
            try
            {
                if (currency.Type == CurrencyType.FiatCurrency)
                {
                    K4FiatCurrencyTransactions.Add(new K4Transaction()
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
                    K4CryptoCurrencyTransactions.Add(new K4Transaction()
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
            catch
            {
                ErrorMessage("AddK4Transaction");
            }
        }

        private void ErrorMessage(string functionName, string errorMessage = "") //TODO! Refactor into application wide error handling.
        {
            Debug.Print("Line " + _lineNumber + ". " + errorMessage + " " + functionName);
        }
    }
}
