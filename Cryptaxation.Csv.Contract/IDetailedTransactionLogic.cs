using System.Collections.Generic;

namespace Cryptaxation.Csv.Contract
{
    public interface IDetailedTransactionLogic<TDetailedTransaction>
    {
        void CreateDetailedTransactionsCsv(List<TDetailedTransaction> detailedTransactions, string path);
    }
}
