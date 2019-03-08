using System.Collections.Generic;

namespace Cryptaxation.Csv.Contract
{
    public interface IRateLogic<T>
    {
        List<T> CreateRateList(string path);
        List<T> CreateRates(string[] row);
    }
}
