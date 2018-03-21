using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransitsTracker.API.ExternalServices.GoogleMaps
{
    public class Distance
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }

    public class Duration
    {
        public string Text { get; set; }
        public int Value { get; set; }
    }

    public class Element
    {
        public Distance Distance { get; set; }
        public Duration Duration { get; set; }
        public string Status { get; set; }
    }

    public class Row
    {
        public List<Element> Elements { get; set; }
    }

    public class DistanceMatrixResponse
    {
        [JsonProperty(PropertyName = "destination_addresses")]
        public List<string> DestinationAddresses { get; set; }

        [JsonProperty(PropertyName = "origin_addresses")]
        public List<string> OriginAddresses { get; set; }

        public List<Row> Rows { get; set; }
        public string Status { get; set; }

        public string GetDistanceText()
        {
            return Rows.First().Elements.First().Distance.Text;
        }

        public int GetDistanceValue()
        {
            return Rows.First().Elements.First().Distance.Value;
        }
    }
}
