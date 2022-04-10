using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedReport.DataAccess.Models
{
    internal class ReportScheduledFrequency
    {
        public int ReportScheduledFrequencyID { get; set; }
        public int ReportFrequencyID { get; set; }
        public int ReportScheduleID { get; set; }
    }
}
