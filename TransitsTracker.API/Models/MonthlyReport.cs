using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TransitsTracker.API.Models
{
    public class MonthlyReport : Report
    {
        public HashSet<MonthlyReportItem> Items { get; private set; }

        private MonthlyReport()
        {
        }

        private MonthlyReport(IEnumerable<Transit> transits, DateTime date)
        {
            InitializeItemsHashSet();
            AddItemsToReport(transits.ToList(), date);
        }

        private void AddItemsToReport(List<Transit> transits, DateTime date)
        {
            var proceededDate = GetStartOfMonthDate(date);

            while (proceededDate < date)
            {
                var transitsForDay = GetTransitsForDay(transits, proceededDate);
                Items.Add(MonthlyReportItem.Create(transitsForDay, proceededDate));
                proceededDate = proceededDate.AddDays(1);
            }
        }

        private void InitializeItemsHashSet()
        {
            Items = new HashSet<MonthlyReportItem>();
        }

        private static IEnumerable<Transit> GetTransitsForDay(List<Transit> transits, DateTime date)
            => transits.Where(o => o.Date == date);

        private static DateTime GetStartOfMonthDate(DateTime date)
        {
            return new DateTime(date.Year, date.Month, 1);
        }

        public static MonthlyReport Create(IEnumerable<Transit> transits, DateTime date)
            => new MonthlyReport(transits, date);
    }
}
