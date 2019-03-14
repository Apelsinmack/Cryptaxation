using System.Collections.Generic;

namespace Cryptaxation.Csv.Contract
{
    public interface IRateCsvLogic<TRate>
    {
        List<TRate> CreateRateList();
    }
}
