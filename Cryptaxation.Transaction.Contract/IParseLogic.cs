using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation.Transaction.Contract
{
    public interface IParseLogic<TTransaction, TRate>
    {
        void ParseTransactions(List<TTransaction> transactions, List<TRate> rates);
    }
}
