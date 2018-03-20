using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransitsTracker.API.Models;

namespace TransitsTracker.API.Services
{
    public interface IReportService
    {
        Task<MonthlyReport> GetMonthlyReportAsync(DateTime date);
        Task<DailyReport> GetDailyReportAsync(DateTime startDate, DateTime endDate);
    }
}
