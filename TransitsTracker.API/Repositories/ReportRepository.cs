using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransitsTracker.API.Database;
using TransitsTracker.API.Models;

namespace TransitsTracker.API.Repositories
{
    public class ReportRepository : IReportRepository
    {
        private readonly TransitsTrackerContext _context;

        public ReportRepository(TransitsTrackerContext context)
        {
            _context = context;
        }

        public async Task<DailyReport> GetDailyReportAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public async Task<MonthlyReport> GetMonthlyReportAsync(DateTime date)
        {
            throw new NotImplementedException();
        }
    }
}
