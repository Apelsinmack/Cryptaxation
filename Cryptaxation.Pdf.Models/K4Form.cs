using System.Collections.Generic;

namespace Cryptaxation.Pdf.Models
{
    public class K4Form
    {
        public K4TabIndexes TabIndexes { get; set; }
        public string Name { get; set; }
        public string PersonalIdentificatonNumber { get; set; }
        public List<K4Transaction> CryptoTransactions { get; set; }
        public List<K4Transaction> FiatTransactions { get; set; }
    }
}
