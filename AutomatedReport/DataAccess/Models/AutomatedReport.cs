using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedReport.DataAccess.Models
{
    public class AutomatedReport
    {
        public int ReportID { get; set; }
        public string? ReportName { get; set; }
        public string? ReportStoredProcedure { get; set; }
        public string? ReportParameters { get; set; }
        public int ReportScheduledFrequencyID { get; set; }
        public bool Active { get; set; }
        public int ReportFrequencyID { get; set; }
        public string? ReportFrequency { get; set; } 
        public int ReportScheduleID { get; set; }
        public string? ReportScheduledTime { get; set; }
        public string? ReportScheduledDay { get; set; }
        public string? ReportScheduledDate { get; set; }
    }
}
