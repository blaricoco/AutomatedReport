using AutomatedReport.DataAccess.Repository;
using AutomatedReport.Invocables;
using AutomatedReport.ReportEngine.ExcelFunctionality;
using AutomatedReport.ReportEngine.Models;
using Coravel.Invocable;
using Coravel.Scheduling.Schedule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedReport.ReportEngine
{
    internal class ReportScheduler:IInvocable
    {
        private readonly ReportGenerator _reportGenerator;
        private readonly ILogger _logger;
        private readonly IScheduler _scheduler;
        public ReportScheduler(ILogger<ReportScheduler> logger, IScheduler scheduler, ReportGenerator reportGenerator)
        {
            _reportGenerator = reportGenerator;
            _logger = logger;
            _scheduler = scheduler;

        }

        public Task Invoke()
        {
            _logger.LogInformation("Report Scheduler running at: {time}", DateTimeOffset.Now);

            ScheduleDailyReports();

            return Task.FromResult(true);
        }

    
        private void ScheduleDailyReports()
        {
            var dailyReports = _reportGenerator.dialyReports;
            var weeklyReports = _reportGenerator.weeklyReports;
            var montlyReports = _reportGenerator.montlyReports;

            foreach (var report in dailyReports)
            {
                var cronStringList = ParseToCron(report.ReportScheduledTime);

                foreach(var cronString in cronStringList) 
                {
                    _scheduler.ScheduleWithParams<DailyReport>(report).Cron(cronString);
                    _logger.LogInformation($"Daily Report Scheduled: {report.ReportName}");
                    _logger.LogInformation($"{cronString}");
                }
            }

            foreach (var report in weeklyReports)
            {
                var cronStringList = ParseToCronWeekly(report.ReportScheduledTime, report.ReportScheduledDay);

                foreach (var cronString in cronStringList)
                {
                    _scheduler.ScheduleWithParams<DailyReport>(report).Cron(cronString);
                    _logger.LogInformation($"Weekly Report Scheduled: {report.ReportName}");
                    _logger.LogInformation($"{cronString}");
                }
            }

            foreach (var report in montlyReports)
            {
                var cronStringList = ParseToCronMontly(report.ReportScheduledTime, report.ReportScheduledDate);

                foreach (var cronString in cronStringList)
                {
                    _scheduler.ScheduleWithParams<DailyReport>(report).Cron(cronString);
                    _logger.LogInformation($"Montly Report Scheduled: {report.ReportName}");
                    _logger.LogInformation($"{cronString}");
                }
            }
        }

        private List<string> ParseToCron(List<string> scheduledTimeList)
        {
 
            var listCron = new List<string>();
     
            foreach(var scheduledTime in scheduledTimeList)
            {
                // Coravel cron starts hour at 0 - 23
                // Substraction of 1 hour required 
                var hour = Convert.ToInt32(scheduledTime.Split(':')[0]) - 1;
                var minute = scheduledTime.Split(':')[1];

                var cron = $"{minute} {hour} * * *";
                listCron.Add(cron);
            }

            return listCron;
        }

        private List<string> ParseToCronWeekly(List<string> scheduledTimeList, List<string> scheduledDayList)
        {

            var listCron = new List<string>();

            foreach (var scheduledTime in scheduledTimeList)
            {
                foreach(var scheduledDay in scheduledDayList)
                {
                    var hour = Convert.ToInt32(scheduledTime.Split(':')[0]) - 1;
                    var minute = scheduledTime.Split(':')[1];

                    var cron = $"{minute} {hour} * * {scheduledDay}";
                    listCron.Add(cron);
                }
            }

            return listCron;
        }

        private List<string> ParseToCronMontly(List<string> scheduledTimeList, List<string> scheduledDateList)
        {

            var listCron = new List<string>();

            foreach (var scheduledDate in scheduledDateList)
            {
                foreach(var scheduledTime in scheduledTimeList)
                {
                    var hour = Convert.ToInt32(scheduledTime.Split(':')[0]) - 1;
                    var minute = scheduledTime.Split(':')[1];

                    var cron = $"{minute} {hour} {scheduledDate} * *";
                    listCron.Add(cron);
                }
            }

            return listCron;
        }
    }
}
