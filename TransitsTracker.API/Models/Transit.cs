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
        [JsonIgnore]
        public int Id { get; private set; }

        [JsonProperty(PropertyName = "source_address")]
        public Address SourceAddress { get; set; }

        [JsonProperty(PropertyName = "destination_address")]
        public Address DestinationAddress { get; set; }

        [JsonProperty(PropertyName = "price")]
        public decimal Price { get; set; }

        [JsonProperty(PropertyName = "date")]
        public DateTime Date { get; private set; }

        public int Distance { get; private set; }

        public Transit()
        {
        }

        public void SetDistance(int distance)
        {
            if(distance < 0)
            {
                throw new Exception("Distance cannot be lower than 0.");
            }
            if (Distance == distance) return;
            Distance = distance;
        }
    }
}
