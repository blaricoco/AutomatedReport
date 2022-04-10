using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedReport.ReportEngine.Models
{
    public class DailyReportModel: ReportModelBase
    {
        public List<string>? ReportScheduledTime { get; set; } 
    }
}
