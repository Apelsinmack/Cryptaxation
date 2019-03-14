using System.Collections.Generic;

namespace Cryptaxation.Csv.Contract
{
    public interface IDetailedTransactionCsvLogic<TDetailedTransaction>
    {
        void CreateDetailedTransactionsCsv(List<TDetailedTransaction> detailedTransactionsh);
    }
}
