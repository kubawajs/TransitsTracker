using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransitsTracker.Core.Domain
{
    public class MonthlyReportItem
    {
        //[Key]
        //public int Id { get; private set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; private set; }
        
        [JsonProperty(PropertyName = "total_distance")]
        public int TotalDistance { get; private set; }

        [JsonProperty(PropertyName = "avg_distance")]
        public decimal AverageDistance { get; private set; }

        [JsonProperty(PropertyName = "avg_price")]
        public decimal AveragePrice { get; private set; }

        public MonthlyReportItem(IEnumerable<Transit> transits, DateTime date)
        {
            SetDate(date);
            SetTotalDistance(transits.ToList());
            SetAverageDistance(transits.ToList());
            SetAveragePrice(transits.ToList());
        }

        private void SetAveragePrice(List<Transit> transits)
        {
            var avgPrice = CalculateAveragePrice(transits);
            if(avgPrice < 0)
            {
                throw new Exception("Average price cannot be lower than 0.");
            }
            if (AveragePrice == avgPrice) return;
            AveragePrice = avgPrice;
        }

        private decimal CalculateAveragePrice(List<Transit> transits)
        {
            if(transits.Count <= 0)
            {
                return 0;
            }
            return CalculateTotalPrice(transits) / transits.Count;
        }

        private static decimal CalculateTotalPrice(List<Transit> transits)
            => transits.Sum(o => o.Price);

        private void SetAverageDistance(List<Transit> transits)
        {
            var avgDistance = CalculateAverageDistance(transits);
            if(avgDistance < 0)
            {
                throw new Exception("Average distance cannot be lower than 0.");
            }
            if (AverageDistance == avgDistance) return;
            AverageDistance = avgDistance;
        }

        private decimal CalculateAverageDistance(List<Transit> transits)
        {
            if (transits.Count <= 0)
            {
                return 0;
            }
            return CalculateTotalDistance(transits) / transits.Count;
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

        private int CalculateTotalDistance(List<Transit> transits)
            => transits.Sum(o => o.Distance);

        private void SetDate(DateTime date)
        {
            if(date == null)
            {
                throw new Exception("Date cannot be empty.");
            }
            if (Date == date) return;
            Date = date;
        }

        public static MonthlyReportItem Create(IEnumerable<Transit> transits, DateTime date)
            => new MonthlyReportItem(transits, date);
    }
}
