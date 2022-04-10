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
    internal class ReportScheduledFrequencyRepository : IGenericRepository<ReportScheduledFrequency>
    {
        private readonly DapperContext _dapperContext;

        public ReportScheduledFrequencyRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext; 
        }


        public async Task<IEnumerable<ReportScheduledFrequency>> GetAllAsync()
        {
            using (var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                string sql = "SELECT * FROM tblReportScheduledFrequency";
                var reportScheduledFrequencyList = await connection.QueryAsync<ReportScheduledFrequency>(sql);

                return reportScheduledFrequencyList;
            }
        }


        public async Task<ReportScheduledFrequency> GetByIdAsync(int id)
        {
            using (var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                string sql = "SELECT * FROM tblReportScheduledFrequency WHERE ReportScheduledFrequencyID = @Id";
                var reportScheduledFrequency = await connection.QueryFirstOrDefaultAsync<ReportScheduledFrequency>(sql, new { Id = id });

                return reportScheduledFrequency;
            }
        }


        public async Task<int> UpdateAsync(ReportScheduledFrequency entity)
        {
            using (var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                string sql = @"UPDATE tblReportScheduledFrequency 
                               SET ReportFrequencyID = @ReportFrequencyID, 
                                   ReportScheduleID = @ReportScheduleID
                               WHERE ReportScheduledFrequencyID = @ReportScheduledFrequencyID";

                var updated = await connection.ExecuteAsync(sql, entity);

                return updated;
            }
        }


        public async Task<int> AddAsync(ReportScheduledFrequency entity)
        {
            using (var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                string sql = @"INSERT INTO tblReportScheduledFrequency (ReportFrequencyID, ReportScheduleID) 
                               VALUES (@ReportFrequencyID, @ReportScheduleID)";

                var updated = await connection.ExecuteAsync(sql, entity);

                return updated;
            }
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }


        
    }
}
