using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedReport.DataAccess.Models
{
    public class ReportSchedule
    {
        public int ReportScheduleID { get; set; }
        public string? ReportScheduledTime { get; set; }
        public string? ReportScheduledDay { get; set; }
        public string? ReportScheduledDate { get; set; }

    }
}
