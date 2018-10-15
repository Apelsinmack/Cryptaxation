using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation.Models
{
	public class Currency
	{
		public CurrencyCode CurrencyCode { get; set; }
		public CurrencyType Type {
		    get
		    {
		        if (CurrencyCode == CurrencyCode.Undefined)
		        {
		            return CurrencyType.Undefined;
		        }
		        // TODO: Add other cryptos here.
                if (CurrencyCode == CurrencyCode.BTC)
		        {
		            return CurrencyType.CryptoCurrency;
		        }
		        return CurrencyType.FiatCurrency;
		    }
		}
		public Decimal Value { get; set; }
	}

	public enum CurrencyCode
	{
        Undefined,
		SEK,
		USD,
		EUR,
		BTC,
        LTC,
        ETH
	}

	public enum CurrencyType
	{
	    Undefined,
        FiatCurrency,
		CryptoCurrency
	}
}
