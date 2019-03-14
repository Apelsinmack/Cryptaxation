using System.Collections.Generic;

namespace Cryptaxation.Parse.Contract
{
    public interface ITransactionLogic<TTransaction>
    {
        void ParseTransactions(List<TTransaction> transactions);
    }
}
