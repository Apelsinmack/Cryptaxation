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
		SEK,
		USD,
		EUR,
		BTC
	}

	public enum CurrencyType
	{
		FiatCurrency,
		CryptoCurrency
	}
}
