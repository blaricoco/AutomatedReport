using AutomatedReport.ReportEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutomatedReport.ReportEngine
{
    public class ModelMapper
    {
        public static DailyReportModel MapDailyReport(DataAccess.Models.AutomatedReport automatedReport)
        {
            var dailyReport = new DailyReportModel()
            {
                ReportID = automatedReport.ReportID,
                ReportFrequency = automatedReport.ReportFrequency,
                ReportName = automatedReport.ReportName,
                ReportParameters = ParseToDict(automatedReport.ReportParameters),
                ReportScheduledTime = automatedReport.ReportScheduledTime.Split(';').ToList(),
                ReportStoredProcedure = automatedReport.ReportStoredProcedure
            };

            return dailyReport;
        }

        public static WeeklyReportModel MapWeeklyReport(DataAccess.Models.AutomatedReport automatedReport)
        { 
            var weeklyReport = new WeeklyReportModel()
            {
                ReportID = automatedReport.ReportID,
                ReportFrequency = automatedReport.ReportFrequency,
                ReportName = automatedReport.ReportName,
                ReportParameters = ParseToDict(automatedReport.ReportParameters),
                ReportScheduledTime = automatedReport.ReportScheduledTime.Split(';').ToList(),
                ReportStoredProcedure = automatedReport.ReportStoredProcedure,
                ReportScheduledDay = automatedReport.ReportScheduledDay.Split(';').ToList()
            };

            return weeklyReport;
        }
         
        public static MontlyReportModel MapMontlyReport(DataAccess.Models.AutomatedReport automatedReport)
        {
            var montlyReport = new MontlyReportModel()
            {
                ReportID = automatedReport.ReportID,
                ReportFrequency = automatedReport.ReportFrequency,
                ReportName = automatedReport.ReportName,
                ReportParameters = ParseToDict(automatedReport.ReportParameters),
                ReportScheduledTime = automatedReport.ReportScheduledTime.Split(';').ToList(),
                ReportStoredProcedure = automatedReport.ReportStoredProcedure,
                ReportScheduledDate = automatedReport.ReportScheduledDate.Split(';').ToList()
            };

            return montlyReport;
        }

        private static Dictionary<string, string> ParseToDict(string parameters)
        {
            var dict = new Dictionary<string, string>();
            var regex = new Regex(@"([a-zA-Z1-9_-]*):([a-zA-Z1-9_-]*)");
            var matches = regex.Matches(parameters);

            foreach (Match item in matches)
            {
                dict.Add(item.Groups[1].ToString(), item.Groups[2].ToString());
            }

            return dict;
        }
    }
}
