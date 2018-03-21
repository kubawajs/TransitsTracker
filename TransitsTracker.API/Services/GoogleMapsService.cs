using Newtonsoft.Json;
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
        private const string _apiKey = "KEY";
        private const string _baseUrl = @"https://maps.googleapis.com/maps/api/distancematrix/json?";
        private const string _sourceParam = "origins=";
        private const string _destinationParam = "&destinations=";
        private const string _keyParam = "&key=";
        #endregion

        private HttpWebRequest request;


        public async Task GetDistanceAsync(Address source, Address destination)
        {
            var url = CreateUrlWithParameters(source, destination);

            request = (HttpWebRequest)WebRequest.Create(url.ToString());
            request.Method = "GET";
            request.ContentType = "application/json";

            var serializer = new JsonSerializer();
            var response = await request.GetResponseAsync();
        }

        private static StringBuilder CreateUrlWithParameters(Address source, Address destination)
        {
            var url = new StringBuilder();
            PrepareRequestUrl(source, destination, url);
            return url;
        }

        private static void PrepareRequestUrl(Address source, Address destination, StringBuilder url)
        {
            url.Append(_baseUrl);
            AddSourceParam(source, url);
            AddDestinationParam(destination, url);
            AddApiKey(url);
        }

        private static void AddApiKey(StringBuilder url)
        {
            url.Append(_keyParam);
            url.Append(_apiKey);
        }

        private static void AddDestinationParam(Address destination, StringBuilder url)
        {
            url.Append(_destinationParam);
            url.Append(destination.ToRequestString());
        }

        private static void AddSourceParam(Address source, StringBuilder url)
        {
            url.Append(_sourceParam);
            url.Append(source.ToRequestString());
        }
    }
}
