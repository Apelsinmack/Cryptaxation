using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation
{
    public class K4Transaction
    {
        public decimal Amount { get; set; }
        public string Currency { get; set; }
        public int SalesPrice { get; set; }
        public int TaxBasis { get; set; }
        public int Gain { get; set; }
        public int Loss { get; set; }
    }
}
