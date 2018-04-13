using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation.Models
{
	public class Rate
	{
		public DateTime Date { get; set; }
		public Currency OriginCurrency { get; set; }
		public Currency DestinationCurrency { get; set; }
		public Decimal Value { get; set; }
	}

	public enum Currency
	{
		SEK,
		USD,
		EUR,
		BTC
	}
}

