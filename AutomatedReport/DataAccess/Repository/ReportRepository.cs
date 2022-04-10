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
    // TODO: Implement tblReports repository logic 
    internal class ReportRepository : IGenericRepository<Report>
    {
        private readonly DapperContext _dapperContext;
        public ReportRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
            
        }
        public async Task<IEnumerable<Report>> GetAllAsync()
        {
            
            using(var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                string sql = "SELECT * FROM tblReports";
                var reportList  = await connection.QueryAsync<Report>(sql);

                return reportList;
            }

        }


        public async Task<Report> GetByIdAsync(int id)
        {
            using (var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                string sql = "SELECT * FROM tblReports WHERE ReportID = @Id";
                var report = await connection.QueryFirstOrDefaultAsync<Report>(sql, new {Id = id});

                return report; 
            }
        }


        public async Task<int> UpdateAsync(Report entity)
        {
            using (var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                string sql = @"UPDATE tblReports 
                               SET ReportName = @ReportName, 
                                   ReportStoredProcedure = @ReportStoredProcedure, 
                                   ReportParameters = @ReportParameters, 
                                   ReportScheduledFrequencyID = @ReportScheduledFrequencyID, 
                                   Active = @Active
                               WHERE ReportID = @ReportID";

                var updated = await connection.ExecuteAsync(sql, entity);

                return updated;
            }
        }


        public async Task<int> AddAsync(Report entity)
        {
            using (var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                string sql = @"INSERT INTO tblReports (ReportName ,ReportStoredProcedure ,ReportParameters ,ReportScheduledFrequencyID ,Active)
                               VALUES (@ReportName, @ReportStoredProcedure, @ReportParameters, @ReportScheduledFrequencyID, @Active)";

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
