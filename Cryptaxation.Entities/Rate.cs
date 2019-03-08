using System;
using Cryptaxation.Entities.Types.Enums;

namespace Cryptaxation.Entities
{
	public class Rate
	{
		public DateTime Date { get; set; }
		public CurrencyCode OriginCurrency { get; set; }
		public CurrencyCode DestinationCurrency { get; set; }
		public decimal Value { get; set; }
	}
}

