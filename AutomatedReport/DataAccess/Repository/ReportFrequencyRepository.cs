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
    internal class ReportFrequencyRepository : IGenericRepository<ReportFrequency_>
    {
        private readonly DapperContext _dapperContext;

        public ReportFrequencyRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }


        public async Task<IEnumerable<ReportFrequency_>> GetAllAsync()
        {
            
            using (var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                string sql = "SELECT * FROM tblReportFrequency";
                var reportFrequencyList = await connection.QueryAsync<ReportFrequency_>(sql);

                return reportFrequencyList; 
            }
        }


        public async Task<ReportFrequency_> GetByIdAsync(int id)
        {
            using (var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                string sql = "SELECT * FROM tblReportFrequency WHERE ReportFrequencyID = @Id";
                var reportFrequency = await connection.QueryFirstOrDefaultAsync<ReportFrequency_>(sql, new { Id = id });

                return reportFrequency;
            }
        }


        public async Task<int> UpdateAsync(ReportFrequency_ entity)
        {
            using (var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                string sql = @"UPDATE tblReportFrequency 
                                SET ReportFrequency = @ReportFrequency
                                WHERE ReportFrequencyID = @ReportFrequencyID";

                var updated = await connection.ExecuteAsync(sql, entity);

                return updated;
            }
        }


        public async Task<int> AddAsync(ReportFrequency_ entity)
        {
            using (var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                string sql = @"INSERT INTO tblReportFrequency (ReportFrequency) VALUES (@ReportFrequency)";

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
