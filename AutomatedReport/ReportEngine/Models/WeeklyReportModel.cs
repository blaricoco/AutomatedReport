using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedReport.ReportEngine.Models
{
    public class WeeklyReportModel
    {
        public List<string>? ReportScheduledTime { get; set; }
        public List<string>? ReportScheduledDay { get; set; } 
    }
}
