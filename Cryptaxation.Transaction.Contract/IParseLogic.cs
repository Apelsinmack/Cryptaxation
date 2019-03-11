using System.Collections.Generic;

namespace Cryptaxation.Transaction.Contract
{
    public interface IParseLogic<TTransaction>
    {
        void ParseTransactions(List<TTransaction> transactions);
    }
}
