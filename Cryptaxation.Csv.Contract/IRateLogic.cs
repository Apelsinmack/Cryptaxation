using System.Collections.Generic;

namespace Cryptaxation.Csv.Contract
{
    public interface IRateLogic<TRate>
    {
        List<TRate> CreateRateList(string path);
        List<TRate> CreateRates(string[] row);
    }
}
