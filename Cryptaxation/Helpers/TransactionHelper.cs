using Cryptaxation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation.Helpers
{
    public class TransactionHelper
    {
		public List<K4Transaction> K4FiatCurrencyTransactions;

		public List<K4Transaction> K4CryptoCurrencyTransactions;

		public void UpdateK4TransactionListsFromBitstampTransactions(List<BitstampTransaction> bitstampTransactions, List<Rate> rates)
		{
			List<Currency> taxBaseAmounts = new List<Currency>();
            List<Currency> taxBaseRates = new List<Currency>();
            
            rates.OrderBy(r => r.DestinationCurrency).ThenBy(r => r.OriginCurrency).ThenByDescending(r => r.Date);

            foreach (BitstampTransaction bitstampTransaction in bitstampTransactions)
			{
				if (bitstampTransaction.Type == BitstampTransactionType.Market)
				{  
                    DateTime date = bitstampTransaction.DateTime.Date;
                    if (bitstampTransaction.SubType == SubType.Buy)
                    {
                        HandleTransaction(date, bitstampTransaction.Amount, bitstampTransaction.Value, bitstampTransaction.Fee, bitstampTransaction.SubType, rates, taxBaseAmounts, taxBaseRates);
                        UpdateCostBases(date, bitstampTransaction.Amount, bitstampTransaction.Value, bitstampTransaction.Fee, ref taxBaseAmounts, ref taxBaseRates, rates);
                    }
                    else if (bitstampTransaction.SubType == SubType.Sell)
                    {
                        HandleTransaction(date, bitstampTransaction.Value, bitstampTransaction.Amount, bitstampTransaction.Fee, bitstampTransaction.SubType, rates, taxBaseAmounts, taxBaseRates);
                        UpdateCostBases(date, bitstampTransaction.Amount, bitstampTransaction.Value, bitstampTransaction.Fee, ref taxBaseAmounts, ref taxBaseRates, rates);
                    }
                }
			}
		}

        private void HandleTransaction(DateTime date, Currency bought, Currency sold, Currency fee, SubType subType, List<Rate> rates, List<Currency> taxBaseAmounts, List<Currency> taxBaseRates)
        {
            Decimal totalSalesPrice = 0, taxBasis = 0, gain = 0, loss = 0;

            // Total sales price
            if (sold.Type == CurrencyType.FiatCurrency)         totalSalesPrice = sold.Value * GetRate(date, sold.CurrencyCode, rates);
            else if (sold.Type == CurrencyType.CryptoCurrency)  totalSalesPrice = bought.Value * GetRate(date, bought.CurrencyCode, rates);

            // Tax basis
            taxBasis = GetTaxBasis(sold.CurrencyCode, taxBaseAmounts, taxBaseRates);

            // Gain or loss
            if (totalSalesPrice > taxBasis)         gain = totalSalesPrice - taxBasis;
            else if (totalSalesPrice < taxBasis)    loss = taxBasis - totalSalesPrice;

            // Add transaction
            AddK4Transaction(sold, totalSalesPrice, taxBasis, gain, loss);
        }

        private void UpdateCostBases(DateTime date, Currency bought, Currency sold, Currency fee, ref List<Currency> taxBaseAmounts, ref List<Currency> taxBaseRates, List<Rate> rates)
        {
            if (!taxBaseAmounts.Exists(tba => tba.CurrencyCode == bought.CurrencyCode)) taxBaseAmounts.Add(new Currency() { CurrencyCode = bought.CurrencyCode });
            if (!taxBaseRates.Exists(tbr => tbr.CurrencyCode == bought.CurrencyCode)) taxBaseRates.Add(new Currency() { CurrencyCode = bought.CurrencyCode });
            if (!taxBaseAmounts.Exists(tba => tba.CurrencyCode == sold.CurrencyCode)) taxBaseAmounts.Add(new Currency() { CurrencyCode = sold.CurrencyCode });
            if (!taxBaseRates.Exists(tbr => tbr.CurrencyCode == sold.CurrencyCode)) taxBaseRates.Add(new Currency() { CurrencyCode = sold.CurrencyCode });
            
            Currency taxBaseAmountBought = taxBaseAmounts.FirstOrDefault(tba => tba.CurrencyCode == bought.CurrencyCode);
            Currency taxBaseRateBought = taxBaseRates.FirstOrDefault(tbr => tbr.CurrencyCode == bought.CurrencyCode);
            Currency taxBaseAmountSold = taxBaseAmounts.FirstOrDefault(tba => tba.CurrencyCode == sold.CurrencyCode);
            Currency taxBaseRateSold = taxBaseRates.FirstOrDefault(tbr => tbr.CurrencyCode == sold.CurrencyCode);
            
            // (10 USD * 10 + 5 USD * 20) / (10 + 5) = 200 / 15 = 13,333...   (Old amount * Old rate + New value * Rate at that time) / Sum amount = New rate
            taxBaseRateBought.Value =   (taxBaseAmountBought.Value * taxBaseRateBought.Value
                                        + (bought.Value + fee.Value) * GetRate(date, bought.CurrencyCode, rates))
                                        / (taxBaseAmountBought.Value + bought.Value + fee.Value);

            taxBaseAmountBought.Value += bought.Value + fee.Value;
            
            taxBaseRateSold.Value =     (taxBaseAmountSold.Value * taxBaseRateSold.Value
                                        + sold.Value * GetRate(date, sold.CurrencyCode, rates))
                                        / (taxBaseAmountSold.Value + sold.Value);

            taxBaseAmountSold.Value -= sold.Value;
        }

        private Decimal GetRate(DateTime date, CurrencyCode currencyCode, List<Rate> rates, Decimal parentRate = 1)
        {
            // TODO! SEK can be set to tax currency, as per settings.
            if (rates.Exists(r => r.OriginCurrency == currencyCode && r.DestinationCurrency == CurrencyCode.SEK))
            {
                return parentRate * rates.FirstOrDefault(r => r.OriginCurrency == currencyCode && r.DestinationCurrency == CurrencyCode.SEK).Value;
            }
            foreach(Rate rate in rates.Where(r => r.OriginCurrency == currencyCode && r.Date <= date).ToList().OrderBy(r => r.DestinationCurrency).ThenBy(r => r.OriginCurrency).ThenByDescending(r => r.Date))
            {
                return parentRate * GetRate(date, rate.DestinationCurrency, rates, rate.Value);
            }
            return 0;
        }

        private Decimal GetTaxBasis(CurrencyCode currencyCode, List<Currency> taxBaseAmounts, List<Currency> taxBaseRates)
        {
            return taxBaseAmounts.FirstOrDefault(tba => tba.CurrencyCode == currencyCode).Value * taxBaseRates.FirstOrDefault(tbr => tbr.CurrencyCode == currencyCode).Value;
        }

        private void AddK4Transaction(Currency currency, Decimal totalSalesPrice, Decimal taxBasis, Decimal gain, Decimal loss)
        {
            if (currency.Type == CurrencyType.FiatCurrency)
            {
                K4FiatCurrencyTransactions.Add(new K4Transaction()
                {
                    Amount = currency.Value.ToString(),
                    Currency = currency.CurrencyCode.ToString(),
                    SalesPrice = totalSalesPrice.ToString(),
                    TaxBasis = taxBasis.ToString(),
                    Gain = gain.ToString(),
                    Loss = loss.ToString()
                });
            }
            else if (currency.Type == CurrencyType.CryptoCurrency)
            {
                K4CryptoCurrencyTransactions.Add(new K4Transaction()
                {
                    Amount = currency.Value.ToString(),
                    Currency = currency.CurrencyCode.ToString(),
                    SalesPrice = totalSalesPrice.ToString(),
                    TaxBasis = taxBasis.ToString(),
                    Gain = gain.ToString(),
                    Loss = loss.ToString()
                });
            }
        }
    }
}
