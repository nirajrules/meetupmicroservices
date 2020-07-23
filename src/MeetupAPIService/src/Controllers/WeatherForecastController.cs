using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using RestSharp;
using System.Collections.Generic;

namespace MeetupAPIService.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MeetupAPIController : ControllerBase
    {
        [HttpGet("{URL}")]
        public async Task<string> GetAttendees(string URL)
        {
            URL = System.Web.HttpUtility.UrlDecode(URL);
            var client = new RestClient(URL);
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            // if (at != null)
            //     request.AddHeader("authorization", String.Concat("Bearer ", at.AccessToken));
            IRestResponse response = await client.ExecuteAsync(request);
            return response.Content;
        }
    }
}