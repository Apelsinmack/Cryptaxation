using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation.Models
{
    public class BitstampTransaction
    {
		public Type Type { get; set; }
		public DateTime DateTime { get; set; }
		public string Account { get; set; }
		public Currency Amount { get; set; }
		public Currency Value { get; set; }
		public Currency Rate { get; set; }
		public Currency Fee { get; set; }
		public SubType SubType { get; set; }
	}

	public enum Type
	{
		Deposit,
		Witdrawal,
		Market
	}

	public enum SubType
	{
		Buy,
		Sell
	}
}
