using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedReport.ReportEngine.Models
{
    internal class MontlyReportModel: ReportModelBase
    {
        public List<string>? ReportScheduledTime { get; set; }
        public List<string>? ReportScheduledDate { get; set; }
    }
}
