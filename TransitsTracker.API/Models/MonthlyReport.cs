using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransitsTracker.API.Models
{
    public class MonthlyReport : Report
    {
        public IEnumerable<MonthlyReportItem> Items { get; set; }

        public MonthlyReport()
        {
            Items = new HashSet<MonthlyReportItem>();
        }
    }
}
