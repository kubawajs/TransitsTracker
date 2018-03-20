using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace TransitsTracker.API.Models
{
    public class DailyReport : Report
    {
        [JsonProperty(PropertyName = "total_distance")]
        public int TotalDistance { get; private set; }

        [JsonProperty(PropertyName = "total_price")]
        public decimal TotalPrice { get; private set; }

        private DailyReport()
        {
        }

        private DailyReport(IEnumerable<Transit> transits)
        {
            // TODO: refactoring

            int totalDistance = 0;
            decimal totalPrice = 0;

            foreach (var transit in transits)
            {
                totalDistance += transit.Distance;
                totalPrice += transit.Price;
            }

            SetReportParameters(totalDistance, totalPrice);
        }

        private void SetReportParameters(int totalDistance, decimal totalPrice)
        {
            SetTotalDistance(totalDistance);
            SetTotalPrice(totalPrice);
        }

        private void SetTotalPrice(decimal totalPrice)
        {
            if (totalPrice < 0)
            {
                throw new Exception("Total price cannot be lower than 0.");
            }
            if (TotalPrice == totalPrice) return;
            TotalPrice = totalPrice;
        }

        private void SetTotalDistance(int totalDistance)
        {
            if(totalDistance < 0)
            {
                throw new Exception("Total distance cannot be lower than 0.");
            }
            if (TotalDistance == totalDistance) return;
            TotalDistance = totalDistance;
        }

        public static DailyReport Create(IEnumerable<Transit> transits)
            => new DailyReport(transits);
    }
}
