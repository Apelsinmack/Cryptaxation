using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation.Models
{
	public class Currency
	{
		public Code Code { get; set; }
		public Decimal Value { get; set; }
	}

	public enum Code
	{
		SEK,
		USD,
		EUR,
		BTC
	}
}
