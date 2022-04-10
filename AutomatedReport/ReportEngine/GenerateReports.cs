using AutomatedReport.ReportEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedReport.ReportEngine
{
    public class GenerateReports
    {
        public GenerateReports()
        {

        }

        public List<DailyReportModel> GenerateDailyReport()
        {
            var reports = new List<DailyReportModel>();

            return reports;
        }
        // TODO: Write logic for 3 types of reports
        // 1) Map details for daily reports from database 
        // 2) Map details for weekly reports from database 
        // 3) Map details for montly reports from database 

    }
}
