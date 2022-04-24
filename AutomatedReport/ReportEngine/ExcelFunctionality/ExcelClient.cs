using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AutomatedReport.ReportEngine.ExcelFunctionality
{
    public static class ExcelClient
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="data">Report data as list of key value pairs</param>
        /// <param name="pathOutput">Directory of report including file name</param>
        public static void ExportToExcel(IEnumerable<dynamic> data, string pathOutput)
        {
            // TODO: Check of potential issues in data such as extra quotations - "  
            // TODO: Improve performance 
            // TODO: Actual Excel client 
            var lines = new List<string>();
            var headerAdded = false;

            foreach (var item in data)
            {
                var rows = (IDictionary<string, object>)item;

                if (!headerAdded)
                {
                    var columnNames = rows.Keys;
                    var header = string.Join(",", columnNames.Select(name => $"\"{name}\""));

                    lines.Add(header);
                    headerAdded = true;
                }

                var columnValues = rows.Values;
                var values = string.Join(",", columnValues.Select(name => $"\"{name}\""));

                lines.Add(values);

            }

            File.WriteAllLines(pathOutput, lines);
        }
    }
}
