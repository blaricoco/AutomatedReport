using AutomatedReport.DataAccess.Repository;
using AutomatedReport.ReportEngine.ExcelFunctionality;
using AutomatedReport.ReportEngine.Models;
using Coravel.Invocable;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedReport.Invocables
{
    internal class DailyReport : IInvocable
    {
        private readonly ILogger _logger;
        private readonly IConfiguration _configuration;
        private readonly string _reportOutputDir;
        private readonly DailyReportModel _report;
        private readonly ReportSPRepository _reportSPRepository;
        public DailyReport(ILogger<DailyReport> logger, IConfiguration configuration, DailyReportModel report, ReportSPRepository reportSPRepository)
        {
            _logger = logger;
            _configuration = configuration;
            _reportOutputDir = _configuration.GetSection("Report:OutputDir").Value;
            _report = report;
            _reportSPRepository = reportSPRepository;
        }
        public Task Invoke()
        {
            // Get report data from database
            var data = _reportSPRepository.GetDataSPAsync(_report.ReportStoredProcedure, _report.ReportParameters).Result;

            // Save report into directory 
            ExcelClient.ExportToExcel(data, $"{_reportOutputDir}\\{_report.ReportName}_{DateTime.Now.ToString("yyyy_MMddm")}.csv");
            
            // TODO: send report via email


            _logger.LogInformation($"Daily report invoked: {_report.ReportName}"); 

            return Task.FromResult(true);
        }
    }
}
