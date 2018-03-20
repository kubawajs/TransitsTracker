using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransitsTracker.API.Models
{
    public class DailyReport : Report
    {
        [JsonProperty(PropertyName = "total_distance")]
        public int TotalDistance { get; set; }

        [JsonProperty(PropertyName = "total_price")]
        public decimal TotalPrice { get; set; }
    }
}
