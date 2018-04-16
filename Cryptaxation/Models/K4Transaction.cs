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
        public decimal SalesPrice { get; set; }
        public decimal TaxBasis { get; set; }
        public decimal Gain { get; set; }
        public decimal Loss { get; set; }
    }
}
