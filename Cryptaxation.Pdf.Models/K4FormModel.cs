using System.Collections.Generic;

namespace Cryptaxation.Pdf.Models
{
    public class K4FormModel
    {
        public string FullName { get; set; }
        public string PersonalIdentificatonNumber { get; set; }
        public List<int> Years { get; set; }
        public Dictionary<int, List<K4TransactionModel>> CryptoTransactions { get; set; }
        public Dictionary<int, List<K4TransactionModel>> FiatTransactions { get; set; }
    }
}
