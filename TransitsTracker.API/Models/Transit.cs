using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransitsTracker.API.Models
{
    public class Transit
    {
        [JsonProperty(PropertyName = "source_address")]
        public string SourceAddress { get; set; }

        [JsonProperty(PropertyName = "destination_address")]
        public string DestinationAddress { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; set; }

        public int Distance { get; set; }
    }
}
