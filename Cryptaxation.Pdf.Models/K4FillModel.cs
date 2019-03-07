using System.Collections.Generic;

namespace Cryptaxation.Pdf.Models
{
    public class K4FillModel
    {
        public int Year { get; set; }
        public K4TabIndexModel TabIndexes { get; set; }
        public string FullName { get; set; }
        public string PersonalIdentificatonNumber { get; set; }
        public List<K4TransactionModel> CryptoTransactions { get; set; }
        public List<K4TransactionModel> FiatTransactions { get; set; }
    }
}
