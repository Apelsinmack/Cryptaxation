using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation.Models
{
    public class BitstampTransaction
    {
		public BitstampTransactionType Type { get; set; }
		public DateTime DateTime { get; set; }
		public string Account { get; set; }
		public Currency Amount { get; set; }
		public Currency Value { get; set; }
		public Currency Rate { get; set; }
		public Currency Fee { get; set; }
		public SubType SubType { get; set; }
	}

	public enum BitstampTransactionType
	{
	    Undefined,
        Deposit,
		Withdrawal,
		Market
	}

	public enum SubType
	{
        Undefined,
		Buy,
		Sell
	}
}
