using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransitsTracker.API.Models
{
    public class MonthlyReportItem
    {
        [Key]
        public int Id { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }
        
        [JsonProperty(PropertyName = "total_distance")]
        public int TotalDistance { get; set; }

        [JsonProperty(PropertyName = "avg_distance")]
        public int AverageDistance { get; set; }

        [JsonProperty(PropertyName = "avg_price")]
        public decimal AveragePrice { get; set; }
    }
}
