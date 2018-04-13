using Cryptaxation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation.Helpers
{
    public class TransactionHelper
    {
		public List<K4Transaction> K4CurrencyTransactions;

		public List<K4Transaction> K4CryptocurrencyTransactions;

		public void UpdateK4TransactionListFromBitstampTransactions(List<BitstampTransaction> bitstampTransactions, List<Rate> rates)
		{
			List<K4Transaction> k4Transactions = new List<K4Transaction>();
			List<Currency> costBases = new List<Currency>();
			//For each Bitstamp transaction
			foreach (BitstampTransaction bitstampTransaction in bitstampTransactions)
			{

				//	om typen är "Market"
				//		om amounttyp är kryptovaluta och subtyp är "Buy"
				//			om fee har ett värde lägg till det till amount. plussa på omkostnadsbelopp.
				//		om value är kryptovaluta och subtyp är "Buy"
				//		om amount är kryptovaluta och subtyp är "Sell"
				//		om value är kryptovaluta och subtyp är "Sell"
				//			om fee har ett värde lägg till det till value. plussa på omkostnadsbelopp.
				//		om amounttyp är fiatvaluta och subtyp är "Buy"
				//			om fee har ett värde lägg till det till amount. plussa på omkostnadsbelopp.
				//		om value är fiatvaluta och subtyp är "Buy"
				//		om amount är fiatvaluta och subtyp är "Sell"
				//		om value är fiatvaluta och subtyp är "Sell"
				//			om fee har ett värde lägg till det till value. plussa på omkostnadsbelopp.
			}
		}
	}
}
