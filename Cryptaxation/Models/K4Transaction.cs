using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation
{
    public class K4Transaction
    {
        public string Amount { get; set; }
        public string Currency { get; set; }
        public string SalesPrice { get; set; }
        public string TaxBasis { get; set; }
        public string Gain { get; set; }
        public string Loss { get; set; }
    }
}
