using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation.Parse.Contract
{
    public interface IReportLogic<TReportYearlySummary>
    {
        List<TReportYearlySummary> CreateReportYearlySummaryList();
    }
}
