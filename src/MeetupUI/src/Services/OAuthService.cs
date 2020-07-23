using DomainModel.OAuth;

namespace meetupraffle.Services
{
    public class OAuthService 
    {
        public static OAuthToken GetToken()
        {
            //var response = await _httpClient.GetAsync("https://secure.meetup.com/oauth2/authorize?client_id=e64tk5our0g65i1msa2hdpu087&response_type=code&redirect_uri=https://localhost:5001");
            //var clientI = new RestClient("https://secure.meetup.com/oauth2/authorize?client_id=e64tk5our0g65i1msa2hdpu087&response_type=code&redirect_uri=https://localhost:5001");
            //var requestI = new RestRequest(Method.GET);
            //IRestResponse responseI = clientI.Execute(requestI);
            //var code = response.ToString();
            //string URL = String.Format("https://api.meetup.com/:{0}/events/:{1}/rsvps", GroupName, EventID);
            //string URL = String.Format("http://localhost:5001/:{0}/events/:{1}/rsvps", GroupName, EventID);

            // var client = new RestClient("https://secure.meetup.com/oauth2/access");
            // var request = new RestRequest(Method.POST);
            // request.AddHeader("cache-control", "no-cache");
            // request.AddHeader("content-type", "application/x-www-form-urlencoded");
            // request.AddParameter("application/x-www-form-urlencoded", "client_id=e64tk5our0g65i1msa2hdpu087&client_secret=nl1lse544tm8liqul19guskfb3&grant_type=authorization_code&redirect_uri=https://localhost:5001&code=140623190929e619997c049ff3a48fc6", ParameterType.RequestBody);
            // IRestResponse response = client.Execute(request);
            // Token t = JsonConvert.DeserializeObject<Token>(response.Content);
            return null;
        }
    }
}