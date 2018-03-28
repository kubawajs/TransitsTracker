using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TransitsTracker.API.Services;

namespace TransitsTracker.API.Controllers
{
    [Route("api/Reports")]
    public class ReportsController : Controller
    {
        private readonly IReportService _reportService;

        public ReportsController(IReportService reportService)
        {
            _reportService = reportService;
        }

        [HttpGet]
        [Route("daily")]
        public async Task<IActionResult> Daily([FromQuery(Name = "start_date")] DateTime startDate, [FromQuery(Name = "end_date")] DateTime endDate)
        {
            var report = await _reportService.GetDailyReportAsync(startDate, endDate);
            if(report == null)
            {
                return NotFound();
            }
            return Json(report);
        }

        [HttpGet]
        [Route("monthly")]
        public async Task<IActionResult> Monthly()
        {
            var dateNow = DateTime.UtcNow;
            var report = await _reportService.GetMonthlyReportAsync(dateNow);
            if (report == null)
            {
                return NotFound();
            }
            return Json(report);
        }
    }
}