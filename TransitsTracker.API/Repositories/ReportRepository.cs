using System;
using System.Linq;
using System.Threading.Tasks;
using TransitsTracker.API.Database;
using TransitsTracker.Core.Domain;
using TransitsTracker.Core.Repositories;

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
            var itemsToReport = _context.Transits.Where(e => e.Date >= startDate && e.Date <= endDate);
            var report = DailyReport.Create(itemsToReport);

            return await Task.FromResult(report);
        }

        public async Task<MonthlyReport> GetMonthlyReportAsync(DateTime date)
        {
            var itemsToReport = _context.Transits.Where(e => e.Date.Month == date.Month);
            var report = MonthlyReport.Create(itemsToReport, date);

            return await Task.FromResult(report);
        }
    }
}
