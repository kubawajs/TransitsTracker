using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TransitsTracker.API.Models
{
    public class Transit
    {
        [Key]
        public int Id { get; private set; }

        [JsonProperty(PropertyName = "source_address")]
        public string SourceAddress { get; private set; }

        [JsonProperty(PropertyName = "destination_address")]
        public string DestinationAddress { get; private set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; private set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; private set; }

        public int Distance { get; private set; }
    }
}
