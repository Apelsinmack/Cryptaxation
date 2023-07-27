using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation.Parse.Contract
{
    public interface IK4ReportLogic<TK4ReportYearlySummary>
    {
        Dictionary<int, TK4ReportYearlySummary> CreateK4ReportYearlySummaryList();
    }
}
