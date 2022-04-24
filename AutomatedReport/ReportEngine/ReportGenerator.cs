using AutomatedReport.DataAccess.Contract;
using AutomatedReport.DataAccess.Models;
using AutomatedReport.ReportEngine.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedReport.ReportEngine
{
    public class ReportGenerator
    {

        private readonly IGenericRepository<DataAccess.Models.AutomatedReport> _automatedReport;
        public readonly List<DailyReportModel> dialyReports = new();
        public readonly List<WeeklyReportModel> weeklyReports = new();
        public readonly List<MontlyReportModel> montlyReports = new();

        public ReportGenerator(IGenericRepository<DataAccess.Models.AutomatedReport> automatedReport)
        {
            _automatedReport = automatedReport;
            MapReports();
        }

        private void MapReports()
        {
            var reports = _automatedReport.GetAllAsync().Result;

            foreach(var report in reports)
            {
                if (IsDailyReport(report))
                {
                    dialyReports.Add(ModelMapper.MapDailyReport(report)); 
                }
                if (IsWeeklyReport(report))
                {
                    weeklyReports.Add(ModelMapper.MapWeeklyReport(report));
                }
                if (IsMontlyReport(report))
                { 
                    montlyReports.Add(ModelMapper.MapMontlyReport(report));
                }
            }
        }

        private bool IsDailyReport(DataAccess.Models.AutomatedReport automatedReport)
        { 
            var isValid = false;

            // ScheduledTime field needs to be filled 
            if (!string.IsNullOrEmpty(automatedReport.ReportScheduledTime) && 
                 string.IsNullOrEmpty(automatedReport.ReportScheduledDay) && 
                 string.IsNullOrEmpty(automatedReport.ReportScheduledDate))
            {
                isValid = true;
            }

            return isValid;
        }

        private bool IsWeeklyReport(DataAccess.Models.AutomatedReport automatedReport)
        {
            var isValid = false;

            // ScheduledTime and scheduledDay field needs to be filled  
            if (!string.IsNullOrEmpty(automatedReport.ReportScheduledTime) &&
                !string.IsNullOrEmpty(automatedReport.ReportScheduledDay) &&
                 string.IsNullOrEmpty(automatedReport.ReportScheduledDate))
            {
                isValid = true;
            }

            return isValid;
        }

        private bool IsMontlyReport(DataAccess.Models.AutomatedReport automatedReport)
        {
            var isValid = false;

            // ScheduledTime and ScheduledDate field needs to be filled 
            if (!string.IsNullOrEmpty(automatedReport.ReportScheduledTime) &&
                 string.IsNullOrEmpty(automatedReport.ReportScheduledDay) &&
                !string.IsNullOrEmpty(automatedReport.ReportScheduledDate))
            {
                isValid = true;
            }

            return isValid;
        }
    }
}
