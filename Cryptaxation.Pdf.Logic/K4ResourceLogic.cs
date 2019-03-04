using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;
using Cryptaxation.Pdf.Contract;
using Cryptaxation.Pdf.Models;

namespace Cryptaxation.Pdf.Logic
{
    public class K4ResourceLogic : IK4ResourceLogic
    {
        public K4TabIndexes GetTabIndexesByYear(int year)
        {
            switch (year)
            {
                case 2013:
                case 2014:
                case 2015:
                case 2016:
                case 2017:
                    return new K4TabIndexes()
                    {
                        TabIndexDate = 1,
                        TabIndexNumbering = 2,
                        TabIndexName = 3,
                        TabIndexPersonalIdentificationNumber = 4,
                        TabIndexFirstCurrencyField = 65,
                        TabIndexFirstSumCurrencyField = 107,
                        TabIndexFirstResourceField = 111,
                        TabIndexFirstSumResourceField = 153
                    };
                case 2018:
                    return new K4TabIndexes()
                    {
                        TabIndexDate = 1,
                        TabIndexNumbering = 2,
                        TabIndexName = 3,
                        TabIndexPersonalIdentificationNumber = 4,
                        TabIndexFirstCurrencyField = 66,
                        TabIndexFirstSumCurrencyField = 108,
                        TabIndexFirstResourceField = 112,
                        TabIndexFirstSumResourceField = 154
                    };
                default: throw new NotImplementedException();
            }
        }
    }
}
