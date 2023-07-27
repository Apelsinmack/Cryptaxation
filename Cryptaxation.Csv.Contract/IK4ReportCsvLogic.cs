using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation.Csv.Contract
{
    public interface IK4ReportCsvLogic<TK4ReportYearlySummary>
    {
        void CreateK4ReportCsv(Dictionary<int, TK4ReportYearlySummary> k4reportYearlySummaries);
    }
}
