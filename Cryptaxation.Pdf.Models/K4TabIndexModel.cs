using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation.Pdf.Models
{
    public class K4TabIndexModel
    {
        public int Date { get; set; }
        public int Numbering { get; set; }
        public int Name { get; set; }
        public int PersonalIdentificationNumber { get; set; }
        public int FirstCurrencyField { get; set; }
        public int FirstSumCurrencyField { get; set; }
        public int FirstResourceField { get; set; }
        public int FirstSumResourceField { get; set; }
    }
}
