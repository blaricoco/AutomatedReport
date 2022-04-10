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
    internal class ReportScheduleRepository : IGenericRepository<ReportSchedule>
    {
        private readonly DapperContext _dapperContext;

        public ReportScheduleRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }


        public async Task<IEnumerable<ReportSchedule>> GetAllAsync()
        {
            using (var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                string sql = "SELECT * FROM tblReportSchedule";
                var reportScheduleList = await connection.QueryAsync<ReportSchedule>(sql);

                return reportScheduleList;
            }
        }


        public async Task<ReportSchedule> GetByIdAsync(int id)
        {
            using (var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                string sql = "SELECT * FROM tblReportSchedule WHERE ReportScheduleID = @Id";
                var reportSchedule = await connection.QueryFirstOrDefaultAsync<ReportSchedule>(sql, new { Id = id });

                return reportSchedule;
            }
        }


        public async Task<int> UpdateAsync(ReportSchedule entity)
        {
            using (var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                string sql = @"UPDATE tblReportSchedule 
                               SET ReportScheduledTime = @ReportScheduledTime, 
                                   ReportScheduledDay = @ReportScheduledDay, 
                                   ReportScheduledDate = @ReportScheduledDate
                               WHERE ReportScheduleID = @ReportScheduleID";

                var updated = await connection.ExecuteAsync(sql, entity);

                return updated;
            }
        }


        public async Task<int> AddAsync(ReportSchedule entity)
        {
            using (var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                string sql = @"INSERT INTO tblReportSchedule  (ReportScheduledTime, ReportScheduledDay, ReportScheduledDate) 
                               VALUES (@ReportScheduledTime,@ReportScheduledDay,@ReportScheduledDate)";

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
