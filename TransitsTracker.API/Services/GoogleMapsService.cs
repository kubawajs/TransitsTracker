using Newtonsoft.Json;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TransitsTracker.API.Models;

namespace TransitsTracker.API.Services
{
    public class GoogleMapsService : IMapService
    {
        #region const
        private const string API_KEY = "key";
        private const string BASE_URL = @"https://maps.googleapis.com/maps/api/distancematrix/json?";
        private const string ORIGIN = "origins=";
        private const string DESTINATION = "&destinations=";
        private const string KEY = "&key=";
        #endregion


        public async Task GetDistanceAsync(Address source, Address destination)
        {
            var url = CreateUrlWithParameters(source, destination);

            var request = (HttpWebRequest)WebRequest.Create(url.ToString());
            request.Method = "GET";
            request.ContentType = "application/json";

            var response = await request.GetResponseAsync();

            // TODO: serialization

        }

        private static StringBuilder CreateUrlWithParameters(Address source, Address destination)
        {
            var url = new StringBuilder();
            PrepareRequestUrl(source, destination, url);
            return url;
        }

        private static void PrepareRequestUrl(Address source, Address destination, StringBuilder url)
        {
            url.Append(BASE_URL);
            AddSourceParam(source, url);
            AddDestinationParam(destination, url);
            AddApiKey(url);
        }

        private static void AddApiKey(StringBuilder url)
        {
            url.Append(KEY);
            url.Append(API_KEY);
        }

        private static void AddDestinationParam(Address destination, StringBuilder url)
        {
            url.Append(DESTINATION);
            url.Append(destination.ToRequestString());
        }

        private static void AddSourceParam(Address source, StringBuilder url)
        {
            url.Append(ORIGIN);
            url.Append(source.ToRequestString());
        }
    }
}
