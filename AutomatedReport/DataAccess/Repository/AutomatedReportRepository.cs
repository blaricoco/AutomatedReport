using AutomatedReport.DataAccess.Contract;
using AutomatedReport.DataAccess.Models;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedReport.DataAccess.Repository
{
    internal class AutomatedReportRepository: IGenericRepository<Models.AutomatedReport>
    {
        private readonly DapperContext _dapperContext;

        public AutomatedReportRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<Models.AutomatedReport>> GetAllAsync()
        {
            using (var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                string sql = @"SELECT *
	                            FROM tblReports R
	                            LEFT JOIN tblReportScheduledFrequency RSF
		                            ON R.ReportScheduledFrequencyID = RSF.ReportScheduledFrequencyID
	                            LEFT JOIN tblReportFrequency RF
		                            ON RF.ReportFrequencyID = RSF.ReportFrequencyID
	                            LEFT JOIN tblReportSchedule RS
		                            ON RS.ReportScheduleID = RSF.ReportScheduleID";
                var automatedReports = await connection.QueryAsync<Models.AutomatedReport>(sql);

                return automatedReports;
            }
        }


        public Task<int> AddAsync(Models.AutomatedReport entity)
        {
            throw new NotImplementedException();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }


        public Task<Models.AutomatedReport> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<int> UpdateAsync(Models.AutomatedReport entity)
        {
            throw new NotImplementedException();
        }
    }
}
