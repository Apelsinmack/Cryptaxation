﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptaxation.Csv.Contract
{
    public interface IReportCsvLogic<TReportYearlySummary>
    {
        void CreateReportCsv(List<TReportYearlySummary> reportYearlySummaries);
    }
}
