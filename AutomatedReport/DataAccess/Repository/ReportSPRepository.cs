using Dapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedReport.DataAccess.Repository
{
    internal class ReportSPRepository
    {
        private readonly DapperContext _dapperContext;

        public ReportSPRepository(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<IEnumerable<dynamic>> GetDataAsync()
        {
            using (var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                string sql = "SELECT * FROM tblReports";
                var reportData = await connection.QueryAsync(sql);

                return reportData;
            }
        }

        public async Task<IEnumerable<dynamic>> GetDataSPAsync(string storedProcedure, Dictionary<string, string> parametersDict)
        {
            using (var connection = _dapperContext.GetDbConnection())
            {
                connection.Open();

                var parameters = new DynamicParameters();

                foreach (KeyValuePair<string, string> entry in parametersDict)
                {
                    parameters.Add($"{entry.Key}", entry.Value);
                }

                var reportData = await connection.QueryAsync(storedProcedure, parameters, commandType:CommandType.StoredProcedure);

                return reportData;
            }
        }
    }
}
