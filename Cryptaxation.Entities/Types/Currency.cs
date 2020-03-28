using System;
using Cryptaxation.Entities.Types.Enums;

namespace Cryptaxation.Entities.Types
{
	public class Currency
	{
		public CurrencyCode CurrencyCode { get; set; }
		public CurrencyType Type {
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
		public decimal Value { get; set; }
	}
}
