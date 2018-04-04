using System;
using System.Collections.Generic;
using System.Text;
using TransitsTracker.Core.Domain;

namespace TransitsTracker.Tests.Unit.Helpers
{
    public static class ReportsTestHelper
    {
        public static DailyReport GetTestDailyReport()
            => CreateTestDailyReport();

        private static DailyReport CreateTestDailyReport()
        {
            var transits = TransitsTestHelper.GetTestTransits();
            return DailyReport.Create(transits);
        }

        public static MonthlyReport GetTestMonthlyReport(DateTime date)
            => CreateTestMonthlyReport(date);

        private static MonthlyReport CreateTestMonthlyReport(DateTime date)
        {
            var transits = TransitsTestHelper.GetTestTransits();
            return MonthlyReport.Create(transits, date);
        }
    }
}
