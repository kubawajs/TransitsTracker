using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransitsTracker.API.Services;

namespace TransitsTracker.API.Controllers
{
    [Produces("application/json")]
    [Route("api/Reports")]
    public class ReportsController : Controller
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        public async Task<IActionResult> Daily(DateTime startDate, DateTime endDate)
        {
            var report = await _reportService.GetDailyReportAsync(startDate, endDate);
            return Json(report);
        }

        [HttpGet]
        public async Task<IActionResult> Monthly()
        {
            var dateNow = DateTime.UtcNow;
            var report = await _reportService.GetMonthlyReportAsync(dateNow);
            return Json(report);
        }
    }
}