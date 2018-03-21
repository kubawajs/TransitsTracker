using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TransitsTracker.API.Models
{
    public class Address
    {
        public string City { get; private set; }
        public string Street { get; private set; }
        public string HouseNo { get; private set; }

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
