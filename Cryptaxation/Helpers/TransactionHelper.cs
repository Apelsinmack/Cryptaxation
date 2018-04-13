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
			// For each Bitstamp transaction
			foreach (BitstampTransaction bitstampTransaction in bitstampTransactions)
			{
				// If the BitstampTransactionType is Market
				if (bitstampTransaction.Type == BitstampTransactionType.Market)
				{
					// If the BitstampTransactionSubType is Buy
					if (bitstampTransaction.SubType == SubType.Buy)
					{
						//If the Amount type is FiatCurrency
						if (bitstampTransaction.Amount.Type == CurrencyType.FiatCurrency)
						{
							//Update costbasis, if fee has a value add it.
							if (bitstampTransaction.Fee.Value > 0)
							{

							}
							else
							{

							}
						}
						//If the Value type is FiatCurrency
						if (bitstampTransaction.Value.Type == CurrencyType.FiatCurrency)
						{

						}
						//If the Amount type is CryptoCurrency
						if (bitstampTransaction.Amount.Type == CurrencyType.CryptoCurrency)
						{
							//Update costbasis, if fee has a value add it.
							if (bitstampTransaction.Fee.Value > 0)
							{

							}
							else
							{

							}
						}
						//If the Value type is CryptoCurrency
						if (bitstampTransaction.Value.Type == CurrencyType.CryptoCurrency)
						{

						}
					}
					// If the BitstampTransactionSubType is Sell
					if (bitstampTransaction.SubType == SubType.Sell)
					{
						//If the Amount type is FiatCurrency
						if (bitstampTransaction.Amount.Type == CurrencyType.FiatCurrency)
						{
							
						}
						//If the Value type is FiatCurrency
						if (bitstampTransaction.Value.Type == CurrencyType.FiatCurrency)
						{
							//Update costbasis, if fee has a value add it.
							if (bitstampTransaction.Fee.Value > 0)
							{

							}
							else
							{

							}
						}
						//	om fee har ett värde lägg till det till value. plussa på omkostnadsbelopp.
						//If the Amount type is CryptoCurrency
						if (bitstampTransaction.Amount.Type == CurrencyType.CryptoCurrency)
						{
							
						}
						//If the Value type is CryptoCurrency
						if (bitstampTransaction.Value.Type == CurrencyType.CryptoCurrency)
						{
							//Update costbasis, if fee has a value add it.
							if (bitstampTransaction.Fee.Value > 0)
							{

							}
							else
							{

							}
						}
					}
				}
			}
		}
	}
}
