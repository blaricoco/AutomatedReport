using AutomatedReport.DataAccess.Contract;
using AutomatedReport.DataAccess.Model;
using Coravel.Invocable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedReport
{
    internal class ScheduledTask : IInvocable
    {
        private readonly ILogger _logger;
        private readonly IGenericRepository<ReportScheduledFrequency> _reportRepository;

        public ScheduledTask(ILogger<ScheduledTask> logger, IGenericRepository<ReportScheduledFrequency> reportRepository)
        {
            _logger = logger;
            _reportRepository = reportRepository;
        }
        public Task Invoke()
        {
            _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
            //var test = _reportScheduledFrequencyRepository.GetAllAsync();

            var test = _reportRepository.UpdateAsync(new ReportScheduledFrequency() { ReportScheduledFrequencyID = 1, ReportFrequencyID = 1, ReportScheduleID = 2});
            var test3 = test.Result;
            var test2 = "";
            return Task.FromResult(true);
        }
    }
}
