using System.Collections.Generic;

namespace Cryptaxation.Csv.Contract
{
    public interface ITransactionCsvLogic<TTransaction>
    {
        List<TTransaction> CreateTransactionList();
        TTransaction CreateTransaction(string[] row);
    }
}
