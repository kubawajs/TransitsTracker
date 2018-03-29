using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;


namespace TransitsTracker.Core.Domain
{
    public class Address
    {
        [Key]
        [JsonIgnore]
        public int Id { get; private set; }

        [JsonProperty(PropertyName = "city")]
        public string City { get; private set; }

        [JsonProperty(PropertyName = "street")]
        public string Street { get; private set; }

        [JsonProperty(PropertyName = "house_number")]
        public string HouseNo { get; private set; }

        public Address()
        {
        }

        public Address(string city, string street, string houseNo)
        {
            City = city;
            Street = street;
            HouseNo = houseNo;
        }

        public override string ToString()
        {
            return Street + " " + HouseNo + ", " + City;
        }

        public string ToRequestString()
        {
            return HouseNo + "+" + Street + "+" + City;
        }
    }
}
