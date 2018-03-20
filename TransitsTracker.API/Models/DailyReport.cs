using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

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
            SetTotalDistance(transits.ToList());
            SetTotalPrice(transits.ToList());
        }

        private void SetTotalPrice(List<Transit> transits)
        {
            var totalPrice = CalculateTotalPrice(transits);
            if (totalPrice < 0)
            {
                throw new Exception("Total price cannot be lower than 0.");
            }
            if (TotalPrice == totalPrice) return;
            TotalPrice = totalPrice;
        }   

        private void SetTotalDistance(List<Transit> transits)
        {
            var totalDistance = CalculateTotalDistance(transits);
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
