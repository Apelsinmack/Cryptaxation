using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Cryptaxation.Transaction.Contract;
using Cryptaxation.Entities;

namespace Cryptaxation.Transaction.Logic
{
    public class ParseLogic<TTransaction, TRate> : IParseLogic<TTransaction, TRate> where TTransaction : Entities.Transaction where TRate : Rate
    {
        public void ParseTransactions(List<TTransaction> transactions, List<TRate> rates)
        {
            throw new NotImplementedException();
        }
    }
}
