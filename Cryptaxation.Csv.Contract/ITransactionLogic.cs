using System.Collections.Generic;

namespace Cryptaxation.Csv.Contract
{
    public interface ITransactionLogic<TTransaction>
    {
        List<TTransaction> CreateTransactionList(string path);
        TTransaction CreateTransaction(string[] row);
    }
}
