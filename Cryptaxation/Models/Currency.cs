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
                if (CurrencyCode == CurrencyCode.BTC || CurrencyCode == CurrencyCode.ETH || CurrencyCode == CurrencyCode.LTC)
		        {
		            return CurrencyType.CryptoCurrency;
		        }
		        return CurrencyType.FiatCurrency;
		    }
		}
		public decimal Value { get; set; }
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
