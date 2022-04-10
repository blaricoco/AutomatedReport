using Coravel.Invocable;
using Coravel.Scheduling.Schedule.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedReport
{
    internal class TestService: IInvocable
    {
        private readonly ILogger _logger;
        private readonly IScheduler _scheduler;
        public TestService(ILogger<TestService> logger, IScheduler scheduler) 
        {
            _logger = logger;
            _scheduler = scheduler;
        }

        public Task Invoke()
        {

            _logger.LogInformation("Scheduler triggered!");
            // Read database 
            _scheduler.Schedule<ScheduledTask>().EveryFiveSeconds();



            return Task.FromResult(true);
        }
    }
}
