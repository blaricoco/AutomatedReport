﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedReport.ReportEngine.Models
{
    public class ReportModelBase
    {
        public int ReportID { get; set; }
        public string? ReportName { get; set; }
        public string? ReportStoredProcedure { get; set; }
        public Dictionary<string, string>? ReportParameters { get; set; }
        public string? ReportFrequency { get; set; }
    }
}
