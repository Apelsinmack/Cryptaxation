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
		public CurrencyCode OriginCurrency { get; set; }
		public CurrencyCode DestinationCurrency { get; set; }
		public Decimal Value { get; set; }
	}
}

