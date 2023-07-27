using System;
using Cryptaxation.Entities.Types.Enums;

namespace Cryptaxation.Entities
{
    public class ReportCurrency
    {
        private CurrencyCode _currencyCode;
        public CurrencyCode CurrencyCode { get { return _currencyCode; } set { _currencyCode = value; } }

        public ReportCurrency(CurrencyCode currencyCode)
        {
            _currencyCode = currencyCode;
        }

        public CurrencyType CurrencyType
        {
            get
            {
                switch (CurrencyCode)
                {
                    case CurrencyCode.Undefined:
                        return CurrencyType.Undefined;
                    case CurrencyCode.BTC:
                        return CurrencyType.CryptoCurrency;
                    case CurrencyCode.ETH:
                        return CurrencyType.CryptoCurrency;
                    case CurrencyCode.LTC:
                        return CurrencyType.CryptoCurrency;
                    case CurrencyCode.XRP:
                        return CurrencyType.CryptoCurrency;
                    case CurrencyCode.BCH:
                        return CurrencyType.CryptoCurrency;
                    case CurrencyCode.USD:
                        return CurrencyType.FiatCurrency;
                    case CurrencyCode.EUR:
                        return CurrencyType.FiatCurrency;
                    case CurrencyCode.SEK:
                        return CurrencyType.FiatCurrency;
                    default: throw new NotImplementedException("Cannot determine currency type.");
                }
            }
        }
        public decimal OpeningTaxBaseRate { get; set; }
        public decimal ClosingTaxBaseRate { get; set; }
        public decimal AccumulatedProfit { get; set; }
        public decimal AccumulatedLoss { get; set; }
    }
}
