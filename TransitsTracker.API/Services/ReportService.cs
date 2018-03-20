using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransitsTracker.API.Models;
using TransitsTracker.API.Repositories;

namespace TransitsTracker.API.Services
{
    public class ReportService : IReportService
    {
        private readonly IReportRepository _reportRepository;

        public ReportService(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        public async Task<DailyReport> GetDailyReportAsync(DateTime startDate, DateTime endDate)
            => await _reportRepository.GetDailyReportAsync(startDate, endDate);

        public async Task<MonthlyReport> GetMonthlyReportAsync(DateTime date)
            => await _reportRepository.GetMonthlyReportAsync(date);
    }
}
