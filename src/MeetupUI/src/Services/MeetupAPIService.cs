using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using DomainModel.OAuth;
using Newtonsoft.Json;
using RestSharp;

namespace meetupraffle.Services
{
    public class MeetupAPIService 
    {
        public static async Task<T> FetchObjectsAsync<T>(string URL, OAuthToken at = null)
        {
            var client = new RestClient(URL);
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            if (at != null)
                request.AddHeader("authorization", String.Concat("Bearer ", at.AccessToken)); 
            IRestResponse response2 = await client.ExecuteAsync(request);
            var cleanJSON = Regex.Unescape(response2.Content);
            var serializedJSON = cleanJSON.Trim('\"');
            return JsonConvert.DeserializeObject<T>(serializedJSON);
        }
    }
}