using System;
using System.Collections.Generic;
using System.Linq;
using Cryptaxation.Entities;
using Cryptaxation.Entities.Types;
using Cryptaxation.Entities.Types.Enums;
using Cryptaxation.Parse.Contract;

namespace Cryptaxation.Parse.Logic
{
    public class TransactionLogic<TTransaction, TDetailedTransaction> : ITransactionLogic<TTransaction> where TTransaction : Transaction where TDetailedTransaction : DetailedTransaction, new()
    {
        private readonly CurrencyCode _taxCurrencyCode;
        private readonly List<Rate> _rates;
        private readonly List<Currency> _taxBaseAmounts;
        private readonly List<Currency> _taxBaseRates;

        public List<TDetailedTransaction> DetailedTransactions = new List<TDetailedTransaction>();

        public TransactionLogic(CurrencyCode taxCurrencyCode, List<Rate> rates)
        {
            _taxCurrencyCode = taxCurrencyCode;
            _rates = rates;
            _taxBaseAmounts = new List<Currency>();
            _taxBaseRates = new List<Currency>();
        }

        public void ParseTransactions(List<TTransaction> transactions)
        {
            foreach (var transaction in transactions)
            {
                if (transaction.Type == TransactionType.Market)
                {
                    if (transaction.Action == TradeAction.Buy)
                    {
                        AddDetailedTransaction(transaction);
                        UpdateTaxBases(transaction);
                    }
                    else if (transaction.Action == TradeAction.Sell)
                    {
                        AddDetailedTransaction(transaction);
                        UpdateTaxBases(transaction);
                    }
                }
            }
        }

        private void AddDetailedTransaction(TTransaction transaction)
        {
            DateTime dateTime = transaction.DateTime.Date;
            Currency bought = transaction.Action == TradeAction.Buy ? transaction.Amount : transaction.Value;
            Currency sold = transaction.Action == TradeAction.Buy ? transaction.Value : transaction.Amount;
            Currency fee = transaction.Fee;
            Currency taxBaseAmountBought = GetTaxBaseAmount(bought.CurrencyCode);
            Currency taxBaseRateBought = GetTaxBaseRate(bought.CurrencyCode);
            Currency taxBaseAmountSold = GetTaxBaseAmount(sold.CurrencyCode);

            decimal totalSalesPrice = GetSalesPrice(dateTime, bought, sold, fee);
            decimal valueTaxationCurrencyFee = GetValueTaxationCurrencyFee(dateTime, fee);
            decimal taxBasis = sold.Value * GetTaxBaseRate(sold.CurrencyCode).Value;
            decimal gain = GetGain(sold, totalSalesPrice, taxBasis);
            decimal loss = GetLoss(sold, totalSalesPrice, taxBasis);
            decimal taxBasisAmountBeforeSold = GetTaxBasisAmountBeforeSold(sold, taxBaseAmountSold);
            decimal taxBasisAmountAfterSold = GetTaxBasisAmountAfterSold(sold, taxBaseAmountSold);
            decimal taxBasisRateSold = 0m;
            decimal taxBasisRateBeforeBought = 0m, taxBasisRateAfterBought = 0m, taxBasisAmountBeforeBought = 0m, taxBasisAmountAfterBought = 0m;

            if (bought.CurrencyCode != _taxCurrencyCode)
            {
                decimal boughtPrice = GetBoughtPrice(dateTime, bought, sold, fee);
                taxBasisRateBeforeBought = GetTaxBasisRateBeforeBought(taxBaseRateBought);
                taxBasisRateAfterBought = GetTaxBasisRateAfterBought(bought, taxBaseAmountBought, taxBaseRateBought, boughtPrice);
                taxBasisAmountBeforeBought = GetTaxBasisAmountBeforeBought(taxBaseAmountBought);
                taxBasisAmountAfterBought = GetTaxBasisAmountAfterBought(bought, taxBaseAmountBought);
            }

            DetailedTransactions.Add(new TDetailedTransaction
            {
                DateTime = dateTime,
                CurrencyCodeTaxation = _taxCurrencyCode,
                CurrencyCodeSold = sold.CurrencyCode,
                AmountSold = sold.Value,
                CurrencyCodeBought = bought.CurrencyCode,
                AmountBought = bought.Value,
                CurrencyCodeFee = fee.CurrencyCode,
                AmountFee = fee.Value,
                ValueTaxationCurrencySold = totalSalesPrice,
                TaxBasisValueSold = taxBasis,
                Gain = gain,
                Loss = loss,
                TaxBasisRateSold = taxBasisRateSold,
                TaxBasisAmountAfterSold = taxBasisAmountAfterSold,
                TaxBasisAmountBeforeSold = taxBasisAmountBeforeSold,
                TaxBasisRateAfterBought = taxBasisRateAfterBought,
                TaxBasisRateBeforeBought = taxBasisRateBeforeBought,
                TaxBasisAmountAfterBought = taxBasisAmountAfterBought,
                TaxBasisAmountBeforeBought = taxBasisAmountBeforeBought,
                ValueTaxationCurrencyFee = valueTaxationCurrencyFee
            });
        }

        private void UpdateTaxBases(TTransaction transaction)
        {
            DateTime date = transaction.DateTime.Date;
            Currency bought = transaction.Action == TradeAction.Buy ? transaction.Amount : transaction.Value;
            Currency sold = transaction.Action == TradeAction.Buy ? transaction.Value : transaction.Amount;
            Currency fee = transaction.Fee;
            Currency taxBaseAmountBought = GetTaxBaseAmount(bought.CurrencyCode);
            Currency taxBaseRateBought = GetTaxBaseRate(bought.CurrencyCode);
            Currency taxBaseAmountSold = GetTaxBaseAmount(sold.CurrencyCode);
            
            if (bought.CurrencyCode != _taxCurrencyCode)
            {
                decimal taxBasePriceBought = taxBaseAmountBought.Value * taxBaseRateBought.Value;
                decimal boughtPrice = GetBoughtPrice(date, bought, sold, fee);

                // (10 USD * 10 + 5 USD * 20) / (10 + 5) = 200 / 15 = 13,333...   (Old amount * Old rate + New value * Rate at that time) / Sum amount = New rate
                taxBaseRateBought.Value = (taxBasePriceBought + boughtPrice) / (taxBaseAmountBought.Value + bought.Value);
                taxBaseAmountBought.Value += bought.Value;
            }

            if (sold.CurrencyCode != _taxCurrencyCode) taxBaseAmountSold.Value -= sold.Value;
        }

        private decimal GetValueTaxationCurrencyFee(DateTime date, Currency fee)
        {
            if (fee.CurrencyCode != CurrencyCode.Undefined) return fee.Value * GetRate(date, fee.CurrencyCode);
            return 0m;
        }

        private decimal GetBoughtPrice(DateTime date, Currency bought, Currency sold, Currency fee)
        {
            decimal valueTaxationCurrencyFee = GetValueTaxationCurrencyFee(date, fee);
            return GetPrice(date, bought, sold, valueTaxationCurrencyFee);
        }

        private decimal GetSalesPrice(DateTime date, Currency bought, Currency sold, Currency fee)
        {
            decimal valueTaxationCurrencyFee = GetValueTaxationCurrencyFee(date, fee);
            return GetPrice(date, bought, sold, -1 * valueTaxationCurrencyFee);
        }

        private decimal GetPrice(DateTime date, Currency bought, Currency sold, decimal valueTaxationCurrencyFee)
        {
            decimal price = 0m;
            if (sold.CurrencyCode <= bought.CurrencyCode)
            {
                price = sold.Value * GetRate(date, sold.CurrencyCode) + valueTaxationCurrencyFee;
            }
            else if (bought.CurrencyCode < sold.CurrencyCode)
            {
                price = bought.Value * GetRate(date, bought.CurrencyCode) + valueTaxationCurrencyFee;
            }
            return price;
        }

        private decimal GetGain(Currency sold, decimal totalSalesPrice, decimal taxBasis)
        {
            if (totalSalesPrice > taxBasis && sold.CurrencyCode != _taxCurrencyCode) return totalSalesPrice - taxBasis;
            return 0m;
        }

        private decimal GetLoss(Currency sold, decimal totalSalesPrice, decimal taxBasis)
        {
            if (totalSalesPrice < taxBasis && sold.CurrencyCode != _taxCurrencyCode) return taxBasis - totalSalesPrice;
            return 0m;
        }

        private decimal GetTaxBasisAmountBeforeSold(Currency sold, Currency taxBaseAmountSold)
        {
            if (sold.CurrencyCode != _taxCurrencyCode)
            {
                return taxBaseAmountSold.Value;
            }
            return 0m;
        }

        private decimal GetTaxBasisAmountAfterSold(Currency sold, Currency taxBaseAmountSold)
        {
            if (sold.CurrencyCode != _taxCurrencyCode)
            {
                return taxBaseAmountSold.Value - sold.Value;
            }
            return 0m;
        }

        private decimal GetTaxBasisRateBeforeBought(Currency taxBaseRateBought)
        {
            return taxBaseRateBought.Value;
        }

        private decimal GetTaxBasisRateAfterBought(Currency bought, Currency taxBaseAmountBought, Currency taxBaseRateBought, decimal boughtPrice)
        {
            decimal taxBasePriceBought = taxBaseAmountBought.Value * taxBaseRateBought.Value;
            // (10 USD * 10 + 5 USD * 20) / (10 + 5) = 200 / 15 = 13,333...   (Old amount * Old rate + New value * Rate at that time) / Sum amount = New rate
            return (taxBasePriceBought + boughtPrice) / (taxBaseAmountBought.Value + bought.Value);
        }

        private decimal GetTaxBasisAmountBeforeBought(Currency taxBaseAmountBought)
        {
            return taxBaseAmountBought.Value;
        }

        private decimal GetTaxBasisAmountAfterBought(Currency bought, Currency taxBaseAmountBought)
        {
            return taxBaseAmountBought.Value + bought.Value;
        }

        private Currency GetTaxBaseAmount(CurrencyCode currencyCode)
        {
            if (!_taxBaseAmounts.Exists(tba => tba.CurrencyCode == currencyCode)) _taxBaseAmounts.Add(new Currency { CurrencyCode = currencyCode });
            return _taxBaseAmounts.FirstOrDefault(tba => tba.CurrencyCode == currencyCode);
        }

        private Currency GetTaxBaseRate(CurrencyCode currencyCode)
        {
            if (!_taxBaseRates.Exists(tbr => tbr.CurrencyCode == currencyCode)) _taxBaseRates.Add(new Currency { CurrencyCode = currencyCode });
            return _taxBaseRates.FirstOrDefault(tbr => tbr.CurrencyCode == currencyCode);
        }

        private decimal GetRate(DateTime date, CurrencyCode currency, decimal parentRate = 1m)
        {
            if (currency == _taxCurrencyCode) return parentRate;
            List<Rate> originRates = _rates.Where(r => r.OriginCurrency == currency && r.Date <= date).ToList();
            return originRates.Select(rate => parentRate * GetRate(date, rate.DestinationCurrency, rate.Value)).FirstOrDefault(currentRate => currentRate > 0);
        }
    }
}
