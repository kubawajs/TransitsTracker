using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TransitsTracker.API.Controllers;
using TransitsTracker.API.Services;
using TransitsTracker.Core.Domain;
using TransitsTracker.Tests.Unit.Helpers;
using Xunit;

namespace TransitsTracker.Tests.Unit.Controllers
{
    public class ReportsControllerTests
    {
        // TODO: test for mapping parameters in query

        [Fact]
        public async void get_daily_report_should_return_json_for_valid_data()
        {
            var startDate = DateTime.Now.AddDays(-1);
            var endDate = DateTime.Now.AddDays(-2);
            var expected = ReportsTestHelper.GetTestDailyReport();

            // Arrange
            var reportServiceMock = new Mock<IReportService>();
            var controllerMock = new ReportsController(reportServiceMock.Object);

            reportServiceMock.Setup(service => service.GetDailyReportAsync(startDate, endDate))
                             .Returns(Task.FromResult(expected));

            // Act
            var response = await controllerMock.Daily(startDate, endDate);
            var result = response as JsonResult;
            var actual = result.Value as DailyReport;

            // Assert
            Assert.IsType<JsonResult>(response);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void get_daily_report_should_return_not_found_for_invalid_data()
        {
            var startDate = DateTime.Now.AddDays(-1);
            var endDate = DateTime.Now.AddDays(-2);

            // Arrange
            var reportServiceMock = new Mock<IReportService>();
            var controllerMock = new ReportsController(reportServiceMock.Object);

            reportServiceMock.Setup(service => service.GetDailyReportAsync(startDate, endDate))
                             .Returns(Task.FromResult((DailyReport)null));

            // Act
            var response = await controllerMock.Daily(startDate, endDate);
            var result = response as NotFoundResult;

            // Assert
            Assert.IsType<NotFoundResult>(response);
            Assert.Equal(404, result.StatusCode);
        }

        [Fact]
        public async void get_monthly_report_should_return_json_for_valid_data()
        {
            var date = DateTime.Now;
            var expected = ReportsTestHelper.GetTestMonthlyReport(date);

            // Arrange
            var reportServiceMock = new Mock<IReportService>();
            var controllerMock = new ReportsController(reportServiceMock.Object);

            reportServiceMock.Setup(service => service.GetMonthlyReportAsync(date))
                             .Returns(Task.FromResult(expected));

            // Act
            var response = await controllerMock.Monthly();
            var result = response as JsonResult;
            var actual = result.Value as MonthlyReport;

            // Assert
            Assert.IsType<JsonResult>(response);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public async void get_monthly_report_should_return_not_found_for_invalid_data()
        {
            // Arrange
            var reportServiceMock = new Mock<IReportService>();
            var controllerMock = new ReportsController(reportServiceMock.Object);

            reportServiceMock.Setup(service => service.GetMonthlyReportAsync(DateTime.Now))
                             .Returns(Task.FromResult((MonthlyReport)null));

            // Act
            var response = await controllerMock.Monthly();
            var result = response as NotFoundResult;

            // Assert
            Assert.IsType<NotFoundResult>(response);
            Assert.Equal(404, result.StatusCode);
        }
    }
}
