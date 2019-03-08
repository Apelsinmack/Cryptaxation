using System;
using Cryptaxation.Entities.Types;
using Cryptaxation.Entities.Types.Enums;

namespace Cryptaxation.Entities
{
    public class Transaction
    {
		public TransactionType Type { get; set; }
		public DateTime DateTime { get; set; }
		public string Account { get; set; }
		public Currency Amount { get; set; }
		public Currency Value { get; set; }
		public Currency Rate { get; set; }
		public Currency Fee { get; set; }
		public TradeAction Action { get; set; }
	}
}
