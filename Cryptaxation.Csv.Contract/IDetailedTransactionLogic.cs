using System.Collections.Generic;

namespace Cryptaxation.Csv.Contract
{
    public interface IDetailedTransactionLogic<T>
    {
        void CreateDetailedTransactionsCsv(List<T> detailedTransactions, string path);
    }
}
