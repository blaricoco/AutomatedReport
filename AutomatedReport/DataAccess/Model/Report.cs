using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedReport.DataAccess.Model
{
    internal class Report
    {
        public int ReportID { get; set; }
        public string? ReportName { get; set; }
        public string? ReportStoredProcedure { get; set; }
        public string? ReportParameters { get; set; }
        public int ReportScheduledFrequencyID { get; set; }
        public bool Active { get; set; }

    }
}
