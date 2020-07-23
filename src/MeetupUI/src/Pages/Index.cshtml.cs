using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using DomainModel.Meetup;
using RestSharp;
using Newtonsoft.Json;
using System.Text.RegularExpressions;
using System.IO;

namespace meetupraffle.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        [Required]
        public string GroupName { get; set; }

        [BindProperty]
        [Required]
        public string EventID { get; set; }

        [BindProperty]
        public List<RSVP> RSVPs { get; set; }

        [BindProperty]
        public RSVP Winner { get; set; }

        private readonly ILogger<IndexModel> _logger;


        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
            //IndexViewModel = new IndexViewModel();
            EventID = "qlmdrqybckbcb";
            GroupName = "Charlotte-Microsoft-Azure1";
            RSVPs = new List<RSVP>();
            Winner = new RSVP();
            Winner.Name = String.Empty;
        }

        public async Task<IActionResult> OnPostFetchRSVPsAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            //Clear the existing dataset and session variable
            RSVPs.Clear();
            HttpContext.Session.SetString("currentWinners", "");
            List<Attendee> attendees = new List<Attendee>();
            string meetupRsvpMemberOnlyUrl =  Environment.GetEnvironmentVariable("MEETUP_RSVP_MEMBERONLY_URL");
            string queryString = string.Format(meetupRsvpMemberOnlyUrl, GroupName, EventID);
            queryString = System.Web.HttpUtility.UrlEncode(queryString);
            string URL = Environment.GetEnvironmentVariable("API_URL");
            var client = new RestClient(string.Format("{0}/{1}", URL, queryString));
            var request = new RestRequest(Method.GET);
            request.AddHeader("content-type", "application/json");
            string dir = Directory.GetCurrentDirectory();
            //Request URL to retrive events; no authentication required 
            IRestResponse response = null;
            try
            {
                // request.AddHeader("authorization", String.Concat("Bearer ", at.AccessToken));
                response = await client.ExecuteAsync(request);
                var cleanJSON = Regex.Unescape(response.Content);
                var serializedJSON = cleanJSON.Trim('\"');
                attendees = JsonConvert.DeserializeObject<List<Attendee>>(serializedJSON);
            }
            catch (Exception)
            {
                Winner.Name = "Couldn't Fetch details for the given Group / Event!!";
                return Page();
            }
            if(attendees == null)
            {
                Winner.Name = "Couldn't Fetch details for the given Group / Event!!";
                return Page();
            }
            foreach (var attendee in attendees)
            {
                RSVPs.Add(new RSVP() { Name = attendee.Member.Name, PictureUri = attendee.Member.Photo != null ? attendee.Member.Photo.ThumbLink.ToString() : "" });
            }
            return Page();
        }


        public IActionResult OnPostPickWinnerAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string currentWinners = HttpContext.Session.GetString("currentWinners");

            int winnerId = WinnerManager.PickNextWinner<RSVP>(currentWinners, RSVPs);

            if (winnerId == -1)
                Winner.Name = "No more atteendees left!!!";
            else
            {
                Winner.Name = RSVPs[winnerId].Name;
                Winner.PictureUri = RSVPs[winnerId].PictureUri;
                currentWinners = currentWinners + winnerId.ToString() + ",";
                HttpContext.Session.SetString("currentWinners", currentWinners);
            }

            return Page();
        }
    }

    public class RSVP
    {
        [BindProperty]
        public string Name { get; set; }
        [BindProperty]
        public string PictureUri { get; set; }
    }
}