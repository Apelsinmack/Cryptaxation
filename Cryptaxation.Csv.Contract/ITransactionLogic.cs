using System.Collections.Generic;

namespace Cryptaxation.Csv.Contract
{
    public interface ITransactionLogic<T>
    {
        List<T> CreateTransactionList(string path);
        T CreateTransaction(string[] row);
    }
}
