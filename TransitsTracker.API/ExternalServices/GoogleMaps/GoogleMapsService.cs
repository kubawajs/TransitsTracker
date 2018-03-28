using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TransitsTracker.API.Models;
using TransitsTracker.API.Services;

namespace TransitsTracker.API.ExternalServices.GoogleMaps
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

        public async Task<int> GetDistanceAsync(Address source, Address destination)
        {
            var url = CreateUrlWithParameters(source, destination);
            var request = CreateGetRequest(url);

            var responseObject = await GetResponseAsDistanceMatrix(request);
            var distVal = responseObject.GetDistanceValue();

            return distVal;
        }

        private static async Task<DistanceMatrixResponse> GetResponseAsDistanceMatrix(HttpWebRequest request)
        {
            var response = await request.GetResponseAsync();
            var jsonResponse = ResponseToJson(response);
            return JsonToDistanceMatrix(jsonResponse);
        }

        private static DistanceMatrixResponse JsonToDistanceMatrix(string jsonResponse)
        {
            return JsonConvert.DeserializeObject<DistanceMatrixResponse>(jsonResponse);
        }

        private static string ResponseToJson(WebResponse response)
        {
            string jsonResponse;
            using (var sr = new StreamReader(response.GetResponseStream()))
            {
                jsonResponse = sr.ReadToEnd();
            }

            return jsonResponse;
        }

        private static HttpWebRequest CreateGetRequest(StringBuilder url)
        {
            var request = (HttpWebRequest)WebRequest.Create(url.ToString());
            request.Method = "GET";
            request.ContentType = "application/json";
            return request;
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
            AddAddressParams(source, destination, url);
            AddApiKey(url);
        }

        private static void AddAddressParams(Address source, Address destination, StringBuilder url)
        {
            AddSourceParam(source, url);
            AddDestinationParam(destination, url);
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
